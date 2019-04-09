using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetCheck : MonoBehaviour
{
    public List<GameObject> targets = new List<GameObject>();
    public bool allStunned = false;
    public bool done = false;
    AudioSource successSound;
    AudioSource[] audioSources;

    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform child in transform)
        {
            targets.Add(child.gameObject);
        }
        audioSources = GetComponents<AudioSource>();
        successSound = audioSources[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (done == false)
        {
            int stunCount = 0;
            //print("enemyCount: " + targets.Count);
            for (int i = 0; i < targets.Count; i++)
            {
                if (targets[i].GetComponent<TargetDummy>().shot == true)
                {
                    stunCount += 1;
                }
            }
            //print("stunned count: " + stunCount);
            if (stunCount >= 11)
            {
                System.Threading.Thread.Sleep(10);
                successSound.Play();
                done = true;
            }
        }
    }
}
