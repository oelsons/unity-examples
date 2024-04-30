using UnityEngine;

public class DoorHingeMotor : MonoBehaviour, IActivatable
{
    [SerializeField] private bool isClosed;
    [SerializeField] private float doorSpeed;
    [SerializeField] private float doorForce;

    private HingeJoint joint;

    JointMotor motor = new JointMotor();

    [SerializeField, TextArea] string debug;

    private void Awake()
    {
        joint = GetComponent<HingeJoint>();
    }

    private void Open()
    {
        motor.targetVelocity = -doorSpeed;
        motor.force = doorForce;
        joint.motor = motor;
    }

    private void Close()
    {
        motor.targetVelocity = doorSpeed;
        motor.force = doorForce;
        joint.motor = motor;
    }

    private void Update()
    {
        if (joint == null) Destroy(this);
        if (!joint.useMotor) return;

        int angle = Mathf.RoundToInt(joint.angle);
        int limitMin = Mathf.RoundToInt(joint.limits.min);
        int limitMax = Mathf.RoundToInt(joint.limits.max);

        joint.useMotor = !((motor.targetVelocity > 0 && angle == limitMax) || (motor.targetVelocity < 0 && angle == limitMin));

        debug = "joint.limits.max: " + limitMax + "\njoint.limits.min: " + limitMin + "\nintAngle: " + angle;
    }

    public void Activate()
    {
        isClosed = !isClosed;

        if (isClosed) {
            Close();
        } else {
            Open();
        }

        joint.useMotor = true;
    }
}
