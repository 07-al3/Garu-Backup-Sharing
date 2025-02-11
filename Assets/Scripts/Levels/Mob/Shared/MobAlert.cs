using UnityEngine;

public class MobAlert : MonoBehaviour
{
    [SerializeField] private GameObject otherAl;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag.Equals("Player"))
        {
            GetComponentInParent<Animator>().SetTrigger("Discover");
            gameObject.SetActive(false);
            otherAl.gameObject.SetActive(false);
        }
    }
}
