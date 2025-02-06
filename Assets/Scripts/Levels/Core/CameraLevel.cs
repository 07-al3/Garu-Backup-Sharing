using UnityEngine;

public class CameraLevel : MonoBehaviour
{
    [SerializeField] private Vector3 offset;

    private float lookAhead;
    private float cameraSpeed = 0.8f;
    private Transform playerPosition;

    private void Awake()
    {
        playerPosition = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        transform.position = new Vector3(playerPosition.position.x + lookAhead, playerPosition.position.y + offset.y, playerPosition.position.z - offset.z);
        lookAhead = Mathf.Lerp(lookAhead, offset.x * playerPosition.localScale.x, Time.deltaTime * cameraSpeed);
    }
}
