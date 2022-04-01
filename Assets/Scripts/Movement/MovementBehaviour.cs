 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehaviour : MonoBehaviour
{
    private Vector3 _velocity;

    /// <summary>
    /// The velocity currently being applied to this actor
    /// </summary>
    public Vector3 Velocity { get => _velocity; set => _velocity = value; }


    // Update is called once per frame
    public virtual void Update()
    {
        //Applies this game object's velocity to its position
        transform.position += _velocity * Time.deltaTime;
    }
}
