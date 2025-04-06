using UnityEngine;

public class InputRouter : MonoBehaviour
{
    private IControlHandler[] _controlHandlers;

    private void Awake()
    {
        _controlHandlers = GetComponents<IControlHandler>();
        ControlTypeManager.OnControlTypeChanged += OnControlTypeChanged;
    }

    private void OnDestroy()
    {
        ControlTypeManager.OnControlTypeChanged -= OnControlTypeChanged;
    }

    private void Update()
    {
        foreach (var handler in _controlHandlers)
        {
            if (handler.IsActive)
            {
                handler.HandleInput();
                break;
            }
        }
    }

    private void OnControlTypeChanged(ControlType newType)
    {
        Debug.Log($"[InputRouter] Тип передвижения изменен на: {newType}");
        var playerMovement = GetComponent<PlayerMovement>();
        if (playerMovement != null)
        {
            playerMovement.ResetToCenter();
        }
    }
}