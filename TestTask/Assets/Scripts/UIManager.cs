using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("Панель паузы")]
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private Button _pauseButton;
    [SerializeField] private Button _resumeButton;

    [Header("Выбор управления")]
    [SerializeField] private TMP_Dropdown _inputDropdown;

    private void Start()
    {
        _pauseButton.onClick.AddListener(EnablePause);
        _resumeButton.onClick.AddListener(DisablePause);

        _inputDropdown.onValueChanged.AddListener(ChangeInput);
        _inputDropdown.value = (int)InputManager.InputType.Keyboard;
    }

    public void EnablePause()
    {
        Time.timeScale = 0f;
        _pausePanel.SetActive(true);
        Debug.Log("Игра на паузе");
    }

    public void DisablePause()
    {
        Time.timeScale = 1f;
        _pausePanel.SetActive(false);
        Debug.Log("Игра продолжена");
    }

    public void ChangeInput(int index)
    {
        var inputType = (InputManager.InputType)index;
        FindObjectOfType<InputManager>().SwitchToInput(inputType);
    }
}