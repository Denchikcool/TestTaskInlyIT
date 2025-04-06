using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DropdownStyler : MonoBehaviour
{
    [Header("Основные настройки")]
    [SerializeField] 
    private Color dropdownColor = Color.white;
    [SerializeField] 
    private int captionFontSize = 25;
    [SerializeField] 
    private int itemFontSize = 22;

    private void Start()
    {
        TMP_Dropdown dropdown = GetComponent<TMP_Dropdown>();

        Image dropdownBackground = GetComponent<Image>();
        if (dropdownBackground != null)
        {
            dropdownBackground.color = dropdownColor;
        }

        if (dropdown.captionText != null)
        {
            dropdown.captionText.fontSize = captionFontSize;
            dropdown.captionText.fontStyle = FontStyles.Bold;
        }

        if (dropdown.itemText != null)
        {
            dropdown.itemText.fontSize = itemFontSize;
        }

        if (dropdown.template != null)
        {
            Image templateBackground = dropdown.template.GetComponent<Image>();
            if (templateBackground != null)
            {
                templateBackground.color = dropdownColor;
            }
        }
    }

    public void SetDropdownColor(Color newColor)
    {
        Image bg = GetComponent<Image>();
        if (bg != null) bg.color = newColor;
    }
}