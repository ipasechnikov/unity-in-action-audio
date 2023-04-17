using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour, IGameManager
{
    private NetworkService networkService;

    [SerializeField] AudioSource soundSource;

    public ManagerStatus Status
    {
        get; private set;
    }

    public float SoundVolume
    {
        get => AudioListener.volume;
        set => AudioListener.volume = value;
    }

    public bool SoundMute
    {
        get => AudioListener.pause;
        set => AudioListener.pause = value;
    }

    public void Startup(NetworkService service)
    {
        Debug.Log("Audio manager starting...");
        networkService = service;
        SoundVolume = 1f;
        Status = ManagerStatus.Started;
    }

    public void PlaySound(AudioClip audioClip)
    {
        soundSource.PlayOneShot(audioClip);
    }
}
