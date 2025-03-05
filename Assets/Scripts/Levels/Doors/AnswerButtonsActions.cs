using UnityEngine;

public class AnswerButtonsActions : MonoBehaviour
{
    [Header("Sprite And Lever")]
    [SerializeField] private GameObject doorOpen;
    [SerializeField] private GameObject lever;

    [Header("Player and Positions")]
    [SerializeField] private GameObject player;
    [SerializeField] private Transform startPosition;

    [Header("Door e Q&A")]
    [SerializeField] private GameObject door;
    [SerializeField] private GameObject questionCanvas;
    
    public void wrong()
    {
        PlayerHealth healthRef = player.GetComponent<PlayerHealth>();
        questionCanvas.SetActive(false);
        Time.timeScale = 1;
        player.GetComponent<BehavioursSetter>().setActive(true);

        player.transform.position = healthRef.lastCheckpoint != null ? new Vector2(healthRef.lastCheckpoint.position.x, healthRef.lastCheckpoint.position.y) : new Vector2(startPosition.position.x, startPosition.position.y);
    
        player.GetComponent<PlayerAttack>().enabled = false;
    }

    public void correct()
    {
        questionCanvas.SetActive(false);
        Time.timeScale = 1;
        player.GetComponent<BehavioursSetter>().setActive(true);

        door.SetActive(false);;
        door.GetComponent<BoxCollider2D>().enabled = false;

        doorOpen.SetActive(true);

        lever.SetActive(false);

        player.GetComponent<PlayerAttack>().enabled = false;
    }
}
