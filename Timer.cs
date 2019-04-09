using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
    float startTime = 0.0f;
    float timeChange;
    float timeTotal = 0;
    int timeSec;
    int timeMin;
    int timeMinSec;
    string timeString;
    GameObject matchTimer;
    [SerializeField] Text timeText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // calculate time
        timeChange = Time.deltaTime;
        timeTotal += timeChange;
        timeSec = (int)(timeTotal - (timeTotal % 1));
        timeMin = timeSec / 60;
        timeMinSec = timeSec % 60;

        //keeps format constant if leas than 10 trailing seconds
        if (timeMinSec < 10)
        {
            timeString = (timeMin.ToString() + " : 0" + timeMinSec.ToString());
        }
        else
        {
            timeString = (timeMin.ToString() + " : " + timeMinSec.ToString());
        }        

        timeText.text = timeString;

    }
}
