using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
    [SerializeField] private float Damage;
    [SerializeField] private bool destroyOnHit;

    private void OnTriggerEnter2D(Collider2D other){

        other.GetComponent<EnemyHp>().TakeDamage(Damage);
        if (destroyOnHit == true)
        {
            Destroy(gameObject);
        }
    }
}
