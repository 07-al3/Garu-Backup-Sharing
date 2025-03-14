using UnityEngine;
using System.Collections;

public class CarBehaviour : MonoBehaviour
{
    [SerializeField] private Sprite attackSprite;
    [SerializeField] private GameObject child;

    private Sprite oldSprite;
    private int random;
    private float time;
    private Vector2 oldDim;

    private void Awake()
    {
        oldSprite =  GetComponent<SpriteRenderer>().sprite;        
        oldDim = child.GetComponentInChildren<BoxCollider2D>().size;
        random = Random.Range(5, 11);
        StartCoroutine(waitAndAttack());
    }

    private void Update()
    {
        time += Time.deltaTime;
        if(time > (random - 1.5))
            GetComponent<SpriteRenderer>().sprite = attackSprite;
        else
            GetComponent<SpriteRenderer>().sprite = oldSprite;
    }

    private IEnumerator waitAndAttack()
    {
        time = 0;
        yield return new WaitForSeconds(random);
        time = 0;

        child.GetComponentInChildren<Animator>().SetTrigger("Activate");
        yield return new WaitForSeconds(1);
        time = 0;

        child.GetComponentInChildren<BoxCollider2D>().size = new Vector2(0.6f, 0.25f);
        StartCoroutine(waitAndReduce());
        time = 0;

        yield return new WaitForSeconds(2);

        StartCoroutine(waitAndAttack());
    }

    private IEnumerator waitAndReduce()
    {
        yield return new WaitForSeconds(1.5f);
        child.GetComponentInChildren<BoxCollider2D>().size = oldDim;
    }
}