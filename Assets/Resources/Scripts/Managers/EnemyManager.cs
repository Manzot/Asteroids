using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyManager
{
    public List<AsteroidEnemy> asteroidsList;
    GameObject asteroidPrefab;
    GameObject smallAsteroidPrefab;
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
        smallAsteroidPrefab = Resources.Load<GameObject>("Prefabs/Asteroid-Small");
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

   public void CreateBigAsteroid()
   {

   }

    public void CreateSmallAsteroids(Vector2 location)
    {
        int numOfAsteroids = Random.Range(2, 4);
        for (int i = 0; i < numOfAsteroids; i++)
        {
            GameObject go = GameObject.Instantiate(smallAsteroidPrefab, location + new Vector2(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f)), Quaternion.identity, asteroidParent);
            asteroidsList.Add(go.GetComponent<AsteroidEnemy>());
            go.GetComponent<AsteroidEnemy>().Initialize();
            go.GetComponent<AsteroidEnemy>().PostInitialize();      
        }
    }

    public void CreateAlienShip()
    {

    }

    public void DestroyEnemy(GameObject go)
    {
        go.SetActive(false);
        asteroidsList.Remove(go.GetComponent<AsteroidEnemy>());
    }


   
}
