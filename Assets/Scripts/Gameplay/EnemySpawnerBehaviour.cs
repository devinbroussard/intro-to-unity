using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerBehaviour : MonoBehaviour {
    /// <summary>
    /// The game object that the enemy will seek
    /// </summary>
    [SerializeField]
    private Transform _enemyTarget;
    /// <summary>
    /// The enemy object that will spawn
    /// </summary>
    [SerializeField]
    private EnemyMovementBehaviour _enemy;

    /// <summary>
    /// The number of enemies that will spawn in a wave
    /// </summary>
    [SerializeField]
    private float _spawnTime = 5.0f;
    private float _timer = 0.0f;
    private void Update() {
        if (_timer > _spawnTime) {
            EnemyMovementBehaviour spawnedEnemy = Instantiate(_enemy, transform.position, transform.rotation);
            spawnedEnemy.Target = _enemyTarget;
            _timer = 0.0f;
        }
        _timer += Time.deltaTime;
    }
}
