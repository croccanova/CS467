using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemiesStunnedCount : MonoBehaviour
{
    int count = 0;
    [SerializeField] Text textComponent;
    GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("TestPlayer");
    }

    // Update is called once per frame
    void Update()
    {
        count = player.GetComponent<testCube>().hitCount;
        textComponent.text = count.ToString();
    }
}
