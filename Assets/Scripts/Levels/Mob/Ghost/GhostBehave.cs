using UnityEngine;
using System.Collections;

public class GhostBehave : MonoBehaviour
{
    private int random;

    private void Awake()
    {
        random = Random.Range(1, 11);
        StartCoroutine(waitAndDisable());
    }

    private IEnumerator waitAndDisable()
    {
        yield return new WaitForSeconds(random);
        GetComponent<Animator>().SetTrigger("Attack");
    }

    private void disable()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<Animator>().SetTrigger("Attack");
    }
}
