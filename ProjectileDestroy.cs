using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDestroy : MonoBehaviour
{
    public float m_MaxLifeTime = 3f;
    public GameObject originator;
    //private bool collisionHasOccurred = false;
    private GameObject objectCollidedWith;

    private void Start()
    {
        Destroy(gameObject, m_MaxLifeTime);
    }

    public void SetOriginator(GameObject origin)
    {
        originator = origin;
    }

    /*private void FixedUpdate()
    {
        if (collisionHasOccurred && objectCollidedWith != originator)
        {
            print("Projectile destroyed on collision with " + objectCollidedWith.ToString());
            Destroy(gameObject);
        }
        else if (collisionHasOccurred)
        {
            collisionHasOccurred = false;
        }
    }*/

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.gameObject.tag == "edge" || other.collider.gameObject == originator)
        {
            return;
        }

        print("Projectile destroyed on collision with " + other.collider.gameObject.ToString());
        Destroy(gameObject);

        //objectCollidedWith = other.collider.gameObject;
        //collisionHasOccurred = true;
    }
}