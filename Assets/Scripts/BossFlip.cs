using UnityEngine;

public class BossFlip : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private void Update()
    {
        var distance = _playerTransform.position.x - transform.position.x;
        var isOnRight = distance > 0;
        _spriteRenderer.flipX = isOnRight;
    }
}