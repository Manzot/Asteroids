using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public float rotateSpeed;

    public virtual void Initialize()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public virtual void PostInitialize()
    {

    }

    public virtual void Refresh()
    {
       
    }

    public virtual void PhysicsRefresh()
    {
        
    }


    public void Move (Vector2 dir)
    {
        // rb.velocity = dir.normalized * speed * Time.deltaTime;
        try
        {
            rb.AddForce(dir.normalized * speed * Time.deltaTime);
        }
        catch
        {
            Debug.Log(transform.name);
        }
    }
    public void Rotate(float rDirection)
    {
        transform.Rotate(0, 0, rDirection * rotateSpeed * Time.deltaTime);
    }
}
