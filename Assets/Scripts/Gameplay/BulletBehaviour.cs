using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    private string _ownerTag; //The bullet's owner
    [SerializeField]
    private float _damageAmount; //The damage this bullet does to objects

    public string OwnerTag { get => _ownerTag; set => _ownerTag = value; }

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
