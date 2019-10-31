using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : Unit
{
    public float laserLife;
    float counter;
    Vector3 startPos;
    public bool isHit = false;
    public override void Initialize()
    {
        base.Initialize();
        startPos = transform.up;
        counter = laserLife;
    }

    public override void PostInitialize()
    {
       
    }

    public override void Refresh()
    {
        LaserShoot(startPos);
        CheckForHit();
        //RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up);
        //Debug.DrawRay(transform.position, transform.up, Color.red, 5f);
        //if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        //{
        //    Debug.Log("hit");
        //}
        counter -= Time.deltaTime;
        if(counter <= 0 || isHit)
        {
            BulletManager.Instance.LaserDied(gameObject.GetComponent<Laser>());
            counter = laserLife;
        }
    }

    public override void PhysicsRefresh()
    {
        base.PhysicsRefresh();
        
    }

    public void CheckForHit()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up);
        //Debug.DrawRay(transform.position, transform.up, Color.red, 5f);
        if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            isHit = true;
            if (hit.transform.CompareTag("Asteroid-Big"))
                EnemyManager.Instance.CreateSmallAsteroids(hit.transform.position);
            EnemyManager.Instance.DestroyEnemy(hit.transform.gameObject);
            
        }
        else
        {
            isHit = false;
        }
    }
}
