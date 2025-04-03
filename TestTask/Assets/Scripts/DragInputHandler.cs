using UnityEngine;
using UnityEngine.EventSystems;

public class DragInputHandler : BaseInputHandler, IDragHandler
{
    private bool _isEnabled;
    private Camera _camera;

    public override void Enable()
    {
        _isEnabled = true;
        _camera = Camera.main;
    }

    public override void Disable() => _isEnabled = false;

    public override void HandleInput() { }

    public void OnDrag(PointerEventData eventData)
    {
        if (!_isEnabled) return;

        float normalizedX = eventData.position.x / Screen.width;
        float targetX = Mathf.Lerp(Player.MinX, Player.MaxX, normalizedX);
        Player.SetTargetPosition(targetX);
    }
}