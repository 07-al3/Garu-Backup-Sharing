using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] tracksList;
    private int index = 0; 
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        PlayNextTrack();
    }

    private void PlayNextTrack()
    {
        index = index < tracksList.Length ? index : 0;

        audioSource.clip = tracksList[index];
        audioSource.Play();
        
        StartCoroutine(WaitForTrackToEnd());
    }

    private IEnumerator WaitForTrackToEnd()
    {
        yield return new WaitWhile(() => audioSource.isPlaying);
        index++;
        PlayNextTrack();
    }
}