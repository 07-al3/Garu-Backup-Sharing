using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    [SerializeField] GameObject backGroundMusicObj;
    [SerializeField] Image volumeImage;
    [SerializeField] Text volumePercentage;

    private AudioSource backGroundMusic;

    private void Awake()
    {
        backGroundMusic = backGroundMusicObj.GetComponent<AudioSource>();
        changeUI();
    }

    public void volumeUp()
    {
        backGroundMusic.volume = Mathf.Clamp(backGroundMusic.volume + 0.1f, 0f, 1f);
        changeUI();
    }

    public void volumeDown()
    {
        backGroundMusic.volume = Mathf.Clamp(backGroundMusic.volume - 0.1f, 0f, 1f);
        changeUI();
    }

    private void changeUI()
    {
        volumeImage.fillAmount = backGroundMusic.volume;
        float temp = Mathf.Round(backGroundMusic.volume * 100);
        volumePercentage.text = temp + "%";
    }
}
