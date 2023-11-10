using UnityEngine;
public class PlayerSound : MonoBehaviour
{
    [SerializeField] private PlayerMovment _playerMovment;
    [SerializeField] private PlayerInteractions _playerInteractions;
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip _jumpSound;
    [SerializeField] private AudioClip _landSound;
    [SerializeField] private AudioClip _dieSound;

    public void Initialize()
    {
        _playerMovment.PlayerJumped += PlayJumpSound;
        _playerInteractions.TouchPlatform += PlayLandSound;
        _playerInteractions.DeadZoneTouched += PlayDieSound;
    }

    private void PlayJumpSound()
    {
        _source.PlayOneShot(_jumpSound);
    }

    private void PlayLandSound()
    {
        _source.PlayOneShot(_landSound);
    }

    private void PlayDieSound()
    {
        _source.PlayOneShot(_dieSound);
    }

    private void OnDisable()
    {
        _playerMovment.PlayerJumped -= PlayJumpSound;
        _playerInteractions.TouchPlatform -= PlayLandSound;
        _playerInteractions.DeadZoneTouched -= PlayDieSound;
    }
}
