using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    private const float damage = 0.5f;
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player")) other.GetComponent<FarmerHp>().TakeDamage(damage);
    }

}