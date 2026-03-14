using UnityEngine;

public class WardrobeOrbitController : MonoBehaviour
{
    [Header("Orbit")]
    [SerializeField] Transform orbitPivot;
    [SerializeField] Transform cameraFollowTarget;

    [Header("Settings")]
    public float orbitSpeed = 120f;
    public float zoomSpeed = 4f;

    public float minDistance = 0.5f;
    public float maxDistance = 6f;

    public float minVerticalAngle = -20f;
    public float maxVerticalAngle = 70f;

    float currentDistance = 2f;
    float verticalRotation = 20f;

    void Update()
    {
        HandleOrbit();
        HandleZoom();
    }

    void HandleOrbit()
    {
#if UNITY_EDITOR || UNITY_STANDALONE

        if (!Input.GetMouseButton(0))
            return;

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        Orbit(mouseX, mouseY);

#else

        if (Input.touchCount != 1)
            return;

        Touch touch = Input.GetTouch(0);

        if (touch.phase != TouchPhase.Moved)
            return;

        Orbit(touch.deltaPosition.x * 0.02f, touch.deltaPosition.y * 0.02f);

#endif
    }

    void Orbit(float x, float y)
    {
        orbitPivot.Rotate(Vector3.up, x * orbitSpeed * Time.deltaTime, Space.World);

        verticalRotation -= y * orbitSpeed * Time.deltaTime;
        verticalRotation = Mathf.Clamp(verticalRotation, minVerticalAngle, maxVerticalAngle);

        orbitPivot.localEulerAngles = new Vector3(verticalRotation, orbitPivot.localEulerAngles.y, 0);
    }

    void HandleZoom()
    {
#if UNITY_EDITOR || UNITY_STANDALONE

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (Mathf.Abs(scroll) < 0.001f)
            return;

        currentDistance -= scroll * zoomSpeed;

#else

        if (Input.touchCount != 2)
            return;

        Touch t0 = Input.GetTouch(0);
        Touch t1 = Input.GetTouch(1);

        float prevDist = (t0.position - t0.deltaPosition - (t1.position - t1.deltaPosition)).magnitude;
        float currDist = (t0.position - t1.position).magnitude;

        float delta = currDist - prevDist;

        currentDistance -= delta * 0.01f;

#endif

        currentDistance = Mathf.Clamp(currentDistance, minDistance, maxDistance);

        cameraFollowTarget.localPosition = new Vector3(0, 0, -currentDistance);
    }

    public void SetDistance(float distance)
    {
        currentDistance = Mathf.Clamp(distance, minDistance, maxDistance);
        cameraFollowTarget.localPosition = new Vector3(0, 0, -currentDistance);
    }

    public void SetPivotPosition(Vector3 position)
    {
        orbitPivot.position = position;
    }
}