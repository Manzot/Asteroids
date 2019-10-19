using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager
{
    #region SINGLETON
    public static BulletManager Instance
    {

        get
        {
            return instance ?? (instance = new BulletManager());
        }

    }
    private static BulletManager instance;

    private BulletManager() { }
    #endregion

    public void Initialize()
    {

    }

    public void PostInitialize()
    {

    }

    public void Refresh()
    {

    }

    public void PhysicsRefresh()
    {

    }
}
