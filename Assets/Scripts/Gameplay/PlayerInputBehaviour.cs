using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputBehaviour : MonoBehaviour
{
    /// <summary>
    /// The direction the player is moving
    /// </summary>
    private PlayerMovementBehaviour _playerMovement;

    /// <summary>
    /// Gets the player's movement behaviour
    /// </summary>
    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovementBehaviour>();
    }

    /// <summary>
    /// Updates the player's position and rotation
    /// </summary>
    private void Update()
    {
        _playerMovement.MoveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        _playerMovement.MouseOffsetDirection = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")).normalized;
    }
}
