using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidEnemy : Unit
{
    public override void Initialize()
    {
        base.Initialize();
    }

    public override void PostInitialize()
    {

    }

    public override void Refresh()
    {
        
    }

    public override void PhysicsRefresh()
    {
        Move(new Vector2(0.01f, 1f));
    }
}
