using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] GameObject activatableGameObject;

    private IActivatable activatable;
    private bool inTrigger = false;

    private void Awake()
    {
        activatable = activatableGameObject.GetComponent<IActivatable>();
        if (activatable == null) {
            Debug.LogError("Attached GameObject is not IActivatable");
        }
    }

    private void Update()
    {
        if (inTrigger && Input.GetKeyDown(KeyCode.E)) {
            if (activatable == null) return;
            activatable.Activate();
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
