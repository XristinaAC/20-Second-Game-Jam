using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float sprintSpeed = 5.0f;
    [SerializeField] private float normalSpeed = 1.0f;

    private float _playerSpeed;
    private CharacterController _playerContorller;
    private Vector3             _playerVelocity;
    private bool                _isGrounded;
    private float               _gravity = -9.81f;
    private bool                _isSprinting;
   
    void Start()
    {
        _playerContorller = GetComponent<CharacterController>();
        _playerSpeed = normalSpeed;
    }

    void Update()
    {
        _isGrounded = _playerContorller.isGrounded;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void Movement(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;

        _playerContorller.Move(transform.TransformDirection(moveDirection) * _playerSpeed * Time.deltaTime);
        _playerVelocity.y += _gravity * Time.deltaTime;
        
        if(_isGrounded && _playerVelocity.y < 0)
        {
            _playerVelocity.y = -2.0f;
        }
        _playerContorller.Move(_playerVelocity * Time.deltaTime);
    }

    public void Sprinting()
    {
        _playerSpeed = sprintSpeed;
    }

    public void NotSprinting()
    {
        _playerSpeed = normalSpeed;
    }
}
