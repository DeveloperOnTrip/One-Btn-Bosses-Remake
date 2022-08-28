using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BossHealth : MonoBehaviour
{
    public Image _healthBarImage;

    [SerializeField] float _health;
    float _maxHealth = 100f;
    float _lerpSpeed;
    bool _dead;

    void Awake()
    {
        _health = _maxHealth;
    }

    void Update()
    {
        if (_health > _maxHealth)
            _health = _maxHealth;

        _lerpSpeed = 1f * Time.deltaTime;

        _healthBarImage.fillAmount = Mathf.Lerp(_healthBarImage.fillAmount, (_health / _maxHealth), _lerpSpeed);
        ChangeColor();
    }

    void ChangeColor()
    {
        Color healthColor = Color.Lerp(Color.red, Color.green, (_health / _maxHealth));
        _healthBarImage.color = healthColor;
    }

    public void TakeDamage(float _damage)
    {
        _health = Mathf.Clamp(_health - _damage, 0, _maxHealth);

        if (_health > 0)
        {

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
