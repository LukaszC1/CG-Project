using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class MusicManager : MonoBehaviour
{

    [SerializeField] AudioClip musicOnStart;
    AudioSource audioSource;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        Play(musicOnStart, true);
    }


    AudioClip switchAudio;
    public void Play(AudioClip music, bool interrupt)
    {
        if (interrupt == true)
        {
            audioSource.volume = 0.5f;
            audioSource.clip = music;
            audioSource.Play();

        }
        else
        {
            switchAudio = music;
            StartCoroutine(SmoothSwitch());
        }
    }

    [SerializeField] float timeToSwitch;
    float volume;
    IEnumerator SmoothSwitch()
    {
        volume = 0.5f;

        while (volume > 0f)
        {
            volume -= Time.deltaTime / timeToSwitch;

            if (volume < 0f) { volume = 0f; }
            audioSource.volume = volume;
            yield return new WaitForEndOfFrame();
        }

          Play(switchAudio, true);
    }
}
