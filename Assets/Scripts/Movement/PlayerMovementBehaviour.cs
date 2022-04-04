using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementBehaviour : MonoBehaviour
{
    /// <summary>
    /// The speed of the player
    /// </summary>
    [SerializeField]
    private float _speed;
    /// <summary>
    /// The player's rigid body component
    /// </summary>
    private Rigidbody _rigidbody;
    /// <summary>
    /// The direction the player is moving in
    /// </summary>
    private Vector3 _moveDirection;
    /// <summary>
    /// The directoin the player is facing
    /// </summary>
    private Vector3 _rotationDirection;
    /// <summary>
    /// The game scene's main camera
    /// </summary>
    private Camera _camera;
    /// <summary>
    /// The sensitivity of the mouse 
    /// </summary>
    [SerializeField]
    private float _rotationSpeed;

    public Vector3 MoveDirection { get => _moveDirection; set => _moveDirection = value; }
    public Vector3 MouseOffsetDirection { get => _rotationDirection; set => _rotationDirection = value; }

    /// <summary>
    /// Initializes the rigid body
    /// </summary>
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _camera = GetComponentInChildren<Camera>();
    }

    private void FixedUpdate()
    {
        Vector3 velocity = MoveDirection * _speed * Time.deltaTime;
        _rigidbody.MovePosition(transform.position + velocity);

        Quaternion playerRotation = Quaternion.Euler(0, transform.rotation.eulerAngles.x + MouseOffsetDirection.x, 0);
        float cameraXRotation = Mathf.Clamp(transform.rotation.eulerAngles.x + MouseOffsetDirection.y * _rotationSpeed * Time.fixedDeltaTime, -89, 89);
        Quaternion cameraRotation = Quaternion.Euler(cameraXRotation, 0, 0);
        _rigidbody.MoveRotation(playerRotation);
        _camera.transform.Rotate(new Vector3(-cameraXRotation, 0, 0) * Time.deltaTime * _rotationSpeed);
    }
}
