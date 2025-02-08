using UnityEngine;

public class NewChunkLoader : MonoBehaviour
{
    [SerializeField] private GameObject[] room;
    [SerializeField] private GameObject[] mob;
    [SerializeField] private GameObject[] collectibles;
    [SerializeField] private GameObject[] angles;
    [SerializeField] private GameObject[] decorations;
    [SerializeField] private GameObject[] checkpoints;

    private void Awake()
    {
        set(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag.Equals("Player"))
            set(true);
    }

    private void set(bool status)
    {
        foreach(GameObject g in room)
            g.SetActive(status);
        foreach(GameObject g in mob)
            g.SetActive(status);
        foreach(GameObject g in collectibles)
            g.SetActive(status);
        foreach(GameObject g in angles)
            g.SetActive(status);
        foreach(GameObject g in decorations)
            g.SetActive(status);
        foreach(GameObject g in checkpoints)
            g.SetActive(status);
    }
}
