using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEmitterBehaviour : MonoBehaviour
{
    /// <summary>
    /// The object's bullet behaviour component
    /// </summary>
    [SerializeField]
    private BulletBehaviour _bullet;
    /// <summary>
    /// The force that will be applied to the bullet
    /// </summary>
    [SerializeField]
    private float _bulletForce; 
    /// <summary>
    /// The owner of the bullet behaviour
    /// </summary>
    [SerializeField]
    private GameObject _owner; 

    /// <summary>
    /// Adds a new bullet to the scene
    /// </summary>
    public void Fire()
    {
        //Creates a new bullet and adds it to the scene
        GameObject bullet = Instantiate(_bullet.gameObject, transform.position, transform.rotation);
        BulletBehaviour bulletBehaviour = bullet.GetComponent<BulletBehaviour>();
        //Sets the bullet's tag to be the tag of its owner
        bulletBehaviour.OwnerTag = _owner.tag;
        //Adds the bullet force to the bullet
        bulletBehaviour.Rigidbody.AddForce(transform.forward * _bulletForce, ForceMode.Impulse);
    }
    
}
