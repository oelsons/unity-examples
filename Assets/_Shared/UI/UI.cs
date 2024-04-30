using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Button resetButton;

    private void Awake()
    {
        resetButton.onClick.AddListener(ResetScene);
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnDestroy()
    {
        resetButton.onClick.RemoveAllListeners();
    }
}
