using UnityEngine;

public class TeleportBossRoom : MonoBehaviour
{
    [SerializeField] private Transform InitialBossRoomPosition;
    [SerializeField] private GameObject bossRoom;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject firstLevelPart;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.Equals("Player"))
        {
            bossRoom.SetActive(true);
            player.transform.position = InitialBossRoomPosition.position;
            firstLevelPart.SetActive(false);
        }
    }
}
