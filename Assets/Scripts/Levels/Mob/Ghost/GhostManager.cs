using UnityEngine;

public class GhostManager : MonoBehaviour
{
    [SerializeField] private GameObject[] ghosts;

    private float time = 0;
    private int[] random;

    void Awake()
    {
        random = new int[5];
    }

    private void Update()
    {
        time += Time.deltaTime;
        if(time > 3)
        {
            time = 0;
            activate();
        }
    }

    private void activate()
    {
        for(int i = 0; i < random.Length; i++)
            random[i] = Random.Range(0, ghosts.Length);

        for(int i = 0; i < ghosts.Length; i++)
            ghosts[random[i]].SetActive(true); 
    }
}
