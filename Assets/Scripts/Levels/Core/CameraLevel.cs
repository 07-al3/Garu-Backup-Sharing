using UnityEngine;

public class CameraLevel : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField] private Transform player;

    private float lookAhead;
    private const float cameraSpeed = 0.8f;

    private void Update()
    {
        transform.position = new Vector3(player.position.x + lookAhead, player.position.y + offset.y, player.position.z - offset.z);
        lookAhead = Mathf.Lerp(lookAhead, offset.x * player.localScale.x, Time.deltaTime * cameraSpeed);
    }
}
