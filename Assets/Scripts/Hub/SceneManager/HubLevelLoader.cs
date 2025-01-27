using UnityEngine;
using UnityEngine.SceneManagement;

public class HubLevelLoader : MonoBehaviour
{
    private void loadLevel(int index)
    {
        SceneManager.LoadScene(index);
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        switch(coll.tag)
        {
            case "livello1":
            {
                loadLevel(2);
                break;
            }
            /*case "livello2":
            {
                loadLevel(4);
                break;
            }
            case "livello3":
            {
                loadLevel(5);
                break;
            }
            case "livello4":
            {
                loadLevel(6);
                break;
            }*/
        }
    }
}
