using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    public enum BEHAVIOUR_ON_DEFEAT { DISABLE = 0, DESTROY = 1, CUSTOM = 2 };

    [SerializeField] private int _currentHP = 10;
    [SerializeField] private int _maxHP = 10;
    [SerializeField] private BEHAVIOUR_ON_DEFEAT _behaviouronDefeat = BEHAVIOUR_ON_DEFEAT.DISABLE;

    public void SetHp(int hp)
    {
        hp = Mathf.Clamp(hp, 0, _maxHP);

        if (hp != _currentHP)
        {
            _currentHP = hp;

            if (_currentHP ==0)
            {
                Defeated();
            }
        }
    }

    public void AddHp(int amount) => SetHp(_currentHP + amount);

    public int GetHp() => _currentHP;

    public int GetMaxHp() => _maxHP;

    private void Defeated()
    {
        switch (_behaviouronDefeat)
        {
            case BEHAVIOUR_ON_DEFEAT.DISABLE:
                gameObject.SetActive(false);
                break;
            case BEHAVIOUR_ON_DEFEAT.DESTROY:
                Destroy(gameObject);
                break;
            case BEHAVIOUR_ON_DEFEAT.CUSTOM:
                Debug.LogWarning("il caso CUSTOM non è ancora implementato");
                break;
        }
    }    
}
