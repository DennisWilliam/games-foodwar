using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DNSCoreMechanics.Behaviors.Entities;

public class Player: EntityBehavior2D<EntityTopDown2D> //: EntityBehavior2D
{
    // Start is called before the first frame update
    void Start()
    {
        EBInstance = new EntityTopDown2D();
        movementSpeed = 10;
        canDash = true;
        //InitializeEntityBehaviorRequiredConfigs(10,5);
    }

    // Update is called once per frame
    void Update()
    {
       // Move(transform,anim, movementSpeed, lookAtDirection);
        //  ExecuteDash();
    }

    private void FixedUpdate()
    {
        EBInstance.MoveWithRigidBody(rb,movementSpeed);
        //Move();
    }
}
