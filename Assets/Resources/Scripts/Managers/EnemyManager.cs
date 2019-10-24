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
    Collider2D world;
    int randNumEnemies;
    Vector2 randomPos;
    InGameUI ui;
  
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
        ui = GameObject.FindObjectOfType<InGameUI>();

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

    private void AstroidsSpawnner()
    {
        
        asteroidPrefab = Resources.Load<GameObject>("Prefabs/Asteroid-Big");
        smallAsteroidPrefab = Resources.Load<GameObject>("Prefabs/Asteroid-Small");
        world = GameObject.FindObjectOfType<MapPositionChanger>().GetComponent<Collider2D>();

        asteroidParent = new GameObject("AsteroidParent").transform;
        asteroidsList = new List<AsteroidEnemy>();

        RandomEnemySpawner(3, 6);
    }
    public void AlienShipSpawnner()
    {
        alienShipPrefab = Resources.Load<GameObject>("Prefabs/AlienShip");
        alienShipList = new List<AlienShipEnemy>();
        alienShipParent = new GameObject("AlienShipParent").transform;
        alienShipParent.position = new Vector2(Random.Range(-9, 9), Random.Range(-5.30f, 5.30f));
        GameObject.Instantiate(alienShipPrefab, alienShipParent);
        alienShipList.AddRange(GameObject.FindObjectsOfType<AlienShipEnemy>());
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
        if (asteroidsList.Count < 1)
        {
            RandomEnemySpawner(3, 6);
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

   public void CreateBigAsteroid(Vector2 _pos)
   {
        AsteroidEnemy ae = GameObject.Instantiate(asteroidPrefab, _pos, Quaternion.identity, asteroidParent).GetComponent<AsteroidEnemy>();
        ae.Initialize();
        asteroidsList.Add(ae);
    }

    public void CreateSmallAsteroids(Vector2 location)
    {
        int numOfAsteroids = Random.Range(2, 4);
        for (int i = 0; i < numOfAsteroids; i++)
        {
            GameObject go = GameObject.Instantiate(smallAsteroidPrefab, location + new Vector2(Random.Range(-0.8f, 0.8f), Random.Range(-0.8f, 0.8f)), Quaternion.identity, asteroidParent);
            asteroidsList.Add(go.GetComponent<AsteroidEnemy>());
            go.GetComponent<AsteroidEnemy>().Initialize();
            go.GetComponent<AsteroidEnemy>().PostInitialize();
        }
    }


    public void DestroyEnemy(GameObject go)
    {
        //go.SetActive(false);
        ui._score += 10;
        asteroidsList.Remove(go.GetComponent<AsteroidEnemy>());
        alienShipList.Remove(go.GetComponent<AlienShipEnemy>());

        GameObject.Destroy(go);     

    }

    public void RandomEnemySpawner(int min, int max)
    {
        randNumEnemies = Random.Range(min, max);

        for (int i = 0; i < randNumEnemies; i++)
        {
            randomPos = new Vector2(Random.Range(world.bounds.min.x, world.bounds.max.x), Random.Range(world.bounds.min.y, world.bounds.max.y));
            float distance = Vector2.Distance(PlayerManager.Instance.player.transform.position, randomPos);
            if (distance > 2f)
                CreateBigAsteroid(randomPos);            
        }
    }
    

}

