using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager
{
 
    public Player player { get; set; }
    private float spawnTime = 5f;
    InGameUI ui;
    #region SINGLETON
    public static PlayerManager Instance
    {

        get
        {
            return instance ?? (instance = new PlayerManager());
        }

    }
    private static PlayerManager instance;

    private PlayerManager() { }
    #endregion

    public void Initialize()
    {
        GameObject playerPrefab = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Player"));
        ui = GameObject.FindObjectOfType<InGameUI>();
        player = playerPrefab.GetComponent<Player>();
        player.Initialize();
    }

    public void PostInitialize()
    {
        player.PostInitialize();
    }

    public void Refresh()
    {
        if(player.isActiveAndEnabled)
            player.Refresh();

        IsPlayerDead();
    }

    public void PhysicsRefresh()
    {
        player.PhysicsRefresh();
    }

    public void PlayerDied(GameObject go)
    {
        ui._score = 0;
        go.SetActive(false);
        
    }
    public void PlayerSpawn(GameObject go)
    {
        go.SetActive(true);
    }

    public void IsPlayerDead()
    {
        if (!player.isActiveAndEnabled)
            spawnTime -= Time.deltaTime;
        if (spawnTime <= 0)
        {
            PlayerSpawn(player.gameObject);
            player.transform.position = new Vector2(0, 0);
            player.transform.rotation = Quaternion.Euler(Vector3.zero);
            spawnTime = 5f;
        }
    }

}
