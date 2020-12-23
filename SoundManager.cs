using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip[] clips;
    [SerializeField] Image soundIcon;
    [SerializeField] Color enabledColor, disabledColor;

    void Start()
    {
        PlayMusic(PlayerPrefs.GetInt("audioEnabled", 1) == 1);
    }

    public void MenuMusic()
    {
        source.clip = clips[0];
        source.Play();
    }

    public void GameplayMusic()
    {
        if (source.clip != clips[1])
        {
            source.clip = clips[1];
            source.Play();
        }
    }

    public void ToggleMusic()
    {
        PlayMusic(!source.isPlaying);
    }

    void PlayMusic(bool play)
    {
        if (play)
        {
            source.Play();
            soundIcon.color = enabledColor;
            PlayerPrefs.SetInt("audioEnabled", 1);
        }
        else
        {
            source.Stop();
            
            soundIcon.color = disabledColor;
            PlayerPrefs.SetInt("audioEnabled", 0);
        }
    }
}
