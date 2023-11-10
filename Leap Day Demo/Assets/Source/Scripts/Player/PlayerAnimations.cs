using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerMovment _playerMovment;
    [SerializeField] private PlayerInteractions _playerInteractions;

   public void Initialize()
    {
        _playerMovment.PlayerJumped += JumpAnimation;
        _playerMovment.PlayerStandPlatform += RunAnimation;
        _playerInteractions.DeadZoneTouched += DeathAnimation;
    }

    private void OnDisable()
    {
        _playerMovment.PlayerJumped -= JumpAnimation;
        _playerMovment.PlayerStandPlatform -= RunAnimation;
        _playerInteractions.DeadZoneTouched -= DeathAnimation;
    }
    private void JumpAnimation()
    {
        _animator.SetBool("Jump",true);
    }

    private void RunAnimation()
    {
        _animator.SetBool("Jump", false);
    }

    private void DeathAnimation()
    {
        _animator.SetBool("Die", true);
    }

    public void RestartAnimations()
    {
        _animator.SetBool("Die", false);
        _animator.SetBool("Jump", false);
    }
}
