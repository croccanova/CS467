using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDummy : MonoBehaviour
{
    public bool shot = false;
    GameObject target;
    Renderer rend;


    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        checkHit();
        
    }

    void checkHit()
    {
        if (shot == true)
        {
            rend.material.SetColor("_Color", Color.gray);
        }
        
    }


}
