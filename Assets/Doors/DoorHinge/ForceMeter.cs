using System;
using UnityEngine;
using UnityEngine.UI;

public class ForceMeter : MonoBehaviour
{
    [SerializeField] Slider forceSlider;

    HingeJoint hj;

    private void Awake()
    {
        hj = GetComponent<HingeJoint>();

        forceSlider.maxValue = hj.breakForce;
    }

    void FixedUpdate()
    {
        if (hj == null) return;

        forceSlider.value = MathF.Max(MathF.Max(Mathf.Abs(hj.currentForce.x), Mathf.Abs(hj.currentForce.y)), Mathf.Abs(hj.currentForce.z));
    }

    private void OnJointBreak(float breakForce)
    {
        forceSlider.value = MathF.Max(MathF.Max(Mathf.Abs(hj.currentForce.x), Mathf.Abs(hj.currentForce.y)), Mathf.Abs(hj.currentForce.z));
    }
}
