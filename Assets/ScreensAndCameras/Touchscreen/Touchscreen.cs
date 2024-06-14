using UnityEngine;
using UnityEngine.UI;

public class Touchscreen : MonoBehaviour
{
    [SerializeField] Button yesButton;
    [SerializeField] Button noButton;
    [SerializeField] Image image;

    void Start()
    {
        yesButton.onClick.AddListener(ClickYes);
        noButton.onClick.AddListener(ClickNo);
    }

    private void ClickYes()
    {
        image.color = Color.green;
    }

    private void ClickNo()
    {
        image.color = Color.red;
    }

    private void OnDestroy()
    {
        yesButton.onClick.RemoveAllListeners();
        noButton.onClick.RemoveAllListeners();
    }
}
