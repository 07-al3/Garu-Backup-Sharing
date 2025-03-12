using UnityEngine;

public class StartingPosition : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private void Awake()
    {
        player.transform.position = transform.position;
        gameObject.SetActive(false);
    }
}
