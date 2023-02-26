using System;
using DG.Tweening;
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
        [SerializeField] private Ease IngressEase;
        [SerializeField] private Vector2 StartPos;
        
        private bool _horizontalConstraint;
        private bool _verticalConstraint;
        private bool _ingressCompleted;

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
    }
}