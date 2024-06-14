using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    [SerializeField, Range(1, 10)] private float zoomSteps = 1f;
    [SerializeField] private Vector2 fovClamp = new Vector2(10f, 60f);
    [SerializeField] private Slider zoomSlider;

    private Camera cam;

    private void Awake()
    {
        cam = GetComponent<Camera>();
    }

    private void Update()
    {
        if (Input.mouseScrollDelta.y == 0) return;

        float fov = cam.fieldOfView;

        if (Input.mouseScrollDelta.y > 0) {
            fov -= zoomSteps;
        } else if (Input.mouseScrollDelta.y < 0) {
            fov += zoomSteps;
        }

        cam.fieldOfView = Mathf.Clamp(fov, fovClamp.x, fovClamp.y);
        float range = (fovClamp.y - fovClamp.x);
        float value = (cam.fieldOfView - fovClamp.x);

        zoomSlider.value = (range - value) / range;
    }
}
