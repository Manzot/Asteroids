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
        EnemyManager.Instance.Initialize();
        PlayerManager.Instance.Initialize();
        BulletManager.Instance.Initialize();
    }

    public void PostInitialize()
    {

        EnemyManager.Instance.PostInitialize();
        PlayerManager.Instance.PostInitialize();
        BulletManager.Instance.PostInitialize();
    }

    public void Refresh()
    {

        EnemyManager.Instance.Refresh();
        PlayerManager.Instance.Refresh();
        BulletManager.Instance.Refresh();
    }

    public void PhysicsRefresh()
    {
        EnemyManager.Instance.PhysicsRefresh();
        PlayerManager.Instance.PhysicsRefresh();
        BulletManager.Instance.PhysicsRefresh();
    }
}
