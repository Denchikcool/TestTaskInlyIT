using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeInputHandler : BaseInputHandler, IPointerDownHandler, IPointerUpHandler
{
    private const float SwipeThreshold = 50f;
    private Vector2 _startPosition;
    private bool _isEnabled;
    private bool _isSwiping;

    public override void Enable() => _isEnabled = true;
    public override void Disable() => _isEnabled = false;

    public override void HandleInput() { }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!_isEnabled) return;
        _startPosition = eventData.position;
        _isSwiping = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (!_isEnabled || !_isSwiping) return;

        float swipeDistance = eventData.position.x - _startPosition.x;
        if (Mathf.Abs(swipeDistance) > SwipeThreshold)
        {
            float direction = Mathf.Sign(swipeDistance);
            Player.SetTargetPosition(Player.transform.position.x + direction * 2f); // Смещение на 2 единицы
        }
        _isSwiping = false;
    }
}