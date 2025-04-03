using UnityEngine;
using UnityEngine.EventSystems;

public class TouchInputHandler : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    [SerializeField] private float _swipeThreshold = 50f;

    private Vector2 _startTouchPosition;
    private bool _isDragging;
    private PlayerController _player;

    private void Awake()
    {
        _player = FindObjectOfType<PlayerController>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (InputManager.Instance.CurrentInputType != InputType.Swipe) return;

        _startTouchPosition = eventData.position;
        _isDragging = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (InputManager.Instance.CurrentInputType != InputType.Drag) return;

        _isDragging = true;
        float normalizedX = eventData.position.x / Screen.width;
        float targetX = Mathf.Lerp(_player.MinX, _player.MaxX, normalizedX);
        _player.SetTargetPosition(targetX);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (InputManager.Instance.CurrentInputType != InputType.Swipe || _isDragging) return;

        float swipeDistance = eventData.position.x - _startTouchPosition.x;
        if (Mathf.Abs(swipeDistance) > _swipeThreshold)
        {
            float direction = Mathf.Sign(swipeDistance);
            _player.MoveTo(direction);
        }
    }
}