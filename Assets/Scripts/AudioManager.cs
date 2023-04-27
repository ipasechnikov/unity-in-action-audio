using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour, IGameManager
{
    private NetworkService networkService;

    [SerializeField] AudioSource soundSource;
    [SerializeField] AudioSource music1Source;
    [SerializeField] AudioSource music2Source;

    [SerializeField] string introBGMusic;
    [SerializeField] string levelBGMusic;

    private AudioSource activeMusic;
    private AudioSource inactiveMusic;

    public float crossFadeRate = 1.5f;
    private bool crossFading;

    public ManagerStatus Status
    {
        get; private set;
    }

    public float SoundVolume
    {
        get => AudioListener.volume;
        set => AudioListener.volume = value;
    }

    private float _musicVolume;
    public float MusicVolume
    {
        get => _musicVolume;
        set
        {
            _musicVolume = value;
            if (music1Source != null && !crossFading)
            {
                music1Source.volume = _musicVolume;
                music2Source.volume = _musicVolume;
            }
        }
    }

    public bool SoundMute
    {
        get => AudioListener.pause;
        set => AudioListener.pause = value;
    }

    public bool MusicMute
    {
        get
        {
            if (music1Source != null)
                return music1Source.mute;
            return false;
        }
        set
        {
            if (music1Source != null)
            {
                music1Source.mute = value;
                music2Source.mute = value;
            }
        }
    }

    public void Startup(NetworkService service)
    {
        Debug.Log("Audio manager starting...");

        networkService = service;

        music1Source.ignoreListenerVolume = true;
        music2Source.ignoreListenerVolume = true;
        music1Source.ignoreListenerPause = true;
        music2Source.ignoreListenerPause = true;

        SoundVolume = 1f;
        MusicVolume = 1f;

        activeMusic = music1Source;
        inactiveMusic = music2Source;

        Status = ManagerStatus.Started;
    }

    public void PlaySound(AudioClip audioClip)
    {
        soundSource.PlayOneShot(audioClip);
    }

    public void PlayMusic(AudioClip musicClip)
    {
        if (crossFading)
            return;

        StartCoroutine(CrossFadeMusic(musicClip));
    }

    public void StopMusic()
    {
        activeMusic.Stop();
        inactiveMusic.Stop();
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

    private IEnumerator CrossFadeMusic(AudioClip musicClip)
    {
        crossFading = true;

        inactiveMusic.clip = musicClip;
        inactiveMusic.volume = 0;
        inactiveMusic.Play();

        var scaledRate = crossFadeRate * MusicVolume;
        while (activeMusic.volume > 0)
        {
            activeMusic.volume -= scaledRate * Time.deltaTime;
            inactiveMusic.volume += scaledRate * Time.deltaTime;

            // Yield statement pauses for one frame
            yield return null;
        }

        var temp = activeMusic;

        activeMusic = inactiveMusic;
        activeMusic.volume = MusicVolume;

        inactiveMusic = temp;
        inactiveMusic.Stop();

        crossFading = false;
    }
}
