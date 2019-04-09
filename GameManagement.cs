/*
 *  Keeps track of remaining number of members on either team and manages game state accordingly
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagement : MonoBehaviour
{
    public int blueLeft; 
    public int redLeft;
    public int blueScore;
    public int redScore;
    public int blueStart;
    public int redStart;
    private bool done = false;

    AudioSource victorySound;
    AudioSource[] audioSources;

    // Start is called before the first frame update
    void Start()
    {
        audioSources = GetComponents<AudioSource>();
        victorySound = audioSources[0];
        blueScore = 0;
        redScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (done == false)
        {
            blueLeft = blueStart - redScore;
            redLeft = redStart - blueScore;
            //print("blueScore = " + blueScore);
            //print("redLeft = " + redLeft);
            //you lose :(
            if (blueLeft <= 0)
            {
                done = true;
                //print("YOU LOSE!!!!!!!!!!!!!!!!!!!!!!!");

                // load game over here
                SceneManager.LoadScene("losingScreen");
            }
            //you win! :D
            if (redLeft <= 0)
            {
                done = true;
                //print("final: " + blueScore);
                //print("YOU WIN!!!!!!!!!!!!!!!!!!!!!!!");
                //System.Threading.Thread.Sleep(10);
                //victorySound.Play();
                // load game over here
                SceneManager.LoadScene("winningScreen");
            }
        }
    }
}
