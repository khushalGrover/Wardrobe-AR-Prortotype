using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WardrobeDimensionUI : MonoBehaviour
{
    [Header("Target")]
    public WardrobeConfig wardrobe;

    [Header("Width")]
    public Slider widthSlider;
    public TMP_InputField widthInput;

    [Header("Height")]
    public Slider heightSlider;
    public TMP_InputField heightInput;

    [Header("Depth")]
    public Slider depthSlider;
    public TMP_InputField depthInput;

    private bool updating;

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

    // WIDTH
    void OnWidthSlider(float value)
    {
        if (updating) return;

        wardrobe.width = value;
        widthInput.text = Mathf.RoundToInt(value).ToString();
    }

    void OnWidthInput(string text)
    {
        if (updating) return;

        if (TryParse(text, out float v))
        {
            wardrobe.width = v;
            widthSlider.value = v;
        }
    }

    // HEIGHT
    void OnHeightSlider(float value)
    {
        if (updating) return;

        wardrobe.height = value;
        heightInput.text = Mathf.RoundToInt(value).ToString();
    }

    void OnHeightInput(string text)
    {
        if (updating) return;

        if (TryParse(text, out float v))
        {
            wardrobe.height = v;
            heightSlider.value = v;
        }
    }

    // DEPTH
    void OnDepthSlider(float value)
    {
        if (updating) return;

        wardrobe.depth = value;
        depthInput.text = Mathf.RoundToInt(value).ToString();
    }

    void OnDepthInput(string text)
    {
        if (updating) return;

        if (TryParse(text, out float v))
        {
            wardrobe.depth = v;
            depthSlider.value = v;
        }
    }

    bool TryParse(string input, out float value)
    {
        return float.TryParse(input, NumberStyles.Float, CultureInfo.InvariantCulture, out value) ||
               float.TryParse(input, NumberStyles.Float, CultureInfo.CurrentCulture, out value);
    }
}