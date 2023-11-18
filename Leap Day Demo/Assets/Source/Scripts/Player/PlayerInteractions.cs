using System;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    private bool _onGround;
    private bool _isJump;
    private bool _isSlide;

    public event Action TouchPlatform;   
    public event Action ExitTouchPlatform;
    public event Action TouchWall;   
    public event Action ExitTouchWall;

    public event Action Die;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            TouchPlatform?.Invoke();
        }
        if (collision.gameObject.tag == "Wall")
        {
            TouchWall?.Invoke();
        }
        if(collision.gameObject.TryGetComponent<CrushedBlock>(out CrushedBlock block))
        {
            block.gameObject.SetActive(false);
        }

    } 
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            ExitTouchWall?.Invoke();
        }
        if (collision.gameObject.tag == "Platform")
        {
            ExitTouchPlatform?.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "DeadZone")
        {
            Die?.Invoke();
        }
    }

}
