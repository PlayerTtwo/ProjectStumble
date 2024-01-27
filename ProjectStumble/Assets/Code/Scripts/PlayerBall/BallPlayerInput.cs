using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class BallPlayerInput : MonoBehaviour
{
    public event Action<Vector2> OnMoveInputCommand;
    public event Action<Vector3> OnMoveKeyboardInputCommand;
    public event Action          OnJumpCommand;

    private Vector2 _moveInputValue;
    private Vector3 _inputDirection;

    private bool _isUsingKeyboard = true;

    private void FixedUpdate()
    {
        HandleKeyboardInput();
    }

    private void OnMove(InputValue value)
    {
        _isUsingKeyboard = false;
        _moveInputValue = value.Get<Vector2>();
        OnMoveInputCommand?.Invoke(_moveInputValue);
    }

    private void OnUseItem()
    {
        Debug.Log("Use Item");
    }

    private void OnJump()
    {
        OnJumpCommand?.Invoke();
    }

    private void HandleKeyboardInput()
    {
        if (_isUsingKeyboard)
        {
            _inputDirection = Vector3.zero;
            OnMoveKeyboardInputCommand?.Invoke(_inputDirection);
        }

        if (Keyboard.current.qKey.isPressed || Keyboard.current.aKey.isPressed)
        {
            _inputDirection = Vector3.zero;
            _inputDirection += new Vector3(0, 0, 1);
            OnMoveKeyboardInputCommand?.Invoke(_inputDirection);
            _isUsingKeyboard = true;
        }
        if (Keyboard.current.dKey.isPressed)
        {
            _inputDirection = Vector3.zero;
            _inputDirection += new Vector3(0, 0, -1);
            OnMoveKeyboardInputCommand?.Invoke(_inputDirection);
            _isUsingKeyboard = true;
        }
        if (Keyboard.current.wKey.isPressed || Keyboard.current.zKey.isPressed)
        {
            _inputDirection = Vector3.zero;
            _inputDirection += new Vector3(1, 0, 0);
            OnMoveKeyboardInputCommand?.Invoke(_inputDirection);
            _isUsingKeyboard = true;
        }
        if (Keyboard.current.sKey.isPressed)
        {
            _inputDirection = Vector3.zero;
            _inputDirection += new Vector3(-1, 0, 0);
            OnMoveKeyboardInputCommand?.Invoke(_inputDirection);
            _isUsingKeyboard = true;
        }
    }
}
