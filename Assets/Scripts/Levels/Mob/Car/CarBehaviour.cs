using UnityEngine;
using System.Collections;

public class CarBehaviour : MonoBehaviour
{
    [SerializeField] private Sprite attackSprite;
    private BoxCollider2D coll;
    private int random;
    private Sprite oldSprite;
    private float time;
    private Vector2 oldDim;

    private void Awake()
    {
        oldSprite =  GetComponent<SpriteRenderer>().sprite;   
        coll = GetComponentInChildren<BoxCollider2D>();     
        oldDim = coll.size;
        random = Random.Range(5, 11);
        StartCoroutine(waitAndAttack());
    }

    private void Update()
    {
        time += Time.deltaTime;
        if(time < 5)
            GetComponent<SpriteRenderer>().sprite = attackSprite;
        else
            GetComponent<SpriteRenderer>().sprite = oldSprite;
    }

    private IEnumerator waitAndAttack()
    {
        yield return new WaitForSeconds(random);
        time = 0;

        GetComponentInChildren<Animator>().SetTrigger("Activate");
        coll.size = new Vector2(0.6f, 0.25f);
        StartCoroutine(waitAndReduce());
        yield return new WaitForSeconds(1);

        StartCoroutine(waitAndAttack());
    }

    private IEnumerator waitAndReduce()
    {
        yield return new WaitForSeconds(2);
        coll.size = oldDim;
    }
}
