using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WardrobeDimensionUI : MonoBehaviour
{
    public WardrobeConfig wardrobe;

    public Slider widthSlider;
    public TMP_InputField widthInput;

    public Slider heightSlider;
    public TMP_InputField heightInput;

    public Slider depthSlider;
    public TMP_InputField depthInput;

    bool updating;

    void Start()
    {
        SyncUI();

        widthSlider.onValueChanged.AddListener(OnWidthSlider);
        heightSlider.onValueChanged.AddListener(OnHeightSlider);
        depthSlider.onValueChanged.AddListener(OnDepthSlider);

        widthInput.onEndEdit.AddListener(OnWidthInput);
        heightInput.onEndEdit.AddListener(OnHeightInput);
        depthInput.onEndEdit.AddListener(OnDepthInput);
    }

    void SyncUI()
    {
        updating = true;

        widthSlider.value = wardrobe.width;
        heightSlider.value = wardrobe.height;
        depthSlider.value = wardrobe.depth;

        widthInput.text = Mathf.RoundToInt(wardrobe.width).ToString();
        heightInput.text = Mathf.RoundToInt(wardrobe.height).ToString();
        depthInput.text = Mathf.RoundToInt(wardrobe.depth).ToString();

        updating = false;
    }

    void OnWidthSlider(float value)
    {
        if (updating) return;

        wardrobe.width = value;
        wardrobe.Rebuild();

        widthInput.text = Mathf.RoundToInt(value).ToString();
    }

    void OnWidthInput(string text)
    {
        if (updating) return;

        if (TryParse(text, out float v))
        {
            wardrobe.width = v;
            wardrobe.Rebuild();

            widthSlider.value = v;
        }
    }

    void OnHeightSlider(float value)
    {
        if (updating) return;

        wardrobe.height = value;
        wardrobe.Rebuild();

        heightInput.text = Mathf.RoundToInt(value).ToString();
    }

    void OnHeightInput(string text)
    {
        if (updating) return;

        if (TryParse(text, out float v))
        {
            wardrobe.height = v;
            wardrobe.Rebuild();

            heightSlider.value = v;
        }
    }

    void OnDepthSlider(float value)
    {
        if (updating) return;

        wardrobe.depth = value;
        wardrobe.Rebuild();

        depthInput.text = Mathf.RoundToInt(value).ToString();
    }

    void OnDepthInput(string text)
    {
        if (updating) return;

        if (TryParse(text, out float v))
        {
            wardrobe.depth = v;
            wardrobe.Rebuild();

            depthSlider.value = v;
        }
    }

    bool TryParse(string input, out float value)
    {
        return float.TryParse(input, NumberStyles.Float, CultureInfo.InvariantCulture, out value) ||
               float.TryParse(input, NumberStyles.Float, CultureInfo.CurrentCulture, out value);
    }
}