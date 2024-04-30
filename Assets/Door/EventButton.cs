using System;
using UnityEngine;

public class EventButton : MonoBehaviour
{
    public event EventHandler OnTrigger;

    private bool inTrigger = false;

    private void Update()
    {
        if (inTrigger && Input.GetKeyDown(KeyCode.E)) {
            OnTrigger?.Invoke(this, EventArgs.Empty);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        inTrigger = true;
    }

    private void OnTriggerExit(Collider other)
    {
        inTrigger = false;
    }
}
