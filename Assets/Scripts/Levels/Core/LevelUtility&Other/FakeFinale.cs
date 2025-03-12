using UnityEngine;

public class FakeFinale : MonoBehaviour
{
    [SerializeField] private GameObject portal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.Equals("Player"))
        {
            portal.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
