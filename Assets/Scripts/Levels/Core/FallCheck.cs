using UnityEngine;

public class FallCheck : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag.Equals("Player"))
            other.GetComponent<PlayerHealth>().dead = true;
    }
}
