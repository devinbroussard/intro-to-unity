using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    /// <summary>
    /// The tag of the bullet's owner
    /// </summary>
    private string _ownerTag;
    [SerializeField]
    private float _damageAmount; //The damage this bullet does to objects

    /// <summary>
    /// The life time of the bullet
    /// </summary>
    [SerializeField]
    private float _lifeTime;
    private float _currentLifeTime;

    /// <summary>
    /// Whether or not this bullet should be destroyed on collision
    /// </summary>
    [SerializeField]
    private bool _destroyOnHit;

    private Rigidbody _rigidbody; //The bullet's rigid body component

    public string OwnerTag { get => _ownerTag; set => _ownerTag = value; }
    public Rigidbody Rigidbody { get => _rigidbody; set => _rigidbody = value; }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(OwnerTag))
            return;

        HealthBehaviour otherHealth = other.GetComponent<HealthBehaviour>();

        if (!otherHealth)
            return;

        otherHealth.TakeDamage(_damageAmount);

        if (_destroyOnHit)
            Destroy(gameObject);
    }

    /// <summary>
    /// Destroys the bullet when 
    /// </summary>
    private void Update()
    {
        _currentLifeTime += Time.deltaTime;

        if (_currentLifeTime >= _lifeTime)
            Destroy(gameObject);
    }
}

