using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyManager
{
    public List<AsteroidEnemy> asteroidsList;
    GameObject asteroidPrefab;
    Transform asteroidParent;
    #region SINGLETON
    public static EnemyManager Instance
    {

        get {
            return instance ?? (instance = new EnemyManager());
        }

    }
    private static EnemyManager instance;
    private EnemyManager() { }
    #endregion


    public void Initialize()
    {
        asteroidPrefab = Resources.Load<GameObject>("Prefabs/Asteroid-Big");
        asteroidParent = new GameObject("AsteroidParent").transform;
        asteroidsList = new List<AsteroidEnemy>();
        GameObject.Instantiate(asteroidPrefab, asteroidParent);
        asteroidsList.AddRange(GameObject.FindObjectsOfType<AsteroidEnemy>());

        foreach (AsteroidEnemy ae in asteroidsList)
        {
            ae.Initialize();
        }
    }

    public void PostInitialize()
    {
        foreach (AsteroidEnemy ae in asteroidsList)
        {
            ae.PostInitialize();
        }
    }

    public void Refresh()
    {
        foreach (AsteroidEnemy ae in asteroidsList)
        {
            ae.Refresh();
        }
    }

    public void PhysicsRefresh()
    {
        foreach (AsteroidEnemy ae in asteroidsList)
        {
            ae.PhysicsRefresh();
        }
    }
   
}
