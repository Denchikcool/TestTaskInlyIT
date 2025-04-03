using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeInput : InputHandler, IPointerDownHandler, IPointerUpHandler
{
    private Vector2 _startPos;
    private const float _swipeThreshold = 50f;

    public override void Enable() { }
    public override void Disable() { }

    public void OnPointerDown(PointerEventData eventData)
    {
        _startPos = eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        float swipeDist = eventData.position.x - _startPos.x;
        if (Mathf.Abs(swipeDist) > _swipeThreshold)
        {
            Notify(Mathf.Sign(swipeDist));
        }
    }
}