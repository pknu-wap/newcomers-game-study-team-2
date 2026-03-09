using UnityEngine;

public class ProjectileMove : MonoBehaviour
{
    private Vector2 finalDirection;
    [SerializeField] private float speed = 12f;
    public void Init(Vector2 direction)
    {
        finalDirection = direction.normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle - 90f);
    }
    private void Update()
    {
        transform.position += (Vector3)(speed * finalDirection * Time.deltaTime);
    }

    private void OTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
