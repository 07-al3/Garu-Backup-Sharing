using UnityEngine;

public class RemoveCtrlImg : MonoBehaviour
{
    [SerializeField] private GameObject controlsCanvas;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject playerHealthShield;
    [SerializeField] private Transform startingPosition;

    private void OnTriggerEnter2D (Collider2D other)
    {
        if(other.tag.Equals("Player"))
        {
            controlsCanvas.SetActive(false);
            player.transform.position = new Vector2(startingPosition.position.x, startingPosition.position.y);
            playerHealthShield.SetActive(true);
            startingPosition.gameObject.SetActive(false);
        }
    }
}
