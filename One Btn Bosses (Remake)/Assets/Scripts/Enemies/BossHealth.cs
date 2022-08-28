using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BossHealth : MonoBehaviour
{
    public float _maxHealth = 200f;
    [SerializeField] float _health;

    public Image _healthBarImage;
    public Color _maxHealthColor;
    public Color _minHealthColor;

    float _lerpSpeed;//How speed the bar change 
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
        Color healthColor = Color.Lerp(_minHealthColor, _maxHealthColor, (_health / _maxHealth));
        _healthBarImage.color = healthColor;
    }

    public void TakeDamage(float _damage)
    {
        _health = Mathf.Clamp(_health - _damage, 0, _maxHealth);

        if (_health > 0)
        {
            // Take Damage Sound
        }
        else
        {
            if (!_dead)
            {
                _dead = true;
                gameObject.SetActive(false);
                Debug.Log("You Win");
            }
        }
    }

    public void AddHealth(float _value)
    {
        _health = Mathf.Clamp(_health + _value, 0, _maxHealth);
    }
}
