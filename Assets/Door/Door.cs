using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private List<Button> buttonList;
    [SerializeField] float doorSpeed = 5f;
    [SerializeField] Vector3 openRotation;
    [SerializeField] Vector3 closeRotation;

    private bool isMoving = false;
    private bool isOpen = false;
    private float timeCount = 0f;
    private Quaternion fromRotation = Quaternion.identity;
    private Quaternion toRotation = Quaternion.identity;

    private void Start()
    {
        foreach (Button button in buttonList) {
            button.OnTrigger += Button_OnTrigger;
        }
    }

    private void Update()
    {
        if (!isMoving) return;

        transform.rotation = Quaternion.Lerp(fromRotation, toRotation, timeCount * doorSpeed);
        timeCount += Time.deltaTime;

        if (transform.rotation == toRotation) isMoving = false;
    }

    private void Button_OnTrigger(object sender, System.EventArgs e)
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

    private void OnDestroy()
    {
        foreach (Button button in buttonList) {
            button.OnTrigger -= Button_OnTrigger;
        }
    }
}
