using UnityEngine;
using System.Collections;

public class SideBossPortal : MonoBehaviour
{
    [SerializeField] private Transform otherPortal;
    [SerializeField] private GameObject player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag.Equals("Player"))
        {
            player.transform.position = otherPortal.position;
            StartCoroutine(resetColl());
        }
    }

    private IEnumerator resetColl()
    {
        GetComponent<PolygonCollider2D>().enabled = false;
        yield return new WaitForSeconds(2);
        GetComponent<PolygonCollider2D>().enabled = true;
    }
}
