using UnityEngine;

public class WindLevChange : MonoBehaviour
{
    [SerializeField] private RuntimeAnimatorController newAnim;
    [SerializeField] private Behaviour toSetOff;
    [SerializeField] private Behaviour toSetOn;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.Equals("Player"))
        {
            GetComponent<Animator>().runtimeAnimatorController = newAnim;
            toSetOff.enabled = false;
            toSetOn.enabled = true;
            GetComponent<Rigidbody2D>().gravityScale = 0;
        }
    }
}
