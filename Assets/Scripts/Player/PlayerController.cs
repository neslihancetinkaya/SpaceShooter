using System;
using DG.Tweening;
using Lean.Pool;
using UnityEngine;
using Utils;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float ConstraintX;
        [SerializeField] private float ConstraintY;
        [SerializeField] private float Speed;
        [SerializeField] private float IngressDuration;
        [SerializeField] private float FireTime;
        [SerializeField] private float LaserSpacing;
        [SerializeField] private Ease IngressEase;
        [SerializeField] private Vector2 StartPos;
        [SerializeField] private GameObject Laser;
        
        private bool _horizontalConstraint;
        private bool _verticalConstraint;
        private bool _ingressCompleted;
        private float _tick;

        private void Awake()
        {
            transform.position = StartPos;
        }

        private void Start()
        {
            transform.DOMoveY(0, IngressDuration).SetEase(IngressEase)
                .OnComplete(() => _ingressCompleted = true);
        }

        private void Update()
        {
            if(!_ingressCompleted)
                return;
            Move();
            Fire();
        }

        private void Move()
        {
            var position = transform.position;
            _horizontalConstraint = position.x < ConstraintX && position.x > -ConstraintX;
            _verticalConstraint = position.y < ConstraintY && position.y > -ConstraintY;

            if (_horizontalConstraint)
            {
                if (Input.GetKey(KeyCode.RightArrow))
                    transform.position = new Vector2(position.x + Speed * Time.deltaTime, position.y);

                if (Input.GetKey(KeyCode.LeftArrow))
                    transform.position = new Vector2(position.x - Speed * Time.deltaTime, position.y);
                
            }

            if (_verticalConstraint)
            {
                if(Input.GetKey(KeyCode.UpArrow))
                    transform.position = new Vector2(position.x, position.y + Speed * Time.deltaTime);
                
                if(Input.GetKey(KeyCode.DownArrow))
                    transform.position = new Vector2(position.x, position.y - Speed * Time.deltaTime);
                
            }
        }

        private void Fire()
        {
            if (Input.GetKey(KeyCode.Space) && _tick < Time.time)
            {
                _tick = Time.time + FireTime;
                GameObject laser = LeanPool.Spawn(Laser);
                laser.transform.position = new Vector2(transform.position.x, transform.position.y + LaserSpacing);
            }
        }
    }
}