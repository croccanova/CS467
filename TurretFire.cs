using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretFire : MonoBehaviour
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

    //AudioSource[] audioSources;
    //AudioSource blast;

    private void Start()
    {
        body = GetComponent<Rigidbody>();
        launch = body.transform;
        //audioSources = GetComponents<AudioSource>();
        //blast = audioSources[0];

        coolingDown = false;
        lastFired = 0f;
        fireInterval = 2.0f;


    }

    private void Update()
    {

        if (coolingDown)
        {
            lastFired += Time.deltaTime;
            if (lastFired > fireInterval)
            {
                coolingDown = false;
            }
        }

        if (!coolingDown)
        {
            Fire();
            coolingDown = true;
            lastFired = 0f;
        }
    }

    private void Fire()
    {
        //print("Fire!");
        Rigidbody shot =
            Instantiate(projectile, launch.position, launch.rotation) as Rigidbody;
        //blast.Play();
        // Set the shell's velocity to the launch force in the fire position's forward direction.
        shot.velocity = launchForce * launch.forward;
    }
}
