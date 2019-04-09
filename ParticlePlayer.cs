using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePlayer : MonoBehaviour
{
    public GameObject stunEffect;
    public GameObject bot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<TargetDummy>().shot == true)
        {
            stunEffect.GetComponent<ParticleSystem>().Play();
        }
    }
}
