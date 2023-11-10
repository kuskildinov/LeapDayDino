using System;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    [Header("Move")]
    [SerializeField,Min(0)] private float _speed;
    [Header("Jump")]
    [SerializeField,Min(0)] private float _jumpForce;
    [SerializeField] private int _maxJumpValue = 2;
    [Header("Slide")]
    [SerializeField] private float _slipeDownSpeed;
    [Header("Settings")]
    [SerializeField] private Transform _root;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private PlayerInteractions _playerInteractions; 

    public event Action PlayerJumped;
    public event Action PlayerStandPlatform;

    private bool _grounded = true;
    private bool _canMove = true;
    private int _extraJumpsValue; 
    private IInput _input;
    private float _moveDirection = 0.9f;


    private void Update()
    {
        if(_canMove)
        {
            if (_grounded)
                Move();
            if (_input.PlayerTap())
            {
                _grounded = false;
                _rigidbody.gravityScale = 1;
                PlayerJumped?.Invoke();
                if (_extraJumpsValue > 0)
                {
                    Jump();
                }
            }
        }        
    }

    public void Initialize(IInput input)
    {
        _input = input;       
        _playerInteractions.TouchWall += TouchWall;
        _playerInteractions.TouchPlatform += LandToPlatform;
        _playerInteractions.FallFromPlatform += FallFromPlatform;
        _playerInteractions.FallFromWall += FallFromWall;
        _playerInteractions.DeadZoneTouched += Die;
        _extraJumpsValue = _maxJumpValue;
        Time.timeScale = 1.5f;
    }

    private void TouchWall()
    {
        ChangeMoveDirection();
        PlayerStandPlatform?.Invoke();
        if (_grounded == false)
            SlipDownToWall();
        _extraJumpsValue = _maxJumpValue;               
    }

    private void LandToPlatform()
    {
        PlayerStandPlatform?.Invoke();
        _grounded = true;
        _extraJumpsValue = _maxJumpValue;
        _rigidbody.gravityScale = 1;
        _canMove = true;
    }

    private void FallFromPlatform()
    {
        _grounded = false;
        _rigidbody.gravityScale = 1;
    }

    private void FallFromWall()
    {       
        _rigidbody.gravityScale = 1;        
    }

    private void OnDisable()
    {
        _playerInteractions.TouchWall -= TouchWall;
        _playerInteractions.TouchPlatform -= LandToPlatform;
        _playerInteractions.FallFromPlatform -= FallFromPlatform;
        _playerInteractions.FallFromWall -= FallFromWall;
        _playerInteractions.DeadZoneTouched -= Die;
    }

    private void Die()
    {
        _canMove = false;
    }

    #region Walk
    private void Move()
    {
        Vector2 newVelocity = new Vector2(_moveDirection * _speed,_rigidbody.velocity.y);
        _rigidbody.velocity = newVelocity;
    }

    private void ChangeMoveDirection()
    {
        _moveDirection *= -1;        
    }

    #endregion

    #region Jump
    private void Jump()
    {        
        _rigidbody.velocity = new Vector2(_moveDirection,2) * _jumpForce;
        _extraJumpsValue--;
    }
    #endregion

    #region SlideToWall

    private void SlipDownToWall()
    {
        Vector2 slideDownVelocity = new Vector2(_rigidbody.velocity.x, Vector2.down.y);
        _rigidbody.velocity = slideDownVelocity * _slipeDownSpeed;
        _rigidbody.gravityScale = 0;
    }  

    #endregion
}
