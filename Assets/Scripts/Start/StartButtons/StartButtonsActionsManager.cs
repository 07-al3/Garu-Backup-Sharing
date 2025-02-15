using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonsActionsManager : MonoBehaviour
{
    [SerializeField] private GameObject volumeScreen;
    [SerializeField] private GameObject creditsButton;
    [SerializeField] private GameObject main;

    public void continueGame()
    {
        SceneManager.LoadScene(1);
    }

    public void newGame()
    {
        PlayerPrefs.SetInt("EarthLev", 0);
        PlayerPrefs.SetInt("WaterLev", 0);
        PlayerPrefs.SetInt("FireLev", 0);
        PlayerPrefs.SetInt("WindLev", 0);
        
        PlayerPrefs.Save();

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

    public void credits()
    {
        creditsButton.SetActive(!creditsButton.activeInHierarchy);
        main.SetActive(!main.activeInHierarchy);
    }
}