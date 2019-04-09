using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetsRemaining : MonoBehaviour
{
    private int deadCount = 0;

    [SerializeField] int initialCount;
    [SerializeField] Text textComponent;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        deadCount = GameObject.Find("TestPlayer").GetComponent<testCube>().hitCount;
        textComponent.text = ("OPPONENT x " + (initialCount -(deadCount)).ToString());
    }
}
