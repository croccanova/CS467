using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawn : MonoBehaviour
{
    // spawn point assigned in inspector
    public GameObject spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        spawn();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // moves object to its spawn point
    void spawn()
    {
        transform.position = spawnPoint.transform.position;
    }
}
