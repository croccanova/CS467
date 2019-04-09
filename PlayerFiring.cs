using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PlayerFiring : MonoBehaviour
{
    private Rigidbody body;
    //private bool hasTarget;
    //private GameObject target;

    public Rigidbody projectile;
    public Transform launch;
    //public BotMovement moveScript;
    public float launchForce;
    private float fireInterval;
    private bool coolingDown;
    private float lastFired;


    AudioSource[] audioSources;
    AudioSource blast;

    private void Start()
    {
        body = GetComponent<Rigidbody>();
        audioSources = GetComponents<AudioSource>();
        blast = audioSources[0];

        coolingDown = false;
        lastFired = 0f;
        fireInterval = 0.7f;


    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }

        if (GetComponent<testCube>().shot == true)
        {
            return;
        }

        if (coolingDown)
        {
            lastFired += Time.deltaTime;
            if (lastFired > fireInterval)
            {
                coolingDown = false;
            }
        }

        if (Input.GetMouseButton(0) && !coolingDown)
        {
            Fire();
            coolingDown = true;
            lastFired = 0f;
        }
    }

    private void Fire()
    {
        Rigidbody shot =
            Instantiate (projectile, launch.position, launch.rotation) as Rigidbody;
        blast.Play();
        projectile.gameObject.GetComponent<ProjectileDestroy>().SetOriginator(body.gameObject);
        Physics.IgnoreCollision(shot.GetComponent<Collider>(), GetComponent<BoxCollider>());

        //Physics.IgnoreCollision(shot.GetComponent<Collider>(), GetComponent<SphereCollider>());

        // Set the shell's velocity to the launch force in the fire position's forward direction.
        shot.velocity = launchForce * launch.forward + body.velocity;
    }
}