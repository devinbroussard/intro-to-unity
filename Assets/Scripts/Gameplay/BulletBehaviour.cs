using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    private string _ownerTag; //The bullet's owner
    [SerializeField]
    private float _damageAmount; //The damage this bullet does to objects
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
    }
}
