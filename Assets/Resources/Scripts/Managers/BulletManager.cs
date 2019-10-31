using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager
{
    public List<Laser> lasersList;
    GameObject laserPrefab;
    Transform laserParent;
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
        laserPrefab = Resources.Load<GameObject>("Prefabs/Laser");
        laserParent = new GameObject("LaserParent").transform;
        lasersList = new List<Laser>();


        foreach (Laser l in lasersList)
        {
            l.Initialize();
        }
    }

    public void PostInitialize()
    {
        foreach (Laser l in lasersList)
        {
            l.PostInitialize();
        }
    }

    public void Refresh()
    {
        foreach (Laser l in lasersList)
        {
            if (l.isActiveAndEnabled)
                l.Refresh();
        }
    }

    public void PhysicsRefresh()
    {
        foreach (Laser l in lasersList)
        {

            l.PhysicsRefresh();
        }
    }

    public Laser CreateBullet(Transform t, Color c)
    {
        
        Laser laser = null;
        if (lasersList.Count == 0)
        {
            laser = GameObject.Instantiate(laserPrefab, t.position, t.rotation,  laserParent).GetComponent<Laser>(); 
            lasersList.Add(laser);
            laser.GetComponent<SpriteRenderer>().color = c;
            laser.Initialize();
            laser.PostInitialize();
            lasersList.Add(laser);
            return laser;
        }
        else
        {
            foreach (Laser l in lasersList)
            {
                if (l.gameObject.activeSelf)
                {
                    laser = GameObject.Instantiate(laserPrefab, t.position, t.rotation, laserParent).GetComponent<Laser>();
                    lasersList.Add(laser);
                    laser.GetComponent<SpriteRenderer>().color = c;
                    laser.Initialize();
                    laser.PostInitialize();
                    lasersList.Add(laser);
                    return laser;
                }
                else
                {
                    int inactiveLaser = 0;
                    for (int j = 0; j < lasersList.Count; j++)
                    {
                        if (!lasersList[j].gameObject.activeSelf)
                            inactiveLaser = j;
                    }
                    lasersList[inactiveLaser].gameObject.SetActive(true);
                    
                    laser = lasersList[inactiveLaser].gameObject.GetComponent<Laser>();
                    laser.GetComponent<SpriteRenderer>().color = c;
                    laser.transform.position = t.position;
                    laser.transform.rotation = t.rotation;
                    laser.Initialize();
                    laser.PostInitialize();
                    return laser;
                }
            }
        }
        return laser;

    }
    public void LaserDied(Laser l)
    {
        l.gameObject.SetActive(false);
        //lasersList.Remove(l);
    }

  


}
