using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButtonsActionsManager : MonoBehaviour
{
    [SerializeField] GameObject parentObject;
    [SerializeField] GameObject volumeScreen;

    public void volume()
    {
        volumeScreen.SetActive(!volumeScreen.activeInHierarchy);
    }

    public void resume()
    {
        GetComponent<BehavioursSetter>().setActive(true);
        Time.timeScale = 1;
        parentObject.SetActive(false);
    }

    public void quitLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
}
