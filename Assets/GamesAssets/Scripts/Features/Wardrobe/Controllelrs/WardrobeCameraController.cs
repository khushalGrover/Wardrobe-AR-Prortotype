using UnityEngine;

public class WardrobeCameraController : MonoBehaviour
{
    public WardrobeConfig wardrobe;
    public WardrobeOrbitController orbitController;
    
    public Transform followTarget;
    public Transform lookAtTarget;

    public Camera mainCamera;

    public float padding = 1.1f;

    public void FrameWardrobe()
    {
        Bounds bounds = wardrobe.GetWardrobeBounds();

        Vector3 focusPoint = bounds.center;

        float distance = CalculateCameraDistance(bounds);

        Vector3 viewDir = new Vector3(1f,0.4f,-1f).normalized;

        followTarget.position = focusPoint + viewDir * distance;

        lookAtTarget.position = focusPoint;
    }

    float CalculateCameraDistance(Bounds bounds)
    {
        float objectHeight = bounds.size.y;

        float fov = mainCamera.fieldOfView * Mathf.Deg2Rad;

        float distance = objectHeight / (2f * Mathf.Tan(fov / 2f));

        return distance * padding;
    }

    public void FocusPoint(Vector3 worldPoint)
    {
        lookAtTarget.position = worldPoint;
    }
}