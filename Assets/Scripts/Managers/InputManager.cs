using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput _playerInput;
    public PlayerInput.MovementActions _movementActions;

    private PlayerMovement _movement;
    private PlayerLook _lookAround;

    private float _initialLookCameraTime;
    private float _initialLookCameraTimer = 2.0f;
    private bool  _canMoveCamera = false;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _movementActions = _playerInput.Movement;
        _movement = GetComponent<PlayerMovement>();
        _lookAround = GetComponent<PlayerLook>();

        StartCoroutine(CameraLookAroundDelay());
    }

    IEnumerator CameraLookAroundDelay()
    {
        yield return new WaitForSeconds(.5f);
        _canMoveCamera = true;
    }

    void FixedUpdate()
    {
        _movement.Movement(_movementActions.Walking.ReadValue<Vector2>());
        //_movementActions.Sprint.performed += ctx => _movement.Sprinting();
        if(_movementActions.Sprint.IsPressed())
        {
            _movement.Sprinting();
        }
        else
        {
            _movement.NotSprinting();
        }
    }

    private void LateUpdate()
    {
        if(_canMoveCamera)
        {
            _lookAround.LookAround(_movementActions.LookAround.ReadValue<Vector2>());
        }
    }

    private void OnEnable()
    {
        _movementActions.Enable();
    }

    private void OnDisable()
    {
        _movementActions.Disable();
    }
}
