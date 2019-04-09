/*
 * hit detection for tutorial level bullets
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadBulletDetector : MonoBehaviour
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

        // raycast allows for detection of object in from of the bullet.
        Ray ray = new Ray(transform.position, Vector3.forward);

        if (Physics.Raycast(ray, out hit, 1.0f))
        {
            // if player is hit returns them to portal exit at null velocity
            if (hit.collider.gameObject.tag == "TutorialPlayer")
            {
                GameObject.Find("TestPlayer").GetComponent<testCube>().transform.position = GameObject.Find("TestPlayer").GetComponent<testCube>().portalExitB.transform.position;
                GameObject.Find("TestPlayer").GetComponent<testCube>().rigidBody.velocity = Vector3.zero;
                GameObject.Find("TestPlayer").GetComponent<testCube>().isLatched = true;
                Destroy(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }



        }
    }
}
