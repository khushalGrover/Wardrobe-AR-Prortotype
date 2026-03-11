using UnityEngine;

[ExecuteAlways]
public class WardrobeConfig : MonoBehaviour
{
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

    void Update()
    {
        BuildWardrobe();
    }

    void BuildWardrobe()
    {
        if (leftPanel == null || rightPanel == null || topPanel == null || bottomPanel == null || backPanel == null)
            return;

        // convert mm to meters
        W = width / 1000f;
        H = height / 1000f;
        D = depth / 1000f;
        T = thickness / 1000f;
        BH = plint ? .1f : 0f;

        // LEFT PANEL
        leftPanel.localPosition = new Vector3(0, BH, 0);
        leftPanel.localScale = new Vector3(T, H, D);

        // RIGHT PANEL
        rightPanel.localPosition = new Vector3(-W + T, BH, 0);
        rightPanel.localScale = new Vector3(T, H, D);

        // BOTTOM PANEL
        bottomPanel.localPosition = new Vector3(-T, BH, 0);
        bottomPanel.localScale = new Vector3(W - (2 * T), T, D);

        // TOP PANEL
        topPanel.localPosition = new Vector3(-T, H - T + BH, 0);
        topPanel.localScale = new Vector3(W - (2 * T), T, D);

        // BACK PANEL
        backPanel.localPosition = new Vector3(-T, T + BH, 0);
        backPanel.localScale = new Vector3(W-(2*T), H-(2*T), T);

        // Hinges
        if (leftHinges != null)
        {
            leftHinges.localPosition = new Vector3(0, H / 2, D);
        }
        if (rightHinges != null)
        {
            rightHinges.localPosition = new Vector3(-W , H / 2, D);
        }

        //FrontLeftPanel pivot on left Hinges
        if (frontLeftPanel != null)
        {
            frontLeftPanel.localPosition = new Vector3(T, BH, 0);
            frontLeftPanel.localScale = new Vector3(T, H, W/2);
            frontLeftPanel.SetParent(leftHinges, true);
        }
        //FrontRightPanel pivot on right Hinges
        if (frontRightPanel != null)
        {
            frontRightPanel.localPosition = new Vector3(0, BH, 0);
            frontRightPanel.localScale = new Vector3(T, H, W/2);
            frontRightPanel.SetParent(rightHinges, true);
        }

        // Plint
        if (plintPrefab != null)
        {
            plintPrefab.SetActive(plint);
            plintPrefab.transform.localPosition = new Vector3(-W/2, BH/2, D/2);
            plintPrefab.transform.localScale = new Vector3(W, BH, D);
        }
        
    }
}