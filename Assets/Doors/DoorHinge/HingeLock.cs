using UnityEngine;

public class HingeLock : MonoBehaviour, IActivatable
{
    private class HingeConfig
    {
        public JointLimits limits;
        public bool useSpring;
        public JointSpring spring;

        public JointSpring lockSpring = new JointSpring();
    }

    [SerializeField] private HingeJoint joint;
    [SerializeReference] private bool isLocked;
    [SerializeField] private float lockSpring;

    HingeConfig hc = new HingeConfig();

    JointLimits lockLimits = new JointLimits();

    void Start()
    {
        hc.limits = joint.limits;
        hc.useSpring = joint.useSpring;
        hc.spring = joint.spring;

        hc.lockSpring.spring = lockSpring;

        if (isLocked) {
            Activate();
        } else {
            Deactivate();
        }
    }

    private void Update()
    {
        if (joint == null) Destroy(this);
    }

    public void Activate()
    {
        isLocked = true;

        joint.useSpring = true;

        lockLimits.min = joint.angle - 1;
        lockLimits.max = joint.angle + 1;
        joint.limits = lockLimits;

        joint.spring = hc.lockSpring;
    }

    public void Deactivate()
    {
        isLocked = false;

        joint.limits = hc.limits;
        joint.useSpring = hc.useSpring;
        joint.spring = hc.spring;
    }

    public bool IsActivated()
    {
        return isLocked;
    }
}
