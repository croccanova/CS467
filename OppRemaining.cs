using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OppRemaining : MonoBehaviour
{
    public int deadCount = 0;
    public int botKills = 0;
    [SerializeField] int initialCount;
    [SerializeField] Text textComponent;
    public GameObject manager;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("GameManagement");
    }

    // Update is called once per frame
    void Update()
    {
        
        deadCount = manager.GetComponent<GameManagement>().redLeft;        
        textComponent.text = ("OPPONENT x " + (deadCount).ToString());
    }
}
