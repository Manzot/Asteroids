using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit
{
    public float spawnTime = 5f;
    public override void Initialize()
    {
        base.Initialize();
    }

    public override void PostInitialize()
    {

    }

    public override void Refresh()
    {
        if(Input.GetKey(KeyCode.W))
            Move(transform.up);
        if (Input.GetKey(KeyCode.A))
            Rotate(1);
        if (Input.GetKey(KeyCode.D))
            Rotate(-1);
        if (Input.GetKeyDown(KeyCode.Space))
            BulletManager.Instance.CreateBullet(transform.position);

        
        if(spawnTime <= 0)
        {
            PlayerManager.Instance.PlayerSpawn(gameObject);
            spawnTime = 5f;
        }
    }

    public override void PhysicsRefresh()
    {
        //base.PhysicsRefresh();
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))// 13) //(13 for enemy)
        {
            PlayerManager.Instance.PlayerDied(gameObject);
        }
    }
}
