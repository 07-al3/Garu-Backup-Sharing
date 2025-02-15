using UnityEngine;
using UnityEngine.SceneManagement;

public class HubLevelLoader : MonoBehaviour
{
    [SerializeField] private GameObject[] levelDescriptions;

    public void loadLevel(int index)
    {
        SceneManager.LoadScene(index);
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        foreach (GameObject g in levelDescriptions)
        {
            if(coll.tag.Equals(g.tag))
            {
                g.SetActive(true);
                return;
            }
        }
    }
}
