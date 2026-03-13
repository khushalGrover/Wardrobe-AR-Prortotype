using TMPro;
using UnityEngine;

public class WardrobePartDropdownUI : MonoBehaviour
{
    public TMP_Dropdown dropdown;

    public WardrobeFocusController focusController;

    void Start()
    {
        dropdown.onValueChanged.AddListener(OnDropdownChanged);
    }

    void OnDropdownChanged(int index)
    {
        string selected = dropdown.options[index].text;

        if (System.Enum.TryParse(selected, out WardrobeConfig.PartType part))
        {
            focusController.FocusPart(part);
        }
    }
}