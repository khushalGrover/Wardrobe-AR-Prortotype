using System.Collections.Generic;
using UnityEngine;

public class WardrobePartMap : MonoBehaviour
{
    public WardrobeConfig wardrobe;

    Dictionary<WardrobeConfig.PartType, Transform> partMap;

    void Awake()
    {
        partMap = new Dictionary<WardrobeConfig.PartType, Transform>()
        {
            { WardrobeConfig.PartType.LeftPanel, wardrobe.leftPanel },
            { WardrobeConfig.PartType.RightPanel, wardrobe.rightPanel },
            { WardrobeConfig.PartType.TopPanel, wardrobe.topPanel },
            { WardrobeConfig.PartType.BottomPanel, wardrobe.bottomPanel },
            { WardrobeConfig.PartType.BackPanel, wardrobe.backPanel },
            { WardrobeConfig.PartType.FrontLeftPanel, wardrobe.frontLeftPanel },
            { WardrobeConfig.PartType.FrontRightPanel, wardrobe.frontRightPanel },
            { WardrobeConfig.PartType.LeftHinges, wardrobe.leftHinges },
            { WardrobeConfig.PartType.RightHinges, wardrobe.rightHinges },
        };
    }

    public Transform GetPart(WardrobeConfig.PartType part)
    {
        if (partMap.TryGetValue(part, out var t))
            return t;

        return null;
    }
}