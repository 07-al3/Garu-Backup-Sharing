using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] tracksList;
    private AudioSource audioSource;
    private int random;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        PlayNextTrack();
    }

    private void PlayNextTrack()
    {
        random = Random.Range(0, tracksList.Length);

        audioSource.clip = tracksList[random];
        audioSource.Play();
        
        StartCoroutine(WaitForTrackToEnd());
    }

    private IEnumerator WaitForTrackToEnd()
    {
        yield return new WaitWhile(() => audioSource.isPlaying);
        PlayNextTrack();
    }
}