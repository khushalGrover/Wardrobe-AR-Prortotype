using UnityEngine;

[ExecuteAlways]
public class WardrobeConfig : MonoBehaviour
{
    public enum PartType
    {
        LeftPanel,
        RightPanel,
        TopPanel,
        BottomPanel,
        BackPanel,
        FrontLeftPanel,
        FrontRightPanel,
        LeftHinges,
        RightHinges,
        Plint
    }

    [Header("Dimensions (mm)")]
    public float width = 1200f;
    public float height = 2000f;
    public float depth = 600f;
    public float thickness = 18f;
    public bool plint = true;

    [Header("Panels")]
    public Transform leftPanel;
    public Transform rightPanel;
    public Transform topPanel;
    public Transform bottomPanel;
    public Transform backPanel;
    public Transform frontLeftPanel;
    public Transform frontRightPanel;
    public Transform leftHinges;
    public Transform rightHinges;
    public GameObject plintPrefab;

    float W;
    float H;
    float D;
    float T;
    float BH;

    public void Rebuild()
    {
        BuildWardrobe();
    }

    void OnValidate()
    {
        BuildWardrobe();
    }

    void BuildWardrobe()
    {
        if (leftPanel == null || rightPanel == null || topPanel == null || bottomPanel == null || backPanel == null)
            return;

        W = width / 1000f;
        H = height / 1000f;
        D = depth / 1000f;
        T = thickness / 1000f;

        BH = plint ? 0.1f : 0f;

        leftPanel.localPosition = new Vector3(0, BH, 0);
        leftPanel.localScale = new Vector3(T, H, D);

        rightPanel.localPosition = new Vector3(-W + T, BH, 0);
        rightPanel.localScale = new Vector3(T, H, D);

        bottomPanel.localPosition = new Vector3(-T, BH, 0);
        bottomPanel.localScale = new Vector3(W - (2 * T), T, D);

        topPanel.localPosition = new Vector3(-T, H - T + BH, 0);
        topPanel.localScale = new Vector3(W - (2 * T), T, D);

        backPanel.localPosition = new Vector3(-T, T + BH, 0);
        backPanel.localScale = new Vector3(W - (2 * T), H - (2 * T), T);

        if (leftHinges != null)
            leftHinges.localPosition = new Vector3(0, H / 2, D);

        if (rightHinges != null)
            rightHinges.localPosition = new Vector3(-W, H / 2, D);

        if (frontLeftPanel != null)
        {
            frontLeftPanel.localPosition = new Vector3(T, BH, 0);
            frontLeftPanel.localScale = new Vector3(T, H, W / 2);
            frontLeftPanel.SetParent(leftHinges, true);
        }

        if (frontRightPanel != null)
        {
            frontRightPanel.localPosition = new Vector3(0, BH, 0);
            frontRightPanel.localScale = new Vector3(T, H, W / 2);
            frontRightPanel.SetParent(rightHinges, true);
        }

        if (plintPrefab != null)
        {
            plintPrefab.SetActive(plint);
            plintPrefab.transform.localPosition = new Vector3(-W / 2, BH / 2, D / 2);
            plintPrefab.transform.localScale = new Vector3(W, BH, D);
        }
    }

    public Bounds GetWardrobeBounds()
    {
        float W = width / 1000f;
        float H = height / 1000f;
        float D = depth / 1000f;

        Vector3 center = new Vector3(-W * 0.5f, H * 0.5f, D * 0.5f);
        Vector3 size = new Vector3(W, H, D);

        return new Bounds(center, size);
    }
}