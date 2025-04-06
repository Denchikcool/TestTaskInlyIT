using UnityEngine;
using UnityEngine.InputSystem;

public class SwipeControl : MonoBehaviour, IControlHandler
{
    private float _swipeThreshold = 50f;
    private PlayerMovement _playerMovement;
    private Vector2 _startMousePos;
    private bool _isSwiping;

    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }

    public void HandleInput()
    {
        var mouse = Mouse.current;

        if (mouse.leftButton.wasPressedThisFrame)
        {
            _startMousePos = mouse.position.ReadValue();
            _isSwiping = true;
            Debug.Log("[Swipe] Свайп начался");
        }

        if (_isSwiping && mouse.leftButton.wasReleasedThisFrame)
        {
            Vector2 endPos = mouse.position.ReadValue();
            float deltaX = endPos.x - _startMousePos.x;

            if (Mathf.Abs(deltaX) > _swipeThreshold)
            {
                float direction = Mathf.Sign(deltaX);
                _playerMovement.MoveTo(_playerMovement.CurrentX + direction * 2f);
                Debug.Log($"[Swipe] Свайп зафиксирован! Направление: {direction}");
            }

            _isSwiping = false;
        }
    }

    public bool IsActive => ControlTypeManager.GetCurrentControlType() == ControlType.Swipe;
}