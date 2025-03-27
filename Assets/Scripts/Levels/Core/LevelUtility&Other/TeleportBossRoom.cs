using UnityEngine;

public class TeleportBossRoom : MonoBehaviour
{
    [SerializeField] private Transform InitialBossRoomPosition;
    [SerializeField] private GameObject bossRoom;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject firstLevelPart;
    [SerializeField] private GameObject playerRespawn;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.Equals("Player"))
        {
            bossRoom.SetActive(true);
            player.transform.position = InitialBossRoomPosition.position;
            firstLevelPart.SetActive(false);
            playerRespawn.GetComponent<RespawnManager>().startingPosition = InitialBossRoomPosition;
            player.GetComponent<PlayerHealth>().lastCheckpoint = InitialBossRoomPosition;
        }
    }
}
