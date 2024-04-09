using UnityEngine;

public class SimplePlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 velocity = Vector3.zero;

        if (Input.GetKey(KeyCode.W)) { velocity.z = 1; }
        if (Input.GetKey(KeyCode.A)) { velocity.x = -1; }
        if (Input.GetKey(KeyCode.S)) { velocity.z = -1; }
        if (Input.GetKey(KeyCode.D)) { velocity.x = 1; }

        rb.velocity = velocity.normalized * speed; // Normalize the vector so the diagonal speed isn't faster (sum of x and z)
    }
}
