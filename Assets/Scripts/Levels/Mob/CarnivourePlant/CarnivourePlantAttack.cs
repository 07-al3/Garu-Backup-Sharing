using UnityEngine;
using System.Collections;

public class CarnivourePlantAttack : MonoBehaviour
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
            GetComponent<Animator>().SetTrigger("Attack");

            collision.GetComponent<BehavioursSetter>().setActive(false);
            collision.gameObject.SetActive(false);

            StartCoroutine(waitAndStartAgain(2, collision.gameObject));
        }
    }

    private IEnumerator waitAndStartAgain(float time, GameObject g)
    {
        yield return new WaitForSeconds(time);
        g.SetActive(true);
        g.GetComponent<BehavioursSetter>().setActive(true);
    }
}
