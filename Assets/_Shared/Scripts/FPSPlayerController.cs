using UnityEngine;
using UnityEngine.InputSystem;

public class FPSPlayerController : MonoBehaviour
{
    public bool CanMove { get; private set; } = true;

    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private float runSpeed = 10f;

    [SerializeField, Range(1, 10)] private float lookSpeedX = 2f;
    [SerializeField, Range(1, 10)] private float lookSpeedY = 2f;
    [SerializeField, Range(1, 180)] private float upperLookLimit = 80f;
    [SerializeField, Range(1, 180)] private float lowerLookLimit = 80f;
    [Header("Debug")]
    [SerializeField] bool debug = false;

    private Rigidbody rb;
    private Camera playerCamera;

    private Vector3 velocity;
    private Vector3 currentInput;

    private float rotationX = 0;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerCamera = GetComponentInChildren<Camera>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (!CanMove) return;

        Move();
        Look();
    }

    private void Move()
    {
        float speed = walkSpeed;
        if (Input.GetKey(KeyCode.LeftShift)) { speed = runSpeed; }

        currentInput = new Vector2(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));

        velocity = (transform.TransformDirection(Vector3.forward) * currentInput.x) + (transform.TransformDirection(Vector3.right) * currentInput.y);
        velocity.Normalize();
        velocity *= speed;
        velocity.y = rb.velocity.y;

        rb.velocity = velocity;
    }

    private void Look()
    {
        rotationX -= Input.GetAxis("Mouse Y") * lookSpeedY;
        rotationX = Mathf.Clamp(rotationX, -upperLookLimit, lowerLookLimit);
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);

        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeedX, 0);

        if (!debug) return;

        if (Input.GetMouseButton(0)) {
            Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit rh);

            Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * rh.distance, Color.red, 0.2f);
        }
    }
}
