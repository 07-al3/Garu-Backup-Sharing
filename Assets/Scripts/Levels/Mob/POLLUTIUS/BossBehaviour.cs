using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Unity.VisualScripting;

public class BossBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject bossHealthBar;
    [SerializeField] private GameObject bossHealthTotal;
    [SerializeField] private GameObject trophy;
    [SerializeField] private BoxCollider2D[] attack1Collider;
    [SerializeField] private BoxCollider2D attack2Collider;
    [SerializeField] private Transform finalePosition;
    [SerializeField] private float health;


    private Animator anim;
    private bool firstTime;

    private void Awake()
    {
        foreach(BoxCollider2D b in attack1Collider)
            b.enabled = false;

        attack2Collider.enabled = false;

        anim = GetComponent<Animator>();
        firstTime = true;

        StartCoroutine(waitAndActivate());
        StartCoroutine(waitAndStartAttacking());
    }

    private IEnumerator waitAndActivate()
    {
        yield return new WaitForSeconds(3.5f);
        anim.SetTrigger("Activate");

        bossHealthBar.SetActive(true);
        bossHealthTotal.SetActive(true);
    }

    private IEnumerator waitAndStartAttacking()
    {
        yield return new WaitForSeconds(firstTime ? 5 : 0);

        int rand = Random.Range(0, 2);
        anim.SetTrigger(rand == 0 ? "Attack1" : "Attack2");

        if(rand == 0)
            transform.localScale = player.transform.position.x > transform.position.x ? new Vector2(-Mathf.Abs(transform.localScale.x), transform.localScale.y) : new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);

        yield return new WaitForSeconds(Random.Range(0, 4) + (rand == 0 ? 3 : 5));

        firstTime = false;
        StartCoroutine(waitAndStartAttacking());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Projectile")
        {
            bossHealthBar.GetComponent<Image>().fillAmount -= 0.033f;
            health -= (float)collision.GetComponent<Variables>().declarations.Get("DamageValue");
            if(health < 0.1f)
                anim.SetTrigger("Die");
        }
    }

    private IEnumerator waitAndDisable(BoxCollider2D c)
    {
        yield return new WaitForSeconds(0.5f);
        c.enabled = false;
    }

    private void OnDisable()
    {
        bossHealthBar.GetComponent<Image>().fillAmount = 0;
        trophy.SetActive(true);
        player.transform.position = new Vector2(finalePosition.position.x, finalePosition.position.y);
    }

    private void attack1()
    {
        attack1Collider[transform.localScale.x == Mathf.Abs(transform.localScale.x) ? 1 : 0].enabled = true;
        StartCoroutine(waitAndDisable(attack1Collider[transform.localScale.x == Mathf.Abs(transform.localScale.x) ? 1 : 0]));
    }

    private void attack2()
    {
        attack2Collider.enabled = true;
        StartCoroutine(waitAndDisable(attack2Collider));
    }

    private void disableObject()
    {
        gameObject.SetActive(false);
    }
}
