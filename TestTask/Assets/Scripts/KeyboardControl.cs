using UnityEngine;
using UnityEngine.InputSystem;

public class KeyboardControl : MonoBehaviour, IControlHandler
{
    private float _moveSpeed = 100f;
    private PlayerMovement _playerMovement;

    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }

    public void HandleInput()
    {
        bool aPressed = Keyboard.current.aKey.isPressed;
        bool dPressed = Keyboard.current.dKey.isPressed;
        Debug.Log($"[KeyboardControl] Клавиши - A: {aPressed}, D: {dPressed}");

        float direction = Keyboard.current.aKey.isPressed ? -1f :
                          Keyboard.current.dKey.isPressed ? 1f : 0f;

        if (direction != 0)
        {
            Debug.Log($"[KeyboardControl] Движение с направлением: {direction}");
            _playerMovement.MoveTo(_playerMovement.CurrentX + direction * _moveSpeed * Time.deltaTime);
        }
    }

    public bool IsActive => ControlTypeManager.GetCurrentControlType() == ControlType.Keyboard;
}