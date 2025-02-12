using UnityEngine;

public class MobRangeAttack : MonoBehaviour
{
    [SerializeField] private float attackCoolDown;
    [SerializeField] private GameObject player;

    private float lastAttack;

    private void Awake()
    {
        lastAttack = 0;
    }

    private void Update()
    {
        lastAttack += Time.deltaTime;
        Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), player.GetComponent<Collider2D>(), lastAttack > attackCoolDown ? false : true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.Equals("Player") && lastAttack > attackCoolDown)
        {
            lastAttack = 0;

            transform.localScale = player.transform.position.x > transform.position.x ? new Vector2(-Mathf.Abs(transform.localScale.x), transform.localScale.y) : transform.localScale;

            GetComponent<Animator>().SetTrigger("Attack");
        }
    }
}
