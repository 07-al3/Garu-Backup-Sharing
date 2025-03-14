using System.Collections;
using UnityEngine;

public class TornadoBehav : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject cameraLevel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            player.SetActive(false);
            cameraLevel.GetComponent<CameraHub>().playerPosition = gameObject.transform;
            StartCoroutine(waitAndReinable(true));
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    private IEnumerator waitAndReinable(bool flag)
    {
        yield return new WaitForSeconds(3);
        if(flag)
        {
            player.SetActive(true);
            cameraLevel.GetComponent<CameraHub>().playerPosition = player.transform;
            StartCoroutine(waitAndReinable(false));
        }
        else
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }
}