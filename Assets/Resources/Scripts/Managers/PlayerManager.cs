using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager
{
    public Player player { get; set; }
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
        player = playerPrefab.GetComponent<Player>();
        player.Initialize();
    }

    public void PostInitialize()
    {
        player.PostInitialize();
    }

    public void Refresh()
    {
        player.Refresh();
    }

    public void PhysicsRefresh()
    {
        player.PhysicsRefresh();
    }
   


}
