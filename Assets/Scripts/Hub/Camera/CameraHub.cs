using UnityEngine;

public class CameraHub : MonoBehaviour
{
    [SerializeField] private Transform playerPosition;
    [SerializeField] private float offsetZ;

    private void Update()
    {
        transform.position = new Vector3(playerPosition.position.x, playerPosition.position.y, playerPosition.position.z - offsetZ);
    }
}