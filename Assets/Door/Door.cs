using UnityEngine;

public class Door : MonoBehaviour, IActivatable
{
    [SerializeField] float doorSpeed = 5f;
    [SerializeField] Vector3 openRotation;
    [SerializeField] Vector3 closeRotation;

    private bool isMoving = false;
    private bool isOpen = false;
    private float timeCount = 0f;
    private Quaternion fromRotation = Quaternion.identity;
    private Quaternion toRotation = Quaternion.identity;

    private void Update()
    {
        if (!isMoving) return;

        transform.rotation = Quaternion.Lerp(fromRotation, toRotation, timeCount * doorSpeed);
        timeCount += Time.deltaTime;

        if (transform.rotation == toRotation) isMoving = false;
    }

    private void Open()
    {
        isOpen = true;
        toRotation = Quaternion.Euler(openRotation);
    }

    private void Close()
    {
        isOpen = false;
        toRotation = Quaternion.Euler(closeRotation);
    }

    private void OnJointBreak(float breakForce)
    {
        Destroy(this);
    }

    public void Activate()
    {
        fromRotation = transform.rotation;
        timeCount = 0f;
        isMoving = true;

        if (isOpen) {
            Close();
        } else {
            Open();
        }
    }
}
