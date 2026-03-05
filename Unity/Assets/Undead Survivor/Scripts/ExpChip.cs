using UnityEngine;

public class ExpChip : MonoBehaviour
{
    private const float Exp = 10f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        other.GetComponent<FarmerLevel>().AddExp((int)Exp);
        Destroy(gameObject);
    }
}
