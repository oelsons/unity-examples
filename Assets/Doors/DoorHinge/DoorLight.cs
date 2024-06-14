using UnityEngine;

public class DoorLight : MonoBehaviour
{
    [SerializeField] private Light doorLight;
    [SerializeField] private HingeLock hingeLock;
    [SerializeField] private Color openColor;
    [SerializeField] private Color closeColor;


    void Update()
    {
        if (hingeLock == null) {
            Destroy(this);
            return;
        }
        doorLight.color = hingeLock.IsActivated() ? closeColor : openColor;
    }
}
