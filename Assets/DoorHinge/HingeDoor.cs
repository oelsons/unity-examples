using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HingeDoor : MonoBehaviour
{
    [SerializeField] Slider forceSlider;

    HingeJoint hj;

    private void Awake()
    {
        hj = GetComponent<HingeJoint>();

        forceSlider.maxValue = hj.breakForce;
    }

    //float maxForce;
    void FixedUpdate()
    {
        if (hj == null) return;

        //float currentForce = Mathf.Abs(hj.currentForce.x) + Mathf.Abs(hj.currentForce.y) + Mathf.Abs(hj.currentForce.z);
        //float currentForce = MathF.Max(MathF.Max(Mathf.Abs(hj.currentForce.x), Mathf.Abs(hj.currentForce.y)), Mathf.Abs(hj.currentForce.z));
        //if (currentForce > maxForce) {
        //maxForce = currentForce;
        //print(hj.currentForce + " / " + hj.breakForce + " | maxForce: " + maxForce);
        //}

        //print(hj.currentForce + " / " + hj.breakForce);

        forceSlider.value = MathF.Max(MathF.Max(Mathf.Abs(hj.currentForce.x), Mathf.Abs(hj.currentForce.y)), Mathf.Abs(hj.currentForce.z));
    }

    private void OnCollisionEnter(Collision collision)
    {
        //print("Collision impulse: " + collision.impulse + " | fixedDeltaTime: " + Time.fixedDeltaTime + " | " + collision.impulse / Time.fixedDeltaTime);
    }

    private void OnJointBreak(float breakForce)
    {
        forceSlider.value = MathF.Max(MathF.Max(Mathf.Abs(hj.currentForce.x), Mathf.Abs(hj.currentForce.y)), Mathf.Abs(hj.currentForce.z));

        //print("OnJointBreak: " + hj.currentForce + " / " + hj.breakForce + " | maxForce: " + maxForce);
        //print("OnJointBreak: " + hj.currentForce + " / " + hj.breakForce);
        //print("OnJointBreak force: " + breakForce);
    }
}
