using UnityEngine;
using System.Collections;

public class WaterRubbish : MonoBehaviour
{
    private SpriteRenderer sprite;
    private Transform pos;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        pos = GetComponent<Transform>();
        StartCoroutine(alternate());
    }

    private IEnumerator alternate()
    {
        yield return new WaitForSeconds(random());
        utility(true);

        yield return new WaitForSeconds(random());
        utility(false);

        StartCoroutine(alternate());
    }

    private void utility(bool flag)
    {
        sprite.sortingOrder = flag ? 3 : 5;
    }

    private int random()
    {
        return Random.Range(1, 10);
    }
}
