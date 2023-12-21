using DNSCoreMechanics.Utils;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//using DNSCoreMechanics.AI;
public class CarrotEnemy : EntityAITopDown2D //: EnemyCoreAI
{
    // Start is called before the first frame update
    void Start()
    {
        createEntityHealthOnTop();
        WBInstance = new Pistol(true, 0.5f, 2, 10, 5);
        EBInstance = new EntityTopDown2D();
        movementSpeed = 5;
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        distanceBetween = 50;
    }

    // Update is called once per frame
    void Update()
    {
        Chase();
        Vector3 mousePosition = BehaviorsUtils.getCameraMousePosition();
        WBInstance.AIShooting(target,bulletTransform, ExecuteMouseClickAction);
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

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        hs.Damage(10);
    }
}
