using TMPro;
using UnityEngine;

public class WardrobePartDropdownUI : MonoBehaviour
{
    [SerializeField] TMP_Dropdown dropdown;
    [SerializeField] WardrobeFocusController focusController;

    void Start()
    {
        if (dropdown != null)
            dropdown.onValueChanged.AddListener(OnDropdownChanged);
    }

    void OnDestroy()
    {
        if (dropdown != null)
            dropdown.onValueChanged.RemoveListener(OnDropdownChanged);
    }

    void OnDropdownChanged(int index)
    {
        if (focusController == null)
            return;

        string selected = dropdown.options[index].text;

        if (System.Enum.TryParse(selected, out WardrobeConfig.PartType part))
        {
            focusController.FocusPart(part);
        }
        else
        {
            Debug.LogWarning($"Dropdown option '{selected}' does not match PartType enum.");
        }
    }
}