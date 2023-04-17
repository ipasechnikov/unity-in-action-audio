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
}
