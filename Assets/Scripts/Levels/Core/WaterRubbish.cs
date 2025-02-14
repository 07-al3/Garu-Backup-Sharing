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
        yield return new WaitForSeconds(Random.Range(1, 20));
        utility(true);

        yield return new WaitForSeconds(Random.Range(1, 20));
        utility(false);

        StartCoroutine(alternate());
    }

    private void utility(bool flag)
    {
        sprite.sortingOrder = flag ? 3 : 5;
        pos.Translate();
    }
}
