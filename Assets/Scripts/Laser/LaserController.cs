using System;
using Lean.Pool;
using UnityEngine;

namespace Laser
{
    public class LaserController : MonoBehaviour
    {
        [SerializeField] private float Speed;
        [SerializeField] private float DestroyPoint;

        private void Update()
        {
            transform.position += Vector3.up * (Speed * Time.deltaTime);

            if (transform.position.y > DestroyPoint)
            {
                LeanPool.Despawn(gameObject);
            }
        }
    }
}