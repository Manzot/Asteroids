using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour, IManager
{
    Rigidbody2D rb;
    public float speed;

    public void Initialize()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void PhysicsRefresh()
    {
        
    }

    public void PostInitialize()
    {
        
    }

    public void Refresh()
    {
       
    }


    void Move (Vector2 dir)
    {

        rb.velocity = dir.normalized * speed;
    }
}
