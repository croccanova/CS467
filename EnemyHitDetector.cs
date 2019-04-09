using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitDetector : MonoBehaviour
{

    GameObject player,
               manager,
               bolt;
    AudioSource hitSound;
    AudioSource[] audioSources;

    // Start is called before the first frame update
    void Start()
    {
        audioSources = GetComponents<AudioSource>();
        hitSound = audioSources[0];
        player = GameObject.Find("TestPlayer");
        manager = GameObject.Find("GameManagement");
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        // raycast allows for detection of object in from of the bullet.
        Ray ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out hit, 1.0f))
        {
            // if player is hit returns them to portal exit at null velocity
            if (hit.collider.gameObject.tag == "TestPlayer" && hit.collider.GetComponent<testCube>().shot == false)
            {
                //print("Player Hit!");
                player.GetComponent<testCube>().shot = true;
                player.GetComponent<Rigidbody>().velocity = Vector3.zero;

                GameObject.Find("GameManagement").GetComponent<GameManagement>().redScore += 1;
                hitSound.Play();
                Destroy(gameObject);
            }
            else if(hit.collider.gameObject.tag == "Ally")
            {
                if (hit.collider.GetComponent<TargetDummy>().shot == false)
                {
                    manager.GetComponent<GameManagement>().redScore += 1;
                    hit.collider.GetComponent<BotFiring>().stop = true;
                    hit.collider.GetComponent<BotMovement>().stop = true;
                }

                hit.collider.GetComponent<TargetDummy>().shot = true;
                hitSound.Play();
            }

            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        print("OnCollisionEnter called");
        if (other.collider.gameObject.tag == "edge")
        {
            return;
        }

        if (other.collider.gameObject.tag == "TestPlayer" && other.collider.GetComponent<testCube>().shot == false)
        {
            //print("Player Hit!");
            player.GetComponent<testCube>().shot = true;
            player.GetComponent<Rigidbody>().velocity = Vector3.zero;

            GameObject.Find("GameManagement").GetComponent<GameManagement>().redScore += 1;
            hitSound.Play();
            Destroy(gameObject);
        }

        print("Projectile destroyed on collision with " + other.collider.gameObject.ToString());
        //Destroy(gameObject);

        //objectCollidedWith = other.collider.gameObject;
        //collisionHasOccurred = true;
    }
}
