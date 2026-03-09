using UnityEngine;
using UnityEngine.InputSystem;

public class FarmerMovement : MonoBehaviour
{
    private const float Speed = 5f;
    private Vector3 _moveDirection;

    SpriteRenderer spriter;
    Animator anim;

    void Awake()
    {
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        transform.Translate(Time.deltaTime * Speed * _moveDirection);
    }

    private void OnMove(InputValue value)
    {
        _moveDirection = value.Get<Vector2>();
        _moveDirection.Normalize();
    }

    private void LateUpdate()
    {
        anim.SetFloat("Speed", _moveDirection.magnitude);

        if (_moveDirection.x != 0)
        {
            spriter.flipX = _moveDirection.x <0;
        }
    }
}