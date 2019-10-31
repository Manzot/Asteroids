using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Unit
{
    public float spawnTime = 5f;
    public int lives = 3;
    [HideInInspector] public float deathForce = 1;
    public int scores=0;
    public Text scoresText;
    public Text livesText;
    public override void Initialize()
    {
        base.Initialize();
        
    }

    public override void PostInitialize()
    {
       // scores = 0;
       // lives = 3;
       // scoresText.text = "Scores: " + scores;
       //livesText.text = "Lives: " + lives;

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
            BulletManager.Instance.CreateBullet(transform, Color.white).gameObject.layer = LayerMask.NameToLayer("Laser");

        
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
