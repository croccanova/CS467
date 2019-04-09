using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSettings : MonoBehaviour
{
    public float musicVolume = 0.2f;
    GameObject audioManagement;
    AudioSource[] tracks;
    int currentTrack;

    void Start()
    {
        if (PlayerPrefs.HasKey("master_vol"))
        {
            AudioListener.volume = PlayerPrefs.GetFloat("master_vol");
        }

        if (PlayerPrefs.HasKey("music_vol"))
        {
            musicVolume = PlayerPrefs.GetFloat("music_vol");
        }

        audioManagement = GameObject.Find("Audio Management");
        tracks = audioManagement.GetComponents<AudioSource>();
        currentTrack = Random.Range(0, tracks.Length);
        tracks[currentTrack].volume = musicVolume;
        tracks[currentTrack].Play();
    }

    void Update()
    {
        if (!tracks[currentTrack].isPlaying)
        {
            int lastTrackPlayed = currentTrack;

            while (tracks.Length > 1 && lastTrackPlayed == currentTrack)
            {
                currentTrack = Random.Range(0, tracks.Length);
            }

            tracks[currentTrack].volume = musicVolume;
            tracks[currentTrack].Play();
        }
    }
}
