using UnityEngine;

public class SideBossPortal : MonoBehaviour
{
    [SerializeField] private Transform otherPortal;
    [SerializeField] private GameObject player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag.Equals("Player"))
            player.transform.position = otherPortal.position;
    }
}
