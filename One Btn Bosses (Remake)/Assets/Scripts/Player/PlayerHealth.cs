using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerHealth : MonoBehaviour
{
    public Image _healthBarImage;

    float _health;
    float _maxHealth = 3f;
    bool _dead;

    void Awake()
    {
        _health = _maxHealth;
    }

    void Update()
    {
        if (_health > _maxHealth)
            _health = _maxHealth;
    }

    public void TakeDamage(float _damage)
    {
        _health = Mathf.Clamp(_health - _damage, 0, _maxHealth);

        if (_health > 0)
        {
            transform.DOShakePosition(0.8f, 0.5f, 20, 90f);
        }
        else
        {
            if (!_dead)
            {
                _dead = true;
                Debug.Log("Dead");
            }
        }
    }

    public void AddHealth(float _value)
    {
        _health = Mathf.Clamp(_health + _value, 0, _maxHealth);
    }
}
