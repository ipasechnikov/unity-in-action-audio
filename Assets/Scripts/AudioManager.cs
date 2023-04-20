using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour, IGameManager
{
    private NetworkService networkService;

    [SerializeField] AudioSource soundSource;
    [SerializeField] AudioSource music1Source;

    [SerializeField] string introBGMusic;
    [SerializeField] string levelBGMusic;

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

    public void PlayMusic(AudioClip musicClip)
    {
        music1Source.clip = musicClip;
        music1Source.Play();
    }

    public void StopMusic()
    {
        music1Source.Stop();
    }

    public void PlayIntroMusic()
    {
        var introMusicClip = Resources.Load($"Music/{introBGMusic}") as AudioClip;
        PlayMusic(introMusicClip);
    }

    public void PlayLevelMusic()
    {
        var levelMusicClip = Resources.Load($"Music/{levelBGMusic}") as AudioClip;
        PlayMusic(levelMusicClip);
    }
}
