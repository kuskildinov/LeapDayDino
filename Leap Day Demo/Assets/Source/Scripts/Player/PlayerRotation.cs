using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private PlayerInteractions _playerInteractions;

    public void Initialize()
    {
        _playerInteractions.TouchWall += FlipSprite;

    }
    private void FlipSprite()
    {
        if (_spriteRenderer.flipX)
             _spriteRenderer.flipX = false;
        else
             _spriteRenderer.flipX = true;
    }

    private void OnDisable()
    {
        _playerInteractions.TouchWall -= FlipSprite;
    }
}
