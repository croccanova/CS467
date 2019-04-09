using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyHitDetector : MonoBehaviour
{
    GameObject manager,
               bolt;
    AudioSource hitSound;
    AudioSource[] audioSources;


    // Start is called before the first frame update
    void Start()
    {
        audioSources = GetComponents<AudioSource>();
        hitSound = audioSources[0];
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
                    manager.GetComponent<GameManagement>().blueScore += 1;
                    hit.collider.GetComponent<BotFiring>().stop = true;
                    hit.collider.GetComponent<BotMovement>().stop = true;
                }

                hit.collider.GetComponent<TargetDummy>().shot = true;
                hitSound.Play();

                Destroy(this.gameObject);

            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }
}
