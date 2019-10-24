using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlow
{
    // Start is called before the first frame update
    #region Singleton
    public static GameFlow Instance { get { return instance ?? (instance = new GameFlow()); } }

    private static GameFlow instance;

    private GameFlow() { }
    #endregion

    public void Initialize()
    {
        PlayerManager.Instance.Initialize();
        EnemyManager.Instance.Initialize(); 
        BulletManager.Instance.Initialize();
    }

    public void PostInitialize()
    {
        PlayerManager.Instance.PostInitialize();
        EnemyManager.Instance.PostInitialize();
        BulletManager.Instance.PostInitialize();
    }

    public void Refresh()
    {
        PlayerManager.Instance.Refresh();
        EnemyManager.Instance.Refresh();
        BulletManager.Instance.Refresh();
    }

    public void PhysicsRefresh()
    {
        PlayerManager.Instance.PhysicsRefresh();
        EnemyManager.Instance.PhysicsRefresh(); 
        BulletManager.Instance.PhysicsRefresh();
    }
}
