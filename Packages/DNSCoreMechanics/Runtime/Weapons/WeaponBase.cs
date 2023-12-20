using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : IWeaponBehavior
{
    public float timer;
    public float timeBetweenFiring;
    //public bool isAI;
    public bool canShoot;
    public int ammoQtd;
    public int gunMagazine;
    public float timeBetweenReload;
    public int dammage;

    public delegate void CreateBulletDelegate();

    public abstract void AIShooting(GameObject target, Transform entityTransform, CreateBulletDelegate delegate_createBullet);

    public abstract void BulletsVelocity();

    public abstract void ChangeAmmo();

    public abstract void CreateBullet();

    public abstract void MeleeAttack();

    public abstract void Reload();

    public abstract void Shooting(Camera cam, Vector3 mousePos, Transform entityTransform, CreateBulletDelegate delegate_createBullet);

    public abstract void Special();
}
