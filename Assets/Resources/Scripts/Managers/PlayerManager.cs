using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager
{
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
