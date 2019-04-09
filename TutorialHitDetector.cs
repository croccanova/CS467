using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialHitDetector : MonoBehaviour
{
    GameObject bolt;
    AudioSource hitSound;
    AudioSource[] audioSources;


    // Start is called before the first frame update
    void Start()
    {
        audioSources = GetComponents<AudioSource>();
        hitSound = audioSources[0];
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, GameObject.Find("TestPlayer").GetComponent<PlayerFiring>().launch.forward);

        if (Physics.Raycast(ray, out hit, 2.5f))
        {
            // check if enemy was hit
            if (hit.collider.gameObject.tag == "Enemy")
            {
                if (hit.collider.GetComponent<TargetDummy>().shot != true)
                {
                    GameObject.Find("TestPlayer").GetComponent<testCube>().hitCount += 1;

                    //count this enemy as being shot
                    hit.collider.GetComponent<TargetDummy>().shot = true;
                }

                hitSound.Play();

                //check if its a mover for tutorial level
                if (hit.collider.GetComponent<enemy_5_movement>())
                {
                    hit.collider.GetComponent<enemy_5_movement>().stop = true;
                }

            }



        }
    }
}
