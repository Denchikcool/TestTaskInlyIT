using UnityEngine;
using UnityEngine.EventSystems;

public class DragInput : InputHandler, IDragHandler
{
    private Camera _camera;

    public override void Enable() => _camera = Camera.main;
    public override void Disable() { }

    public void OnDrag(PointerEventData eventData)
    {
        float screenX = eventData.position.x / Screen.width;
        float direction = (screenX - 0.5f) * 2f; // -1..1
        Notify(direction * Time.deltaTime);
    }
}