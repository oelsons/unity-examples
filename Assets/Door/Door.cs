using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private List<Button> buttonList;
    [SerializeField] float doorSpeed = 5f;

    private bool isOpen = false;
    private Quaternion rotation = Quaternion.identity;

    private void Start()
    {
        foreach (Button button in buttonList) {
            button.OnTrigger += Button_OnTrigger;
        }
    }

    private void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, doorSpeed * Time.deltaTime);
    }

    private void Button_OnTrigger(object sender, System.EventArgs e)
    {
        if (isOpen) {
            Close();
        } else {
            Open();
        }
    }

    private void Open()
    {
        isOpen = true;
        rotation = Quaternion.Euler(0, -90, 0);
    }

    private void Close()
    {
        isOpen = false;
        rotation = Quaternion.Euler(0, 0, 0);
    }

    private void OnDestroy()
    {
        foreach (Button button in buttonList) {
            button.OnTrigger -= Button_OnTrigger;
        }
    }
}
