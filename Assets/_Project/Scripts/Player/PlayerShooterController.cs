using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooterController : MonoBehaviour
{
    [SerializeField] float fireRate = 0.5f;
    [SerializeField] float fireRange = 6.0f;

    public GameObject BulletPrefab;

    private float _lastShootTime;

    private void Update()
    {
        if (Time.time - _lastShootTime > fireRate)
        {
            _lastShootTime = Time.time;
            Shoot();
        }
    }

    private GameObject FindNearestEnemy()
    {
        GameObject NearstEnemyFounded = null;
        GameObject[] enemiesList = GameObject.FindGameObjectsWithTag(Tags.Enemy);

        float nearstDistance = fireRange;

        foreach (GameObject enemy in enemiesList)
        {
            float CurDistance = Vector2.Distance(transform.position, enemy.transform.position);
            if (CurDistance < nearstDistance)
            {
                nearstDistance = CurDistance;
                NearstEnemyFounded = enemy;
            }
        }
        return NearstEnemyFounded;
    }

    public void Shoot()
    {
        GameObject Target = FindNearestEnemy();

        if (Target == null) return;

        GameObject cloneBullet;
        Vector2 spawnPosition = transform.position;

        cloneBullet = Instantiate(BulletPrefab, spawnPosition, Quaternion.identity);

        if (cloneBullet != null)
        {
            Vector2 targetPos = Target.GetComponent<Rigidbody2D>().position;
            Vector2 playerPos = transform.position;

            Vector2 direction = (targetPos - playerPos);

            cloneBullet.gameObject.GetComponent<Bullet>().Shoot(direction);
        }
        else
        {
            Debug.Log("Non hai assegnato il Prefab del Bullet !!!");
            return;
        }
    }

}
