using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsPopup : MonoBehaviour
{
    [SerializeField] AudioClip sound;

    public void OnSoundToggle()
    {
        Managers.Audio.SoundMute = !Managers.Audio.SoundMute;
        Managers.Audio.PlaySound(sound);
    }

    public void OnSoundValue(float value)
    {
        Managers.Audio.SoundVolume = value;
    }

    public void OnMusicToggle()
    {
        Managers.Audio.MusicMute = !Managers.Audio.MusicMute;
        Managers.Audio.PlaySound(sound);
    }

    public void OnMusicValue(float value)
    {
        Managers.Audio.MusicVolume = value;
    }

    public void OnPlayMusic(int selector)
    {
        switch (selector)
        {
            case 1:
                Managers.Audio.PlayIntroMusic();
                break;
            case 2:
                Managers.Audio.PlayLevelMusic();
                break;
            case 3:
                Managers.Audio.StopMusic();
                break;
            default:
                throw new NotSupportedException();
        }
    }
}
