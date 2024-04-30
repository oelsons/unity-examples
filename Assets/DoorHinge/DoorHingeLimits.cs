using UnityEngine;

public class DoorHingeLimits : MonoBehaviour, IActivatable
{
    [SerializeField] private bool isOpen;
    [SerializeField] float doorSpeed = 5f;

    private HingeJoint joint;

    private bool isMoving = false;

    private JointLimits origLimits = new JointLimits();
    private JointLimits moveLimits = new JointLimits();

    private void Awake()
    {
        joint = GetComponent<HingeJoint>();

        origLimits = joint.limits;
    }

    private void Update()
    {
        if (!isMoving) return;

        if (isOpen) {
            moveLimits.max -= Time.deltaTime * doorSpeed;
            moveLimits.min = moveLimits.max - 1;
        } else {
            moveLimits.min += Time.deltaTime * doorSpeed;
            moveLimits.max = moveLimits.min + 1;
        }

        joint.limits = moveLimits;

        if (moveLimits.max <= origLimits.min || moveLimits.min >= origLimits.max) {
            joint.limits = origLimits;
            isMoving = false;
        }
    }

    public void Activate()
    {
        isOpen = true;
        isMoving = true;
        moveLimits = joint.limits;
        moveLimits.max = joint.angle;
    }

    public void Deactivate()
    {
        isOpen = false;
        isMoving = true;
        moveLimits = joint.limits;
        moveLimits.min = joint.angle;
    }

    public bool IsActivated()
    {
        return isOpen;
    }
}
