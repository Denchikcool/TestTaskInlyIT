using UnityEngine;
using System;

public abstract class InputHandler : MonoBehaviour
{
    public event Action<float> OnMoveEvent; // Событие для наблюдения

    protected void Notify(float direction)
    {
        OnMoveEvent?.Invoke(direction); // Уведомляем подписчиков
    }

    public abstract void Enable();
    public abstract void Disable();
}