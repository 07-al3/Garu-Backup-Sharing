using UnityEngine;

public class NewChunkLoader : MonoBehaviour
{
    [SerializeField] private GameObject[] room;
    [SerializeField] private GameObject[] mob;
    [SerializeField] private GameObject[] collectibles;
    [SerializeField] private GameObject[] angles;
    [SerializeField] private GameObject[] decorations;
    [SerializeField] private GameObject[] checkpoints;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag.Equals("Player"))
        {
            foreach(GameObject g in room)
                g.SetActive(true);
            foreach(GameObject g in mob)
                g.SetActive(true);
            foreach(GameObject g in collectibles)
                g.SetActive(true);
            foreach(GameObject g in angles)
                g.SetActive(true);
            foreach(GameObject g in decorations)
                g.SetActive(true);
            foreach(GameObject g in checkpoints)
                g.SetActive(true);
        }
    }
}
