using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleToShoot : MonoBehaviour
{
    Animator animator;
    //bool Shoot;

    // Start is called before the first frame update
    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
        //Shoot = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool("Shoot", true);
        }
        else animator.SetBool("Shoot", false);
    }
}
