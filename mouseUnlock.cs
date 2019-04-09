using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseUnlock : MonoBehaviour
{
    // Update is called once per frame
    void Start()
    {
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        if (!Cursor.visible)
        {
            Cursor.visible = true;
        }
    }
}
