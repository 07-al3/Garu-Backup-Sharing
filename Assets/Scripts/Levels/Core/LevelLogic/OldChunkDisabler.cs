using UnityEngine;
using System.Collections;

public class OldChunkDisabler : MonoBehaviour
{
    [SerializeField] private GameObject[] room;
    [SerializeField] private GameObject[] mob;
    [SerializeField] private GameObject[] collectibles;
    [SerializeField] private GameObject[] angles;
    [SerializeField] private GameObject[] decorations;
    [SerializeField] private GameObject[] checkpoints;
    [SerializeField] private float delay;

    private bool trovato;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag.Equals("Player"))
            search(other);
    }

    private void search(Collider2D other)
    {
        trovato = setTrovato(other);

        if(other.tag.Equals("Player") && !trovato)
            set();
        else
            StartCoroutine(WaitAndRetry(other));
    }

    private bool setTrovato(Collider2D other)
    {
        GameObject lastCheck = other.GetComponent<PlayerHealth>().lastCheckpoint.gameObject;
        trovato = false;

        foreach(GameObject g in checkpoints)
        {
            if(g == lastCheck)
                return true;
        }
        return false;
    }

    private IEnumerator WaitAndRetry(Collider2D other)
    {
        yield return new WaitForSeconds(delay);
        search(other);
    }

    private void set()
    {
        foreach(GameObject g in room)
            g.SetActive(!g.activeInHierarchy);
        foreach(GameObject g in mob)
            g.SetActive(!g.activeInHierarchy);
        foreach(GameObject g in collectibles)
            g.SetActive(!g.activeInHierarchy);
        foreach(GameObject g in angles)
            g.SetActive(!g.activeInHierarchy);
        foreach(GameObject g in decorations)
            g.SetActive(!g.activeInHierarchy);
        foreach(GameObject g in checkpoints)
            g.SetActive(!g.activeInHierarchy);
    }
}
