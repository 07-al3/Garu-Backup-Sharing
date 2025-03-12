using UnityEngine;

public class ChangeMovement : MonoBehaviour
{
    [SerializeField] private GameObject hubPlayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.Equals("Player"))
        {
            gameObject.SetActive(false);
            hubPlayer.SetActive(true);
        }
    }
}
