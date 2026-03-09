using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private const float Speed = 2f;
    private Transform _playerTransform;

    SpriteRenderer spriter;

    private void Awake()
    {
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        spriter = GetComponent<SpriteRenderer>();
    }
    
    private void Update()
    {
        var direction = _playerTransform.position - transform.position;
        direction.Normalize();
        transform.Translate(Time.deltaTime * Speed * direction);
    }

    private void LateUpdate()
    {
        spriter.flipX = _playerTransform.position.x < transform.position.x;
    }
}