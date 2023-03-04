using System;
using DG.Tweening;
using Lean.Pool;
using UnityEngine;
using UnityEngine.InputSystem;
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
        
        private PlayerControls PlayerMovement;
        private PlayerControls PlayerFire;
        private InputAction _move;
        private InputAction _fire;

        private bool _ingressCompleted;
        private float _tick;
        private Vector2 _moveDirection = Vector2.zero;

        private void Awake()
        {
            transform.position = StartPos;
            PlayerMovement = new PlayerControls();
        }
        
        private void OnEnable()
        {
            _move = PlayerMovement.Player.Move;
            _move.Enable();

            _fire = PlayerMovement.Player.Fire;
            _fire.Enable();
            _fire.performed += Fire;
        }

        private void OnDisable()
        {
            _move.Disable();
            _fire.Disable();
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
            _moveDirection = _move.ReadValue<Vector2>().normalized;
            Vector2 position = transform.position;
            position += _moveDirection * (Speed * Time.deltaTime);
            position.x = Mathf.Clamp(position.x, -ConstraintX, ConstraintX);
            position.y = Mathf.Clamp(position.y, -ConstraintY, ConstraintY);
            transform.position = position;
        }

        private void Fire(InputAction.CallbackContext context)
        {
            if (_tick < Time.time)
            {
                _tick = Time.time + FireTime;
                GameObject laser = LeanPool.Spawn(Laser);
                laser.transform.position = new Vector2(transform.position.x, transform.position.y + LaserSpacing);
            }
        }
    }
}