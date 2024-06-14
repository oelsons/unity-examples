using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CCTVMonitor : MonoBehaviour
{
    [SerializeField] List<GameObject> cameras = new List<GameObject>();
    [SerializeField] Vector2 cameraResolution;

    [SerializeField] GameObject cameraButtonTemplate;
    [SerializeField] GameObject CCTVMenuPanel;
    [SerializeField] GameObject CCTVPanel;

    void Start()
    {
        int camNumber = 0;

        foreach (GameObject camGO in cameras) {
            Camera cam = camGO.GetComponentInChildren<Camera>();
            cam.targetTexture = new RenderTexture((int)cameraResolution.x, (int)cameraResolution.y, 32);

            GameObject cameraButton = Instantiate(cameraButtonTemplate, CCTVMenuPanel.transform);

            Image cameraImage = cameraButton.GetComponent<Image>();
            cameraImage.material = new Material(cameraButtonTemplate.GetComponent<Image>().material);
            cameraImage.material.mainTexture = cam.targetTexture;

            TMP_Text text = cameraButton.GetComponentInChildren<TMP_Text>();
            text.text = "CAM " + ++camNumber;

            Button button = cameraButton.GetComponent<Button>();
            button.name = text.text;
            button.onClick.AddListener(() => {
                ClickCCTVCamera(button, cameraImage.material);
            });

            cameraButton.SetActive(true);
        }

        CCTVPanel.GetComponentInChildren<Button>().onClick.AddListener(() => {
            CCTVPanel.SetActive(false);
            CCTVMenuPanel.SetActive(true);
        });
    }

    private void ClickCCTVCamera(Button button, Material material)
    {
        print("CCTV: " + button.name);

        CCTVPanel.GetComponent<Image>().material = material;

        CCTVMenuPanel.SetActive(false);
        CCTVPanel.SetActive(true);
    }
}
