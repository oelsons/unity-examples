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

    [SerializeField] HingeJoint joint;
    [SerializeField] bool isLocked = false;
    [SerializeField] float lockSpring;

    HingeConfig hc = new HingeConfig();

    JointLimits lockLimits = new JointLimits();

    void Start()
    {
        hc.limits = joint.limits;
        hc.useSpring = joint.useSpring;
        hc.spring = joint.spring;

        hc.lockSpring.spring = lockSpring;

        if (isLocked) {
            Lock();
        } else {
            Unlock();
        }
    }

    public void Activate()
    {
        isLocked = !isLocked;

        if (isLocked) {
            Lock();
        } else {
            Unlock();
        }
    }

    private void Unlock()
    {
        print(hc.limits.min);
        joint.limits = hc.limits;
        joint.useSpring = hc.useSpring;
        joint.spring = hc.spring;
    }

    private void Lock()
    {
        joint.useSpring = true;
        
        lockLimits.min = joint.angle - 1;
        lockLimits.max = joint.angle + 1;
        joint.limits = lockLimits;

        joint.spring = hc.lockSpring;
    }

    private void OnJointBreak(float breakForce)
    {
        Destroy(this);
    }
}
