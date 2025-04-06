using UnityEngine;
using UnityEngine.InputSystem;

public class DragControl : MonoBehaviour, IControlHandler
{
    private float _moveSpeed = 0.5f;
    private PlayerMovement _playerMovement;
    private bool _isDragging;
    private Vector2 _lastMousePos;

    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }

    public void HandleInput()
    {
        var mouse = Mouse.current;

        if (mouse.leftButton.wasPressedThisFrame)
        {
            _isDragging = true;
            _lastMousePos = mouse.position.ReadValue();
            Debug.Log("[Drag] Драг начался");
        }
        else if (mouse.leftButton.wasReleasedThisFrame)
        {
            _isDragging = false;
            Debug.Log("[Drag] Драг закончился");
        }

        if (_isDragging)
        {
            Vector2 currentPos = mouse.position.ReadValue();
            float deltaX = (currentPos.x - _lastMousePos.x) * 0.1f;

            float newX = _playerMovement.CurrentX + deltaX * _moveSpeed;
            _playerMovement.MoveTo(newX);

            _lastMousePos = currentPos;
            Debug.Log($"[Drag] Передвижение в: {deltaX}");
        }
    }

    public bool IsActive => ControlTypeManager.GetCurrentControlType() == ControlType.Drag;
}