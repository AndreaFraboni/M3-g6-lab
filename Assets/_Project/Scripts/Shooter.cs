using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] protected Bullet _bulletPrefab;
    [SerializeField] protected float _fireInterval = 0.5f;

    protected float _lastShootTime;

    public virtual bool CanShootNow()
    {
        return Time.time - _lastShootTime > _fireInterval;
    }

    public virtual void Shoot()
    {
        _lastShootTime = Time.time;

        Bullet clonedBullet = Instantiate(_bulletPrefab);
        clonedBullet.transform.position = transform.position + new Vector3(1.5f, 0, 0);
        clonedBullet.Shoot(new Vector2(1, 0));
    }


    public virtual void TryToShoot(Vector2 direction)
    {
        if (CanShootNow())
        {
            Shoot();
        }
    }    

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (CanShootNow())
            {
                Shoot();
            }
        }
    }


}
