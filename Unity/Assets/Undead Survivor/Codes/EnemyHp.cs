using UnityEngine;

public class EnemyHp : MonoBehaviour
{
    private const float MaxHp = 100f;
    [SerializeField] private GameObject expChip;    
    private float _currentHp = MaxHp;

    public void TakeDamage(float damage){

        _currentHp -= damage;
        Debug.Log($"Enemy HP: {_currentHp}");
        if (_currentHp <= 0){

            Instantiate(expChip, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
