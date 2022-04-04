using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBehaviour : MonoBehaviour
{
    [SerializeField]
    private float _health;
    private bool _isAlive;
    [SerializeField]
    private bool _destroyOnDeath;

    public float Health { get => _health; }
    public bool IsAlive { get => _isAlive; }

    public virtual void OnDeath()
    {

    }

    public virtual float TakeDamage(float damageAmount)
    {
        _health -= damageAmount;

        return damageAmount;
    }

    void Start() { 
    }

    //Called once per frame
    void Update()
    {
        if (_health <= 0 && IsAlive)
            OnDeath();

        _isAlive = _health > 0;

        if (!IsAlive && _destroyOnDeath)
            Destroy(gameObject);
    }
}
