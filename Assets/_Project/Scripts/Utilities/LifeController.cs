using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    [SerializeField] private int _currenthp = 100;
    [SerializeField] private int _maxHP = 100;
    [SerializeField] private int _lives = 3;
    [SerializeField] private AudioClip DeathSound;

    private AudioSource AudioDeath;

    private void Awake()
    {
        AudioDeath = GetComponent<AudioSource>();
        if (AudioDeath == null)
        {
            AudioDeath = gameObject.AddComponent<AudioSource>();
        }
    }

    // Getter
    public int GetHp() => _currenthp;
    public int GetMaxHp() => _maxHP;
    public int GetLives() => _lives;

    // Setter
    public int SetLives(int lives) => _lives = lives;
    public void SetHp(int hp)
    {
        hp = Mathf.Clamp(hp, 0, _maxHP);

        if (hp != _currenthp)
        {
            _currenthp = hp;

            if (_currenthp <= 0)
            {
                _lives--;

                if (_lives == 0)
                {
                    Defeated();
                }
                else
                {
                    _currenthp = 100;
                }
            }
        }
    }

    // Functions
    public void AddHp(int amount) => SetHp(_currenthp + amount);
    public void TakeDamage(int damage)
    {
        AddHp(-damage);
    }
    public void TakeHeal(int amount)
    {
        if (DeathSound != null && AudioDeath != null)
        {
            AudioDeath.PlayOneShot(DeathSound);
        }
        AddHp(amount);
    }

    private void Defeated()
    {
        Destroy(gameObject);
    }

}