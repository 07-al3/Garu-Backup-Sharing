using UnityEngine;
using UnityEngine.UI;

public class ButtonsColorsManager : MonoBehaviour
{
    [SerializeField] private Sprite defaultImage;
    [SerializeField] private Sprite pointerOverImage;

    public void PointerOverImage()
    {
        gameObject.GetComponent<Image>().sprite = pointerOverImage;
    }

    public void DefaultImage()
    {
        gameObject.GetComponent<Image>().sprite = defaultImage;
    }
}
