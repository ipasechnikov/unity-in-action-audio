using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsPopup : MonoBehaviour
{
    public void OnSoundToggle()
    {
        Managers.Audio.SoundMute = !Managers.Audio.SoundMute;
    }

    public void OnSoundValue(float value)
    {
        Managers.Audio.SoundVolume = value;
    }
}
