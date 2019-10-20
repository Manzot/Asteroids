using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit
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
        if(Input.GetKey(KeyCode.W))
            Move(transform.up);
        if (Input.GetKey(KeyCode.A))
            Rotate(1);
        if (Input.GetKey(KeyCode.D))
            Rotate(-1);
    }

    public override void PhysicsRefresh()
    {
        //base.PhysicsRefresh();
        
    }

}
