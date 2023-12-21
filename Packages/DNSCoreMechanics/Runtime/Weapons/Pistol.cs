
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : WeaponBase
{
    WaitSomeTime reloadTime;
    WaitSomeTime shootTime;
    enum AMMO : int
    {
        DECREMENT = 0,
        INCREMENT = 1,
        RELOAD = 2
    }

    public Pistol(bool canShoot, float timeBetweenFiring, int ammoQtd, int gunMagazine, float timeBetweenReload)
    {
        this.canShoot = canShoot;
        this.timeBetweenFiring = timeBetweenFiring;
        this.ammoQtd = ammoQtd;
        this.gunMagazine = gunMagazine;
        shootTime = new WaitSomeTime(timer, timeBetweenFiring, true);
        reloadTime = new WaitSomeTime(0, 10, true);
    }

    public override void AIShooting(GameObject target, Transform entityTransform , CreateBulletDelegate delegate_createBullet)
    {
        Vector3 rotation = target.transform.position - entityTransform.position;
        float rotationZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        entityTransform.rotation = Quaternion.Euler(0, 0, rotationZ);

        if (!shootTime.releaseAction)
        {
            shootTime.Wait();
        }
        if(shootTime.releaseAction && reloadTime.releaseAction)
        {
            shootTime.RedefineTime(timeBetweenFiring, false);
            delegate_createBullet();
            ammoQtd = ammoQtd - 1;
        }
        Reload();
    }

    public override void BulletsVelocity()
    {
        throw new System.NotImplementedException();
    }

    public override void ChangeAmmo()
    {
        throw new System.NotImplementedException();
    }

    public override void CreateBullet()
    {
        Debug.Log("Create Bullet");
        throw new System.NotImplementedException();
    }

    public override void MeleeAttack()
    {
        throw new System.NotImplementedException();
    }

    public override void Reload()
    {
        reloadTime.Wait();
        if (ammoQtd == 0)
        {
            ammoQtd += gunMagazine;
            reloadTime.RedefineTime(10, false);
        }
    }

    public override void Shooting(Camera cam, Vector3 mousePos, Transform entityTransform, CreateBulletDelegate delegate_createBullet)
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - entityTransform.position;
        float rotationZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        //entityTransform.rotation = Quaternion.Euler(0, 0, rotationZ);

        if (!shootTime.releaseAction)
        {
            shootTime.Wait();
        }
        if (Input.GetMouseButton(0) && shootTime.releaseAction && reloadTime.releaseAction)
        {
            shootTime.RedefineTime(timeBetweenFiring, false);
            delegate_createBullet();
            ammoQtd = ammoQtd -1;
            
        }
        Reload();
    }

    public override void Special()
    {
        throw new System.NotImplementedException();
    }
}
