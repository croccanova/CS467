using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_5_movement : MonoBehaviour
{
   [SerializeField] Vector3 movementVector;
    Vector3 startingPos;
    Vector3 direction;
    GameObject dummy;
    Rigidbody body;
    [Range(0, 1)] [SerializeField] float movementFactor;
    float period = 2.0f;
    [SerializeField] int driftForce = 5;
    public bool stop = false;


    // Start is called before the first frame update
    void Start()
    {
        //startingPos = dummy.GetComponent<enemySpawn>().spawnPoint.transform.position;
        startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        

        //if (dummy.GetComponent<TargetDummy>().shot == true)
        if (stop == false)
        {
            float cycles = Time.time / period;
            const float tau = Mathf.PI * 1.0f;
            float rawSinWave = Mathf.Sin(cycles * tau);

            movementFactor = rawSinWave / 2.0f + 0.5f;
            Vector3 offset = movementVector * movementFactor;
            transform.position = startingPos + offset;
            direction = transform.forward;
            //print(direction);
        }
        else
        {
            //body.AddForce(driftForce * transform.forward);
        }

    }
}
