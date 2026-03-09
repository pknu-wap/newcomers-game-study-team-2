using UnityEngine;

public class BoomerangMove : MonoBehaviour
{
    private enum pickaxeState {Attack, Return};
    pickaxeState state;
    private Vector3 attackTargetPos;
    private Transform farmer;
    private Vector3 direction;
    [SerializeField] private float speed = 10f;

    public void Init(Transform farmer, Transform enemy)
    {
        state = pickaxeState.Attack;
        attackTargetPos = enemy.position;
        this.farmer = farmer;
        direction = (enemy.position - transform.position).normalized;
        //transform.rotation
    }
    private void Update()
    {
        transform.Rotate(0, 0, -360 * Time.deltaTime);
        if (state == pickaxeState.Attack)
        {
            transform.position += (Vector3)(direction * speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, attackTargetPos) < 0.2f)
            {
                state = pickaxeState.Return;
            }
        }
        else if (state == pickaxeState.Return)
        {
            Vector3 returnDir = (farmer.position - transform.position).normalized;
            transform.position += (Vector3)(speed * Time.deltaTime * returnDir);
            if (Vector2.Distance(transform.position, farmer.position) < 0.2f)
            {
                Destroy(gameObject);
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (state == pickaxeState.Attack)
        {
            if (other.CompareTag("Enemy"))
            {
                state = pickaxeState.Return;
            }           
        }
    }
}
