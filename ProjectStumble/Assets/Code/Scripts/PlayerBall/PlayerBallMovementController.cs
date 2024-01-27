using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBallMovementController : MonoBehaviour
{
    public  Camera     camera;
    private Rigidbody  _rigidBody;
    private Quaternion _cameraRotation;
    private Vector3    _moveDirection;
    private Vector3    _inputDirection;
    private Coroutine _groundCheckCoroutine;

    private BallPlayerInput _ballPlayerInput;

    [SerializeField] private PlayerBallState _playerBallState = PlayerBallState.Rolling;

    [BoxGroup("Movement"), SerializeField] private float _torque    = 7.5f;
    [BoxGroup("Movement"), SerializeField] private bool _allowMovement;
    [BoxGroup("Jump"), SerializeField] private float _jumpForce = 100f;

    [BoxGroup("Double Jump"), SerializeField] private float _doubleJumpForce = 100f;
    [BoxGroup("Grounded"), SerializeField] private LayerMask _groundLayers;
    [BoxGroup("Grounded"), SerializeField] private float _groundRayLength = 2f;

    private bool _allowGroundCheck;
    private bool _isGrounded;

    #region Properties

    public float Torque          { get => _torque;          set => _torque = value; }
    public float JumpForce       { get => _jumpForce;       set => _jumpForce = value; }
    public float DoubleJumpForce { get => _doubleJumpForce; set => _doubleJumpForce = value; }

    [SerializeField] public bool IsGrounded {
        get
        {
            if (!_allowGroundCheck) 
            {
                _isGrounded = false;
                return _isGrounded;
            }
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit, _groundRayLength, _groundLayers))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.red);
                _isGrounded = true;
                return _isGrounded;
            }

            _isGrounded = false;
            return _isGrounded;
        }
        set => _isGrounded = value;
    } 

    #endregion

    private void Awake()
    {
        _ballPlayerInput = GetComponent<BallPlayerInput>();
        _rigidBody       = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        if (camera == null) camera = Camera.main;
        IsGrounded = true;
    }

    private void OnEnable()
    {
        if (LevelManager.Instance != null)
        {
            LevelManager.Instance.OnJoinPlayer();
            LevelManager.Instance.OnLevelStart += LevelManager_OnLevelStart;
        }

        if (_ballPlayerInput != null)
        {
            _ballPlayerInput.OnMoveKeyboardInputCommand += BallPlayerInput_OnMoveKeyboardInputCommand;
            _ballPlayerInput.OnMoveInputCommand         += BallPlayerInput_OnMoveInputCommand;
            _ballPlayerInput.OnJumpCommand              += BallPlayerInput_OnJumpCommand;
        }
    }

    private void OnDisable()
    {
        if (LevelManager.Instance != null)
            LevelManager.Instance.OnLevelStart -= LevelManager_OnLevelStart;

        if (_ballPlayerInput != null)
        {
            _ballPlayerInput.OnMoveKeyboardInputCommand -= BallPlayerInput_OnMoveKeyboardInputCommand;
            _ballPlayerInput.OnMoveInputCommand         -= BallPlayerInput_OnMoveInputCommand;
            _ballPlayerInput.OnJumpCommand              -= BallPlayerInput_OnJumpCommand;
        }
    }

    private void LevelManager_OnLevelStart() => _allowMovement = true;

    private void BallPlayerInput_OnMoveKeyboardInputCommand(Vector3 moveInputValue)
    {
        _inputDirection =  Vector3.zero;
        _inputDirection += moveInputValue;
    }

    private void BallPlayerInput_OnMoveInputCommand(Vector2 moveInputValue)
    {
        _inputDirection =  Vector3.zero;
        _inputDirection += new Vector3(moveInputValue.y, 0f, -moveInputValue.x);
    }

    private void BallPlayerInput_OnJumpCommand() => Jump();

    private void FixedUpdate() 
    {
        if (IsGrounded && _playerBallState != PlayerBallState.Rolling)
        {
            if (_groundCheckCoroutine != null) StopCoroutine(_groundCheckCoroutine);
            _allowGroundCheck = true;
            _playerBallState = PlayerBallState.Rolling;
        }

        MoveBall();
    } 

    private void MoveBall()
    {
        if (!_allowMovement) return;

        _cameraRotation = Quaternion.AngleAxis(camera.transform.rotation.eulerAngles.y, Vector3.up);
        _moveDirection = _cameraRotation * new Vector3(Mathf.Clamp(_inputDirection.x * 2, -1, 1),
                                                       0,
                                                       Mathf.Clamp(_inputDirection.z * 2, -1, 1));
        
        if (IsGrounded)
            _rigidBody.AddTorque(_moveDirection * Torque);
        else
        {
            Vector3 midAirMoveDirection = new Vector3(-_moveDirection.z, _moveDirection.y, _moveDirection.x);
            _rigidBody.AddForce(midAirMoveDirection / 8f, ForceMode.VelocityChange);
        }
    }

    private void Jump()
    {
        if (!_allowMovement) return;
        if (_playerBallState == PlayerBallState.DoubleJumping) return;

        float jumpForce = JumpForce;
        if (_playerBallState == PlayerBallState.Rolling)
        {
            _playerBallState = PlayerBallState.Jumping;
        }
        else if (_playerBallState == PlayerBallState.Jumping)
        {
            _playerBallState = PlayerBallState.DoubleJumping;
            jumpForce        = _doubleJumpForce;
        }

        Vector3 jumpDirection = new Vector3(0f, jumpForce, 0f);
        _rigidBody.AddForce(jumpDirection, ForceMode.Impulse);
        _allowGroundCheck = false;
        if (_groundCheckCoroutine != null) StopCoroutine(_groundCheckCoroutine);
        _groundCheckCoroutine = StartCoroutine(EnableGroundCheck());
    }

    private IEnumerator EnableGroundCheck()
    {
        yield return new WaitForSeconds(.5f);
        _allowGroundCheck = true;
    }
}