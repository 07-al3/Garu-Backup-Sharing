using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BossBehaviour : MonoBehaviour
{
    [SerializeField] private Image bossHealthBar;
    [SerializeField] private Image bossHealthTotal;

    private Animator anim;
    private bool firstTime;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        firstTime = true;

        StartCoroutine(waitAndActivate());
        StartCoroutine(waitAndStartAttacking());
    }

    private IEnumerator waitAndActivate()
    {
        yield return new WaitForSeconds(3.5f);
        anim.SetTrigger("Activate");
        bossHealthTotal.enabled = true;
        bossHealthBar.enabled = true;
    }

    private IEnumerator waitAndStartAttacking()
    {
        yield return new WaitForSeconds(firstTime ? 5 : 0);

        int rand = Random.Range(0, 1);
        anim.SetTrigger(rand == 0 ? "Attack1" : "Attack2");

        yield return new WaitForSeconds(Random.Range(0, 6) + 4);

        firstTime = false;
        waitAndStartAttacking();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Projectile")
            bossHealthBar.fillAmount -= 0.033f;
    }
}
