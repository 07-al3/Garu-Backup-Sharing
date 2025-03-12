using UnityEngine;

public class ChangeMovement : MonoBehaviour
{
    [SerializeField] private RuntimeAnimatorController animToChange;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.Equals("Player"))
        {
            collision.GetComponent<Animator>().runtimeAnimatorController = animToChange;
            collision.GetComponent<HubMovement>().enabled = true;
            collision.GetComponent<PlayerMovement>().enabled = false;
            collision.GetComponent<Rigidbody2D>().gravityScale = 0;
        }
    }
}
