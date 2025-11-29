using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage = 50;
    [SerializeField] private float _lifeSpan = 5f;
    [SerializeField] private AudioClip ImpactSound;

    public float _speed = 10f;

    private Mover2D _mover;

    private AudioSource AudioImpact;

    private void Awake()
    {
        _mover = GetComponent<Mover2D>();

        AudioImpact = GetComponent<AudioSource>();

        if (AudioImpact == null)
        {
            AudioImpact = gameObject.AddComponent<AudioSource>();
        }
    }

    private void Start()
    {
        Destroy(gameObject, _lifeSpan);
    }

    public void Shoot(Vector2 dir)
    {
        _mover.SetSpeed(_speed);
        _mover.SetAndNormalizeInput(dir);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.CompareTag(Tags.Enemy))
            {
                if (ImpactSound != null && AudioImpact != null)
                {
                    AudioImpact.clip = ImpactSound;
                    AudioImpact.Play();
                }

                //collision.gameObject.GetComponent<Enemy>().DestroyMe();
                collision.gameObject.GetComponent<LifeController>().TakeDamage(_damage);
                Destroy(gameObject);
            }
        }
    }

}
