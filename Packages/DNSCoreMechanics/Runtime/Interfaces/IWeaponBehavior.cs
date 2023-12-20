using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static WeaponBase;

public interface IWeaponBehavior
{
    abstract void AIShooting(GameObject target, Transform entityTransform, CreateBulletDelegate delegate_createBullet);
    abstract void Shooting(Camera cam, Vector3 mousePos, Transform entityTransform, CreateBulletDelegate delegate_createBullet);
    abstract void Reload();
    abstract void ChangeAmmo();
    abstract void MeleeAttack();
    abstract void BulletsVelocity();
    abstract void Special();
    abstract void CreateBullet();
}
