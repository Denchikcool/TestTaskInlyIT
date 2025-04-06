using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;

public class PauseMenuUI : MonoBehaviour
{
    [SerializeField] 
    private GameObject _pausePanel;
    [SerializeField] 
    private TMP_Dropdown _controlDropdown;

    private void Awake()
    {
        InitializeDropdown();
        _pausePanel.SetActive(false);
    }

    private void InitializeDropdown()
    {
        _controlDropdown.ClearOptions();
        _controlDropdown.AddOptions(System.Enum.GetNames(typeof(ControlType)).ToList());

        int savedValue = PlayerPrefs.GetInt("ControlType", 0);

        _controlDropdown.SetValueWithoutNotify(savedValue);

        UpdateCaptionText((ControlType)savedValue);

        _controlDropdown.onValueChanged.AddListener(OnControlTypeSelected);
    }

    private void UpdateCaptionText(ControlType type)
    {
        if (_controlDropdown.captionText != null)
        {
            _controlDropdown.captionText.text = type.ToString();
        }
    }

    private void OnControlTypeSelected(int index)
    {
        ControlType selectedType = (ControlType)index;
        ControlTypeManager.SetControlType(selectedType);
        UpdateCaptionText(selectedType);
    }

    public void TogglePause()
    {
        bool isPaused = !_pausePanel.activeSelf;
        _pausePanel.SetActive(isPaused);
        Time.timeScale = isPaused ? 0f : 1f;
    }

    public void OnResumeButtonClicked()
    {
        TogglePause();
    }
}