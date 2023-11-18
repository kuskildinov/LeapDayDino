using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private PlayerInteractions _playerInteractions;
    [SerializeField] private Animator _animator;
    public void OnWall()
    {
        _animator.SetBool("OnWall",true);
    }

    public void ExitWall()
    {
        _animator.SetBool("OnWall", false);
    }

    public void Die()
    {
        _animator.SetBool("Die", true);
    }

    public void NewLive()
    {
        _animator.SetBool("Die", false);
    }

    public void Jump()
    {
        _animator.SetBool("Jump", true);
    }

    public void Fall()
    {
        _animator.SetBool("Fall", true);
    }
    public void Land()
    {
        _animator.SetBool("Jump", false);
        _animator.SetBool("Fall", false);
    }
}
