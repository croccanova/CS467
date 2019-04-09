using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalSpawn : MonoBehaviour
{

    public GameObject spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Enemies").GetComponent<targetCheck>().done == true)
        {
            spawn();
        }
    }

    void spawn()
    {
        transform.position = spawnPoint.transform.position;
    }
}
