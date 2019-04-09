using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLock : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (Cursor.lockState == CursorLockMode.None)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        if (Cursor.visible)
        {
            Cursor.visible = false;
        }
    }
}
