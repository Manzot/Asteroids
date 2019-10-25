using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : Unit
{
    public float laserLife;
    float counter;
    Vector2 startPos;
    public override void Initialize()
    {
        base.Initialize();
        transform.position = PlayerManager.Instance.player.transform.position;
        transform.rotation = PlayerManager.Instance.player.transform.rotation;
        startPos = PlayerManager.Instance.player.transform.up;
        counter = laserLife;
    }

    public override void PostInitialize()
    {
       
    }

    public override void Refresh()
    {
        LaserShoot(startPos);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up);
        Debug.DrawRay(transform.position, transform.up, Color.red, 5f);
        if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Debug.Log("hit");
        }
        counter -= Time.deltaTime;
        if(counter <= 0)
        {
            BulletManager.Instance.LaserDied(gameObject.GetComponent<Laser>());
            counter = laserLife;
        }
    }

    public override void PhysicsRefresh()
    {
        base.PhysicsRefresh();
        
    }
}
