using UnityEngine;

public class AnswerButtonsActions : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Transform startPosition;
    [SerializeField] private GameObject door;
    [SerializeField] private GameObject questionCanvas;

    public void wrong()
    {
        PlayerHealth healthRef = player.GetComponent<PlayerHealth>();
        questionCanvas.SetActive(false);
        Time.timeScale = 1;
        player.GetComponent<BehavioursSetter>().setActive(true);

        player.transform.position = healthRef.lastCheckpoint != null ? new Vector2(healthRef.lastCheckpoint.position.x, healthRef.lastCheckpoint.position.y) : new Vector2(startPosition.position.x, startPosition.position.y);
    }

    public void correct()
    {
        questionCanvas.SetActive(false);
        Time.timeScale = 1;
        player.GetComponent<BehavioursSetter>().setActive(true);
        door.SetActive(false);
    }
}
