using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeammatesRemaining : MonoBehaviour
{
    int deadCount = 0;
    [SerializeField] Text textComponent;
    [SerializeField] int startingCount;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        deadCount = GameObject.Find("GameManagement").GetComponent<GameManagement>().blueLeft;
        textComponent.text = ("TEAM x " + (deadCount).ToString());
    }
}