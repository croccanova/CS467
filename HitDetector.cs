using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetector : MonoBehaviour
{
    GameObject manager,
               player,
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
        Ray ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out hit, 1.0f))
        {
            // check if enemy was hit
            if (hit.collider.gameObject.tag == "Enemy")
            {
                if (hit.collider.GetComponent<TargetDummy>().shot != true)
                {
                    player.GetComponent<testCube>().hitCount += 1;
                    manager.GetComponent<GameManagement>().blueScore += 1;

                    //count this enemy as being shot
                    hit.collider.GetComponent<TargetDummy>().shot = true;

                    // if these scripts exist, make them stop
                    if (hit.collider.GetComponent<BotFiring>() || hit.collider.GetComponent<BotMovement>())
                    {
                        hit.collider.GetComponent<BotFiring>().stop = true;
                        hit.collider.GetComponent<BotMovement>().stop = true;
                    }
                }                             

                hitSound.Play();

                //check if its a mover for tutorial level
                if (hit.collider.GetComponent<enemy_5_movement>())
                {
                    hit.collider.GetComponent<enemy_5_movement>().stop = true;
                }

                
                Destroy(this.gameObject);

            }
            else
            {
                Destroy(this.gameObject);
            }



        }
    }
}
