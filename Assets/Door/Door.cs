using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private List<Button> buttonList;
    [SerializeField] float doorSpeed = 5f;

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
        transform.rotation = Quaternion.Lerp(fromRotation, toRotation, timeCount * doorSpeed);
        timeCount += Time.deltaTime;
    }

    private void Button_OnTrigger(object sender, System.EventArgs e)
    {
        fromRotation = transform.rotation;
        timeCount = 0f;

        if (isOpen) {
            Close();
        } else {
            Open();
        }
    }

    private void Open()
    {
        isOpen = true;
        toRotation = Quaternion.Euler(0, -90, 0);
    }

    private void Close()
    {
        isOpen = false;
        toRotation = Quaternion.Euler(0, 0, 0);
    }

    private void OnDestroy()
    {
        foreach (Button button in buttonList) {
            button.OnTrigger -= Button_OnTrigger;
        }
    }
}
