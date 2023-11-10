using System;
using System.Collections;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    [SerializeField] private PlayerAnimations _playerAnimations;
    [SerializeField] private Transform _root;
    [SerializeField] private ParticleSystem _deadParticle;
    [SerializeField] private LayerMask _checkpointPlatformLayer;
    [SerializeField] private SaveRoot _saveSystem;
    [SerializeField] private GameObject _winPanel;

    public event Action TouchWall;
    public event Action StayNearWall;
    public event Action DeadZoneTouched;
    public event Action FallFromWall;
    public event Action TouchPlatform;
    public event Action FallFromPlatform;
    public event Action CheckPoint;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            TouchWall?.Invoke();            
        }
        if (collision.gameObject.tag == "Platform")
        {
            TouchPlatform?.Invoke();            
        }  
        if(collision.transform.TryGetComponent<CrushedBlock>(out CrushedBlock _block))
        {
            _block.gameObject.SetActive(false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            FallFromWall?.Invoke();
        }
        if (collision.gameObject.tag == "Platform")
        {
            FallFromPlatform?.Invoke();
        }       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "DeadZone")
        {
            StartCoroutine(DeadDelay());
            DeadZoneTouched.Invoke();
          
        }
        if(collision.gameObject.tag == "CheckPoint")
        {
            CheckPoint?.Invoke();           
        }

        if(collision.gameObject.TryGetComponent<Collactable>(out Collactable item))
        {
            item.Taked();
        }

        if(collision.gameObject.TryGetComponent<WinZone>(out WinZone winZone))
        {
            winZone.Win();
            Win();
        }
    }

    private void Dead()
    {        
        _root.position = _saveSystem.GetCheckPoint();
        _playerAnimations.RestartAnimations();
        StopCoroutine(DeadDelay());
    }

    private void Win()
    {
        _winPanel.SetActive(true);
    }

    private IEnumerator DeadDelay()
    {
        _deadParticle.Play();
        yield return new WaitForSeconds(1f);
        Dead();
    }
}
