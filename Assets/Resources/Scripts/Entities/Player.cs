using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Unit
{
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
        scores = 0;
        lives = 3;
        scoresText.text = "Scores: " + scores;
        livesText.text = "Lives: " + lives;

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
    }

    public override void PhysicsRefresh()
    {
        //base.PhysicsRefresh();
        
    }
    public void AddPoints(int points)
    {
        scores += points;
        scoresText.text = "Scores: " + scores;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.relativeVelocity.magnitude > deathForce && collision.gameObject.CompareTag("Asteroid-Big"))
        {
            Debug.Log("death");
            lives--;
            livesText.text = "Lives: " + lives;
            if (lives <= 0)
            {
                Debug.Log("GAME OVER-FUCK OFF");
            }
        }

    }

}
