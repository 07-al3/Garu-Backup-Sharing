using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class RespawnManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Transform startingPosition;
    [SerializeField] private GameObject deadCanvas;
    [SerializeField] private Image playerHealth;
    [SerializeField] private Image playerShield;

    private Rigidbody2D playerBody;
    private PlayerHealth playerHealthScript;
    private BehavioursSetter playerBehaviours;

    private void Awake()
    {
        playerBody = player.GetComponent<Rigidbody2D>();
        playerHealthScript = player.GetComponent<PlayerHealth>();
        playerBehaviours = player.GetComponent<BehavioursSetter>();
    }

    public void OnClick()
    {
        playerHealthScript.dead = false;
            
        playerBody.gravityScale = 1;

        playerHealth.fillAmount = 1;
        playerShield.fillAmount = 1;

        playerBehaviours.setActive(true);

        player.transform.position = playerHealthScript.lastCheckpoint != null ? new Vector2(playerHealthScript.lastCheckpoint.position.x, playerHealthScript.lastCheckpoint.position.y) : new Vector2(startingPosition.position.x, startingPosition.position.y);

        deadCanvas.SetActive(false);

        player.GetComponent<Animator>().Play("Standing");
    }
}