using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    [Header("Move")]
    [SerializeField, Min(0)] private float _speed;

    [Header("Jump")]
    [SerializeField, Min(0)] private float _jumpForce;

    [Header("Slide")]
    [SerializeField] private float _slipeDownSpeed;

    [Header("Settings")]
    [SerializeField] private Transform _root;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private SpriteRenderer _sprite;

    private float _moveDirection = 0.9f;


    #region Walk
    public void Move()
    {
        Vector2 newVelocity = new Vector2(_moveDirection * _speed, _rigidbody.velocity.y);
        _rigidbody.velocity = newVelocity;
    }

    public void ChangeMoveDirection()
    {
        _moveDirection *= -1;
        if (_sprite.flipX == true)
        {
            _sprite.flipX = false;
        }
        else
            _sprite.flipX = true;
    }
    #endregion

    #region Jump
    public void Jump()
    {
        _rigidbody.velocity = new Vector2(_moveDirection, 2) * _jumpForce;
    }

    public void SecondJump()
    {
        Jump();
    }
    #endregion

    #region Slide
    public void SlipDownToWall()
    {
        Vector2 slideDownVelocity = new Vector2(_rigidbody.velocity.x, Vector2.down.y);
        _rigidbody.velocity = slideDownVelocity * _slipeDownSpeed;
    }
    public void ActivateGravity()
    {
        _rigidbody.gravityScale = 1;
    }
    public void DeactivateGravity()
    {
        _rigidbody.gravityScale = 0;
    }

    #endregion
}
