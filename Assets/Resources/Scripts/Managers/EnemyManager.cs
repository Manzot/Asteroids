using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyManager
{
    public List<AsteroidEnemy> asteroidsList;
    public List<AlienShipEnemy> alienShipList;

    GameObject asteroidPrefab;
    GameObject smallAsteroidPrefab;
    GameObject alienShipPrefab;

    Transform alienShipParent;
    Transform asteroidParent;
    #region SINGLETON
    public static EnemyManager Instance
    {

        get
        {
            return instance ?? (instance = new EnemyManager());
        }

    }
    private static EnemyManager instance;
    private EnemyManager() { }
    #endregion


    public void Initialize()
    {
        AstroidsSpawnner();
        AlienShipSpawnner();

        foreach (AsteroidEnemy ae in asteroidsList)
        {
            ae.Initialize();
        }
        foreach (AlienShipEnemy ase in alienShipList)
        {
            ase.Initialize();
        }
    }
    public void PostInitialize()
    {
        foreach (AsteroidEnemy ae in asteroidsList)
        {
            ae.PostInitialize();
        }
        foreach (AlienShipEnemy ase in alienShipList)
        {
            ase.PostInitialize();
        }
    }

    public void Refresh()
    {
        foreach (AsteroidEnemy ae in asteroidsList)
        {
            ae.Refresh();
        }
        foreach (AlienShipEnemy ase in alienShipList)
        {
            ase.Refresh();
        }
    }

    public void PhysicsRefresh()
    {
        foreach (AsteroidEnemy ae in asteroidsList)
        {
            ae.PhysicsRefresh();
        }
        foreach (AlienShipEnemy ase in alienShipList)
        {
            ase.PhysicsRefresh();
        }
    }

    public void DestroyEnemy(GameObject go)
    {
        go.SetActive(false);
        alienShipList.Remove(go.GetComponent<AlienShipEnemy>());
        asteroidsList.Remove(go.GetComponent<AsteroidEnemy>());
    }
    public void AstroidsSpawnner()
    {
        asteroidPrefab = Resources.Load<GameObject>("Prefabs/Asteroid-Big");
        smallAsteroidPrefab = Resources.Load<GameObject>("Prefabs/Asteroid-Small");
        asteroidParent = new GameObject("AsteroidParent").transform;
        asteroidsList = new List<AsteroidEnemy>();
        GameObject.Instantiate(asteroidPrefab, asteroidParent);
        asteroidsList.AddRange(GameObject.FindObjectsOfType<AsteroidEnemy>());
    }
    public void AlienShipSpawnner()
    {
        alienShipPrefab = Resources.Load<GameObject>("Prefabs/AlienShip");
        alienShipList = new List<AlienShipEnemy>();
        alienShipParent = new GameObject("AlienShipParent").transform;
        GameObject.Instantiate(alienShipPrefab, alienShipParent);
        alienShipList.AddRange(GameObject.FindObjectsOfType<AlienShipEnemy>());
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

}
