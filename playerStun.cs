/*
 * Detects if a player has been stunned and swaps them with an active teammate.
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerStun : MonoBehaviour
{
    public GameObject player;
    //public int allies;
    public int enemies;
    public GameObject stunnedCharacter;
    private Transform originalPos;
    public GameObject manager;
    private float stunWait;
    public Text stunMessage,
                swapMessage;

    private void Start()
    {
        manager = GameObject.Find("GameManagement");
        stunWait = 0f;
    }

    private void Update()
    {
        // chaecks if player is stunned
        if (player.GetComponent<testCube>().shot == true)
        {
            if (stunWait == 0f)
            {
                stunMessage.text = "You have been stunned!";
                if (manager.GetComponent<GameManagement>().blueLeft > 0)
                {
                    swapMessage.text = "Assuming control of a teammate...";
                }
                else
                {
                    swapMessage.text = "No teammates left!";
                    return;
                }
            }
            stunWait += Time.deltaTime;
            if (stunWait < 2.0f)
            {
                return;
            }

            stunWait = 0f;
            stunMessage.text = "";
            swapMessage.text = "";
            // save current position
            originalPos = player.transform;

            // creates a list of all allies
            if (manager.GetComponent<GameManagement>().blueLeft > 0)
            {
                GameObject[] allies = GameObject.FindGameObjectsWithTag("Ally");
                GameObject newHost = allies[0];
                for (int i = 1; i < allies.Length; i++)
                {
                    // saves the first non-stunned ally
                    if (allies[i].GetComponent<BotMovement>().stop == false)
                    {
                        newHost = allies[i];
                        break;
                    }
                }

                // swap player and newly stunned teammate
                player.transform.position = newHost.transform.position;
                newHost.transform.position = originalPos.position;
                newHost.GetComponent<TargetDummy>().shot = true;

                // reset player to pre-stunned state
                player.GetComponent<testCube>().shot = false;
                player.GetComponent<testCube>().isLatched = true;
            }
        }
    }
}
