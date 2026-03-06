using System.Linq;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.InputSystem;

public class FarmerMovement : MonoBehaviour
{
    private const float Speed = 10f;
    private Vector3 _moveDirection;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private enum FarmerState { Stand, Run }
    
    private void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        transform.Translate(Time.deltaTime * Speed * _moveDirection);
        if (_moveDirection.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (_moveDirection.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        

        FarmerState state;
        if (_moveDirection == Vector3.zero)
        {
            state = FarmerState.Stand;
        }
        else
        {
            state = FarmerState.Run;
        }

        animator.SetInteger("state", (int)state);
    }
    
    private void OnMove(InputValue value)
    {
        _moveDirection = value.Get<Vector2>();
        _moveDirection.Normalize();
    }



}