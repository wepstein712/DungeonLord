using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Stats")]
    public float _moveSpeed = 5f;

    [Header("References")]
    //Input master needs to get passed around or references somehow
    //public InputMaster _inputs;
    public Animator _animator;
    public Rigidbody2D _rb;
    public InputMaster _inputs;
    private Vector2 _movementInputDirection;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _inputs = new InputMaster();
        _animator = GetComponentInChildren<Animator>();
        SetupMovementCallbacks();
    }

    void SetupMovementCallbacks()
    {
        _inputs.PlayerActions.Movement.canceled += _ => _movementInputDirection = new Vector2(0f, 0f);
        _inputs.PlayerActions.Movement.performed += performedContext => _movementInputDirection = performedContext.ReadValue<Vector2>();
        //This works, may need some kind of input manager per player so that this instance can get passed around perhaps
        _inputs.PlayerActions.Attack.performed += context => _animator.SetTrigger("Attack");
    }

    private void Move()
    {
        //Debug.Log(_movementInputDirection);
        _rb.velocity = _movementInputDirection * _moveSpeed;
    }

    private void Animate()
    {
        if(_movementInputDirection != Vector2.zero)
        {
            //Change move direction value on controller
            _animator.SetFloat("Horizontal", _movementInputDirection.x);
            _animator.SetFloat("Vertical", _movementInputDirection.y);
        }

        //Change move speed value on controller
        _animator.SetFloat("MoveSpeed", _movementInputDirection.magnitude);
    }

    void Update()
    {
        Move();
        Animate();
    }

    private void OnEnable()
    {
        _inputs.Enable();    
    }

    void OnDisable()
    {
        _inputs.Disable();
    }
}
