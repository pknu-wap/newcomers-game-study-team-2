using UnityEngine;
using UnityEngine.InputSystem;

public class FarmerMovement : MonoBehaviour
{
    private const float Speed = 8f;
    public Vector3 _moveDirection;
    public Vector3 _lastDirection = Vector2.right;

    // PitchforkLaunch에서 사용하기 위한 변수(읽기 전용)
    public Vector2 MoveDirection => _moveDirection;
    public Vector2 LastDirection => _lastDirection;

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
        // Pitchfork의 방향 설정을 위한 로직
        if (_moveDirection != Vector3.zero)
        {
            _lastDirection = _moveDirection;
        }

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