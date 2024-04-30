using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Button resetButton;
    [SerializeField] UnityEngine.UI.Button quitButton;

    private void Awake()
    {
        resetButton.onClick.AddListener(ResetScene);
        quitButton.onClick.AddListener(Quit);
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void Quit()
    {
        Application.Quit();
    }

    private void OnDestroy()
    {
        resetButton.onClick.RemoveAllListeners();
    }
}
