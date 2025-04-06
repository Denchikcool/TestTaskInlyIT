using System;
using UnityEngine;


public enum ControlType
{
    Keyboard = 0,
    Swipe = 1,
    Drag = 2
}
public class ControlTypeManager : MonoBehaviour
{
    public static event Action<ControlType> OnControlTypeChanged;

    private static ControlType _currentControlType;

    private void Start()
    {
        //PlayerPrefs.DeleteKey("ControlType"); ���� ��������� ������ �������� � ����������
        _currentControlType = (ControlType)PlayerPrefs.GetInt("ControlType", 0);
        Debug.Log($"����������� ��� ������������: {_currentControlType} (��������: {PlayerPrefs.GetInt("ControlType", -1)})");
        NotifyControlTypeChanged();
    }

    public static void SetControlType(ControlType type)
    {
        if (_currentControlType == type) return;

        _currentControlType = type;
        PlayerPrefs.SetInt("ControlType", (int)type);
        NotifyControlTypeChanged();
    }

    private static void NotifyControlTypeChanged()
    {
        OnControlTypeChanged?.Invoke(_currentControlType);
        Debug.Log($"[ControlType] ������� ��: {_currentControlType}");
    }

    public static ControlType GetCurrentControlType()
    {
        return _currentControlType;
    }
}