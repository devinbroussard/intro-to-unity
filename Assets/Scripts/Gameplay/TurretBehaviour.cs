using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBehaviour : MonoBehaviour
{
    /// <summary>
    /// A reference to the turret's bullet emitter component
    /// </summary>
    [SerializeField]
    private BulletEmitterBehaviour _gun;

    /// <summary>
    /// The cooldown between firing
    /// </summary>
    [SerializeField]
    private float _firingCooldown;

    /// <summary>
    /// How long its been seen a bullet was fired
    /// </summary>
    [SerializeField]
    private float _firingTimer;

    /// <summary>
    /// How much ammo this turret has
    /// </summary>
    [SerializeField]
    private int _ammo = 0;

    /// <summary>
    /// Whether or not this turret has infinite ammo
    /// </summary>
    [SerializeField]
    private bool _infiniteAmmo = true;

    /// <summary>
    /// Whether or not this turret has ammo
    /// </summary>
    public bool HasAmmo { get => (_ammo > 0 || _infiniteAmmo); }

    /// <summary>
    /// Shoots a bullet when the firing timer reaches the cooldown
    /// </summary>
    private void Update()
    {
        //If this turret has no ammo, 
        if (!HasAmmo) return;

        //Increases the timer
        _firingTimer += Time.deltaTime;

        //If the timer reaches the cooldown...
        if (_firingTimer >= _firingCooldown)
        {
            //...Fire a bullet and reset the cooldown
            _gun.Fire();
            _firingTimer = 0;

            //If this turret doesn't have infinite ammo, decrement the ammo count
            if (!_infiniteAmmo) _ammo--;
        }
    }
}
