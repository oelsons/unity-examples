using UnityEngine;

public class SimplePlayerController : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private float runSpeed = 10f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 velocity = Vector3.zero;
        float speed = walkSpeed;

        if (Input.GetKey(KeyCode.W)) { velocity.z = 1; }
        if (Input.GetKey(KeyCode.A)) { velocity.x = -1; }
        if (Input.GetKey(KeyCode.S)) { velocity.z = -1; }
        if (Input.GetKey(KeyCode.D)) { velocity.x = 1; }
        if (Input.GetKey(KeyCode.LeftShift)) { speed = runSpeed; }

        rb.velocity = velocity.normalized * speed; // Normalize the vector so the diagonal speed isn't faster (sum of x and z)
    }
}
