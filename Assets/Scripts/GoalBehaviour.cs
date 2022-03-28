using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalBehaviour : MonoBehaviour
{
    public Material FailureMaterial;

    /// <summary>
    /// The number of enemies that will cause the goal to change colors
    /// </summary>
    [SerializeField]
    private int _enemyCount = 0;
    /// <summary>
    /// The number of hits that this object can take before changing color
    /// </summary>
    [SerializeField]
    private float _health = 10;
    public int EnemyCount { get => _enemyCount; set => _enemyCount = value; }

    private void Update()
    {
        if (_enemyCount > _health)
        {
            GetComponent<MeshRenderer>().material = FailureMaterial;
        }
    }
}
