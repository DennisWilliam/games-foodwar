using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DNSCoreMechanics.Behaviors.Entities;
using DNSCoreMechanics.Utils;

public class Player: EntityBehavior2D<EntityTopDown2D, WeaponBase> //: EntityBehavior2D
{
    // Start is called before the first frame update
    void Start()
    {
        WBInstance = new Pistol(true, 0.3f, 2,10, 5);
        EBInstance = new EntityTopDown2D();
        initTopDown2D(true, 10, GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>());
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = BehaviorsUtils.getCameraMousePosition();
        WBInstance.Shooting(cam, mousePosition, transform, ExecuteMouseClickAction);
        //  ExecuteDash();
    }

    private void FixedUpdate()
    {
        EBInstance.MoveWithRigidBody(rb,movementSpeed);
    }

    private void ExecuteMouseClickAction()
    {
        GameObject bulletInstance;
        bulletInstance = Instantiate(
                bullet,
                bulletTransform.position,
                Quaternion.identity
                );
        Destroy(bulletInstance, 5);
    }
}
