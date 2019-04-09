using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class testCube : MonoBehaviour
{
     
    public GameObject player;
    public GameObject closestObj;
    public GameObject spawnPoint;
    public GameObject portalExitA;
    public GameObject portalExitB;
    private CharacterController charCont;
    private Vector3 offset;
    //private float speed = 5.0f;
    //private string message = "Press F to Latch";
    public bool isLatched;
    public int hitCount;
    public bool teleport1;
    public bool teleport2;
    public bool shot = false;

    //https://assetstore.unity.com/packages/audio/music/absolute-space-sci-fi-music-free-sample-103274
    //https://assetstore.unity.com/packages/audio/sound-fx/free-casual-game-sfx-pack-54116
    AudioSource thud;
    AudioSource blast;
    AudioSource warp;
    AudioSource victory;
    AudioSource[] audioSources;
    public Rigidbody rigidBody;


    //float closestDist = float.MaxValue; //initialize to maximum possible value

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        charCont = GetComponent<CharacterController>();
        audioSources = GetComponents<AudioSource>();
        thud = audioSources[1];
        warp = audioSources[2];
        victory = audioSources[3];
        
        spawn();
        isLatched = true;
        hitCount = 0;

        teleport1 = false;
        teleport2 = false;

}

    // Update is called once per frame
    void Update()
    {
        if (shot)
        {
            return;
        }

        launch();
        
        // reset to spawn point if stuck
        if (Input.GetKey(KeyCode.Home))
        {
            transform.position = spawnPoint.transform.position;
            // halts velocity
            rigidBody.velocity = Vector3.zero;

            // halts rotation
            rigidBody.angularVelocity = Vector3.zero;

            isLatched = true;
        }        

    }

    //player movement function - applies a set force to the player in the direction of the camera
    void launch()
    {
        if (isLatched == true)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                // launch direction is forward in relation to the camera
                var direction = Camera.main.transform.forward;

                //launch strength
                var strength = 100;

                // launch in the direction of the cursor
                rigidBody.AddRelativeForce(direction * strength);

                // character has launched and is thus no longer latched
                isLatched = false;
            }
            
        }
    }
    // trigger for events on collision
    private void OnCollisionEnter(Collision collision)
    {

        //goes through first teleporter
        if (collision.gameObject.tag == "EventHorizon")
        {
            playSound(warp);
            rigidBody.velocity = Vector3.zero;
            rigidBody.angularVelocity = Vector3.zero;
            transform.position = portalExitA.transform.position;
            teleport1 = true;
            spawnPoint = portalExitA;

            isLatched = true;

        }
        //goes through second teleporter
        else if (collision.gameObject.tag == "EventHorizon2")
        {
            playSound(warp);
            rigidBody.velocity = Vector3.zero;
            rigidBody.angularVelocity = Vector3.zero;
            transform.position = portalExitB.transform.position;
            teleport2 = true;
            spawnPoint = portalExitB;
            isLatched = true;

        }
        //goes through exit
        else if (collision.gameObject.tag == "Exit")
        {
            //you win!
            SceneManager.LoadScene("TutorialWinScreen", LoadSceneMode.Single);

        }
        else
        {
            playSound(thud);
        }

        // basic "latch" functionality - arrests motion if the F key is pressed when a collision occurs
        if (Input.GetKey(KeyCode.F))
        {
            // halts velocity
            rigidBody.velocity = Vector3.zero;

            // halts rotation
            rigidBody.angularVelocity = Vector3.zero;

            isLatched = true;

        }
    }


    void playSound(AudioSource source)
    {
        source.Play();
    }

    void spawn()
    {
        transform.position = spawnPoint.transform.position;
    }

    IEnumerator end()
    {
        
        yield return new WaitWhile(() => victory.isPlaying);
        
    }


}
