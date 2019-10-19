using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyManager
{
    #region SINGLETON
    public static EnemyManager Instance
    {

        get {
            return instance ?? (instance = new EnemyManager());
        }

    }
    private static EnemyManager instance;
    private EnemyManager(){}

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
    #endregion



}
