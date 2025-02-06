using UnityEngine;

public class OldChunkDisabler : MonoBehaviour
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
                g.SetActive(false);
            foreach(GameObject g in mob)
                g.SetActive(false);
            foreach(GameObject g in collectibles)
                g.SetActive(false);
            foreach(GameObject g in angles)
                g.SetActive(false);
            foreach(GameObject g in decorations)
                g.SetActive(false);
            foreach(GameObject g in checkpoints)
                g.SetActive(false);
        }
    }
}
