using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_popup : MonoBehaviour
{

    private bool showText = false, someRandomCondition = true;
    private float currentTime = 0.0f, executedTime = 0.0f, timeToWait = 5.0f;
    public string objective;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    void OnMouseDown()
    {
        executedTime = Time.time;
        objective = "Get to the portal.";
    }



    // Update is called once per frame
    void Update()
    {
        currentTime = Time.time;
        if (someRandomCondition)
            showText = true;
        else
            showText = false;

        if (executedTime != 0.0f)
        {
            if (currentTime - executedTime > timeToWait)
            {
                executedTime = 0.0f;
                someRandomCondition = false;
            }
        }
    }

    void OnGUI()
    {
        if (showText)
        {

            GUI.contentColor = Color.yellow;

            // show controls
            GUI.Label(new Rect(5, 0, 300, 100), "Controls:");
            GUI.Label(new Rect(5, 15, 300, 100), "Launch: Spacebar");
            GUI.Label(new Rect(5, 30, 300, 100), "Cling: F");
            GUI.Label(new Rect(5, 45, 300, 100), "Fire: Left Mouse Button");
            GUI.Label(new Rect(5, 60, 300, 100), "Reset to Spawn: Home");

            // alters objective message based on progression in the level
            if (GameObject.Find("TestPlayer").GetComponent<testCube>().teleport1 == true && GameObject.Find("TestPlayer").GetComponent<testCube>().teleport2 == true)
            {
                GUI.Label(new Rect(5, 75, 500, 500), "Objective: Get to the exit.  Dont get hit!");
            }
            else if (GameObject.Find("TestPlayer").GetComponent<testCube>().teleport1 == true)
            {
                GUI.Label(new Rect(5, 75, 500, 500), "Objective: Stun all the targets.");
            }
            else
            {
                GUI.Label(new Rect(5, 75, 500, 500), "Objective: Get to the portal.");
            }
            
        }


    }

    void centerText()
    {

    }
    
}
