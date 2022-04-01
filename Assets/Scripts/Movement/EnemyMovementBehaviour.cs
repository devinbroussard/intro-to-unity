using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementBehaviour : MovementBehaviour
{
    [SerializeField]
    private Transform _target;
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _damageAmount; //The amount of damage this actor does to the target

    /// <summary>
    /// The game object the enemy will seek
    /// </summary>
    public Transform Target { get => _target; set => _target = value; }
    public float Speed { get => _speed; set => _speed = value; }

    // Update is called once per frame
    public override void Update()
    {
        //Calculates the direction between the enemy and the object it needs to seek
        Vector3 direction = Target.position - transform.position;
        Velocity = direction.normalized * Speed;

        base.Update();
    }

    private void OnTriggerEnter(Collider other)
    {
        //If the other collider matches the transform...
        if (other.transform == _target)
        {
            GoalBehaviour goal = other.GetComponent<GoalBehaviour>();
            //If the target has a GoalBehaviour script...
            if (goal)
            {
                goal.TakeDamage(_damageAmount);
            }
            //..Destroy this game object
            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
    }
}
