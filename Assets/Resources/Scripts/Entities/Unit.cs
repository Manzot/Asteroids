using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public float rotateSpeed;
    public int points;

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
        //rb.AddForce(dir.normalized * speed * Time.fixedDeltaTime, ForceMode2D.Impulse);
        rb.AddForce(dir.normalized * speed );
    }
    public void Rotate(float rotateDir)
    {
        transform.Rotate(0, 0, rotateDir * rotateSpeed * Time.fixedDeltaTime);
    }
    public void LaserShoot(Vector3 shootDir)
    {
        transform.position += shootDir.normalized * speed * Time.deltaTime;
    }
}
