using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonsActionsManager : MonoBehaviour
{
    [SerializeField] private GameObject volumeScreen;
    [SerializeField] private GameObject creditsButton;
    [SerializeField] private GameObject main;
    [SerializeField] private GameObject trama;

    public void continueGame()
    {
        int val = PlayerPrefs.GetInt("EarthLev", 10);

        if(val == 10)
            newGame();

        SceneManager.LoadScene(1);
    }

    public void newGame()
    {
        PlayerPrefs.SetInt("EarthLev", 0);
        PlayerPrefs.SetInt("WaterLevl", 0);
        PlayerPrefs.SetInt("FireLev", 0);
        PlayerPrefs.SetInt("WindLev", 0);
        
        PlayerPrefs.Save();

        trama.SetActive(true);
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