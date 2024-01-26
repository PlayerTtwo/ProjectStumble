using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

public class PlayerBallMovementController : MonoBehaviour
{
    public Camera camera;
    private Rigidbody _rigidBody;
    private Quaternion _cameraRotation;
    private Vector3 _moveDirection;
    private Vector3 _inputDirection;

    private BallPlayerInput _ballPlayerInput;

    private void Awake()
    {
        _ballPlayerInput = GetComponent<BallPlayerInput>();
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        if(camera == null) camera = Camera.main;
    }

    private void OnEnable()
    {
        if (_ballPlayerInput != null)
        {
            _ballPlayerInput.OnMoveKeyboardInputCommand += BallPlayerInput_OnMoveKeyboardInputCommand;
            _ballPlayerInput.OnMoveInputCommand += BallPlayerInput_OnMoveInputCommand;
        }

    }

    private void OnDisable()
    {
        if (_ballPlayerInput != null)
        {
            _ballPlayerInput.OnMoveKeyboardInputCommand -= BallPlayerInput_OnMoveKeyboardInputCommand;
            _ballPlayerInput.OnMoveInputCommand -= BallPlayerInput_OnMoveInputCommand;
        }
    }

    private void BallPlayerInput_OnMoveKeyboardInputCommand(Vector3 moveInputValue)
    {
        _inputDirection = Vector3.zero;
        _inputDirection += moveInputValue;
    }

    private void BallPlayerInput_OnMoveInputCommand(Vector2 moveInputValue)
    {
        _inputDirection = Vector3.zero;
        _inputDirection += new Vector3(moveInputValue.y, 0f, -moveInputValue.x);
    }

    private void FixedUpdate()
    {
        MoveBall();
    }

    private void MoveBall()
    {
        _cameraRotation = Quaternion.AngleAxis(camera.transform.rotation.eulerAngles.y, Vector3.up);
        _moveDirection = _cameraRotation * new Vector3(Mathf.Clamp(_inputDirection.x * 2, -1, 1), 0, Mathf.Clamp(_inputDirection.z * 2, -1, 1));
        _rigidBody.AddTorque(_moveDirection*7.5f);
    }
}
