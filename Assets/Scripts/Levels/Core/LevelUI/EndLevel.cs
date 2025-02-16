using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag.Equals("Player"))
        {
            PlayerPrefs.SetInt(gameObject.tag, 1);
            PlayerPrefs.Save();

            SceneManager.LoadScene(1);
        }
    }
}