using UnityEngine;

public class QuestionActivator : MonoBehaviour
{
    [SerializeField] private GameObject questionCanvas;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag.Equals("Player"))
        {
            questionCanvas.SetActive(true);
            Time.timeScale = 0.5f;
        }
    }
}
