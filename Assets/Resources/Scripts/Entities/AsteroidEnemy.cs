using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidEnemy : Unit
{
    Vector2 moveDir;
    public bool bigAsteroid;
    public override void Initialize()
    {
        base.Initialize();
        moveDir = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
       
    }

    public override void PostInitialize()
    {

    }

    public override void Refresh()
    {
        
    }

    public override void PhysicsRefresh()
    {
        Move(moveDir);
        Rotate(Random.Range(-1,1));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Laser"))
        {
            if (bigAsteroid)
                EnemyManager.Instance.CreateSmallAsteroids(transform.position);
            EnemyManager.Instance.DestroyEnemy(gameObject);
            BulletManager.Instance.LaserDied(collision.gameObject.GetComponent<Laser>());
        }
    }
}
