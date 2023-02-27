using System;
using Lean.Pool;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Directors
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private GameObject Enemy;
        [SerializeField] private Vector2 SpawnRange;
        [SerializeField] private float SpawnTime;

        private float _tick;
        
        private void Update()
        {
            if (_tick < Time.time)
            {
                _tick = Time.time + SpawnTime;
                SpawnEnemy();
            }
        }

        private void SpawnEnemy()
        {
            GameObject enemy = LeanPool.Spawn(Enemy);
            enemy.transform.position = new Vector2(Random.Range(SpawnRange.x, SpawnRange.y), transform.position.y);
        }
    }
}