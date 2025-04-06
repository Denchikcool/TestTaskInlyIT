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
        //PlayerPrefs.DeleteKey("ControlType"); если захочется всегда начинать с клавиатуры
        _currentControlType = (ControlType)PlayerPrefs.GetInt("ControlType", 0);
        Debug.Log($"Загруженный вид передвижения: {_currentControlType} (Значение: {PlayerPrefs.GetInt("ControlType", -1)})");
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
        Debug.Log($"[ControlType] Изменен на: {_currentControlType}");
    }

    public static ControlType GetCurrentControlType()
    {
        return _currentControlType;
    }
}