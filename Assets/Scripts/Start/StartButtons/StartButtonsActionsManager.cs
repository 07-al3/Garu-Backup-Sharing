using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonsActionsManager : MonoBehaviour
{
    [SerializeField] private GameObject volumeScreen;

    public void startGame()
    {
        SceneManager.LoadScene(1);
    }

    public void quitGame()
    {
        Application.Quit();

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    public void volume()
    {
        volumeScreen.SetActive(!volumeScreen.activeInHierarchy);
    }
}