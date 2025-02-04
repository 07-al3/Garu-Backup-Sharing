using UnityEngine;

public class HubButtonsActionsManager : MonoBehaviour
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

    public void quitHub()
    {
        Time.timeScale = 1;
        
        Application.Quit();

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}