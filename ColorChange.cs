using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    public bool shot = false;
    GameObject target;
    Rigidbody rigBody;
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

    // makes target gray if its hit
    void checkHit()
    {
        if (shot == true)
        {
            rend.material.SetColor("_Color", Color.gray);
        }

    }
}
