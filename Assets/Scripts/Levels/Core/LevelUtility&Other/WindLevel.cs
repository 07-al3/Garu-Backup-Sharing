using UnityEngine;

public class WindLevel : MonoBehaviour
{
    [Header("Override Level Parameters")]
    [SerializeField] private GameObject cameraLevel;
    [SerializeField] private GameObject oldPlayerGobj;
    [SerializeField] private GameObject newPlayerGobj;

    [Header("Base Level Logic Parameters")]
    [SerializeField] private GameObject controlsCanvas;
    [SerializeField] private GameObject playerHealthShield;
    [SerializeField] private Transform startingPosition;

    private void OnTriggerEnter2D (Collider2D other)
    {
        if(other.tag.Equals("Player"))
        {
            controlsCanvas.SetActive(false);

            newPlayerGobj.SetActive(true);
            newPlayerGobj.transform.position = new Vector2(startingPosition.position.x, startingPosition.position.y);

            cameraLevel.GetComponent<CameraHub>().enabled = true;
            cameraLevel.GetComponent<CameraLevel>().enabled = false;

            oldPlayerGobj.SetActive(false);

            playerHealthShield.SetActive(true);
            startingPosition.gameObject.SetActive(false);
        }
    }
}
