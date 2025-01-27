using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] GameObject pauseCanvas;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            Time.timeScale = 0;
            pauseCanvas.SetActive(true);
            GetComponent<BehavioursSetter>().setActive(false);
        }
    }
}
