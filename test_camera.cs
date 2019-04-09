using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_camera : MonoBehaviour
{
    public float speedHor = 2.0f;
    public float speedVert = 2.0f;

    //horizontal movement
    private float yaw = 0.0f;

    //vertical movement
    private float pitch = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        if (PlayerPrefs.HasKey("v_sensitivity"))
        {
            speedVert = PlayerPrefs.GetFloat("v_sensitivity");
        }
        if (PlayerPrefs.HasKey("h_sensitivity"))
        {
            speedHor = PlayerPrefs.GetFloat("h_sensitivity");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // x axis input
        // check camera orientation - if upside down, invert x axis input
        if (transform.eulerAngles.z >= 90 || transform.eulerAngles.z <= -90)
        {
            yaw -= speedHor * Input.GetAxis("Mouse X");
        }
        else
        {
            yaw += speedHor * Input.GetAxis("Mouse X");
        }
        
        // y axis input
        pitch -= speedVert * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

        if (Input.GetKeyDown("escape"))
            Cursor.lockState = CursorLockMode.None;

    }
}
