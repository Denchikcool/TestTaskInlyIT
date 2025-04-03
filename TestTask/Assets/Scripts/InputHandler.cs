using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class InputHandler : MonoBehaviour
{
    public event UnityAction<float> OnMove;

    protected void InvokeMove(float direction)
    {
        OnMove?.Invoke(direction);
    }

    public abstract void Enable();
    public abstract void Disable();
}
