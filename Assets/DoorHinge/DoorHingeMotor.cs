using UnityEngine;

public class DoorHingeMotor : MonoBehaviour, IActivatable
{
    [SerializeField] private bool toggle;
    [SerializeField] private float doorSpeed;
    [SerializeField] private float doorForce;

    private HingeJoint joint;

    JointMotor motor = new JointMotor();

    [SerializeField, TextArea] string debug;

    private void Awake()
    {
        joint = GetComponent<HingeJoint>();
    }

    public void Activate()
    {
        toggle = true;

        motor.targetVelocity = -doorSpeed;
        motor.force = doorForce;
        joint.motor = motor;

        joint.useMotor = true;
    }

    public void Deactivate()
    {
        toggle = false;

        motor.targetVelocity = doorSpeed;
        motor.force = doorForce;
        joint.motor = motor;

        joint.useMotor = true;
    }

    private void Update()
    {
        if (!joint.useMotor) return;

        int angle = Mathf.RoundToInt(joint.angle);
        int limitMin = Mathf.RoundToInt(joint.limits.min);
        int limitMax = Mathf.RoundToInt(joint.limits.max);

        joint.useMotor = !((motor.targetVelocity > 0 && angle == limitMax) || (motor.targetVelocity < 0 && angle == limitMin));

        debug = "joint.limits.max: " + limitMax + "\njoint.limits.min: " + limitMin + "\nintAngle: " + angle;
    }

    private void OnJointBreak(float breakForce)
    {
        Destroy(this);
    }

    public bool IsActivated()
    {
        return toggle;
    }
}
