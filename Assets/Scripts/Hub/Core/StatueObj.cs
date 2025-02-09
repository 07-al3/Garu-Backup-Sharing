using UnityEngine;

public class StatueObj : MonoBehaviour
{
    private void Awake()
    {
        gameObject.SetActive(PlayerPrefs.GetInt(gameObject.tag, 0) == 1);
    }
}

