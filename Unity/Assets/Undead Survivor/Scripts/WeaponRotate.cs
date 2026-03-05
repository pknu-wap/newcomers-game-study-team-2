using UnityEngine;

public class WeaponRotate : MonoBehaviour
{
    private const float speed = 50f;

    private void Update()
    {
        transform.RotateAround(transform.parent.position, Vector3.back, speed * Time.deltaTime);
    }
}
