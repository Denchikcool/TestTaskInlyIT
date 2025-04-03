using UnityEngine;
using System;

public abstract class InputHandler : MonoBehaviour
{
    public event Action<float> OnMoveEvent; // ������� ��� ����������

    protected void Notify(float direction)
    {
        OnMoveEvent?.Invoke(direction); // ���������� �����������
    }

    public abstract void Enable();
    public abstract void Disable();
}