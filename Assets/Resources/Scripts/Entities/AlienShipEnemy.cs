using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienShipEnemy : Unit
{
    Vector2 moveDir;
    Transform player;

    float lastShot = 0;
    float shotDelay = 2f;
    Vector2 dir;
    GameObject go;
    float bulletSpeed = 200;
    public override void Initialize()
    {
        base.Initialize();
        moveDir = new Vector2(Random.Range(-10, 10), 0);

    }

    public override void PostInitialize()
    {
        player = GameObject.FindWithTag("Player").transform;

    }

    public override void Refresh()
    {
        Quaternion q = FindTarget();

        if (Time.time > lastShot + shotDelay)
        {

            go = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/AlienLaser"), transform.position, q);
            go.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0f, bulletSpeed));
            lastShot = Time.time;

            Destroy(go, 3f);

        }

    }

    private Quaternion FindTarget()
    {
        dir = (player.position - transform.position).normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = q;
        return q;
    }

    public override void PhysicsRefresh()
    {

        Move(moveDir);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Laser"))
        {
            EnemyManager.Instance.DestroyEnemy(gameObject);
            BulletManager.Instance.LaserDied(collision.gameObject.GetComponent<Laser>());
        }
    }


}
