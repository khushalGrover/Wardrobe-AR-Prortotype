using System.Collections.Generic;
using UnityEngine;

public class WardrobeFocusController : MonoBehaviour
{
    public WardrobeConfig wardrobe;
    public WardrobeCameraController cameraController;

    Dictionary<WardrobeConfig.PartType, Vector3> focusOffsets;

    void Awake()
    {
        focusOffsets = new Dictionary<WardrobeConfig.PartType, Vector3>()
        {
            { WardrobeConfig.PartType.LeftPanel, new Vector3(0f,0.5f,0.5f) },
            { WardrobeConfig.PartType.RightPanel, new Vector3(1f,0.5f,0.5f) },
            { WardrobeConfig.PartType.TopPanel, new Vector3(0.5f,1f,0.5f) },
            { WardrobeConfig.PartType.BottomPanel, new Vector3(0.5f,0f,0.5f) },
            { WardrobeConfig.PartType.BackPanel, new Vector3(0.5f,0.5f,0f) },
            { WardrobeConfig.PartType.FrontLeftPanel, new Vector3(0.25f,0.5f,1f) },
            { WardrobeConfig.PartType.FrontRightPanel, new Vector3(0.75f,0.5f,1f) }
        };
    }

    public void FocusPart(WardrobeConfig.PartType part)
    {
        if (!focusOffsets.ContainsKey(part))
            return;

        Vector3 normalized = focusOffsets[part];

        Bounds bounds = wardrobe.GetWardrobeBounds();

        Vector3 focusPoint = new Vector3(
            Mathf.Lerp(bounds.min.x, bounds.max.x, normalized.x),
            Mathf.Lerp(bounds.min.y, bounds.max.y, normalized.y),
            Mathf.Lerp(bounds.min.z, bounds.max.z, normalized.z)
        );

        cameraController.FocusPoint(focusPoint);
    }
}