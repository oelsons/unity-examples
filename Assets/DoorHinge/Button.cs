using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] GameObject activatableGameObject;

    private IActivatable activatable;
    private bool inTrigger = false;

    private void Awake()
    {
        if (!activatableGameObject.TryGetComponent(out activatable)) {
            Debug.LogError("Attached GameObject is not IActivatable");
        }
    }

    private void Update()
    {
        if (inTrigger && Input.GetKeyDown(KeyCode.E)) {
            if (activatable.Equals(null)) return;

            if (activatable.IsActivated()) {
                activatable.Deactivate();
            } else {
                activatable.Activate();
            }
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
