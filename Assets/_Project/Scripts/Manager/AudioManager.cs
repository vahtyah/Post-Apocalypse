using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : SerializedSingleton<AudioManager>, IGameState
{
    public enum Type
    {
        MainMenu,
        InGame,
        Ak74Shot,
        ScarShot,
    }
    [SerializeField] private AudioSource backgroundSource;
    [SerializeField] private AudioMixer sfxMixer;
    private float musicVolume, sfxVolume;
    

    [SerializeField] private Dictionary<Type, AudioClip> audioClips = new();

    protected override void Awake()
    {
        base.Awake();
        GameStateManager.Instance.AddGameStateChangedListener(this);
    }

    private void Start()
    {
        musicVolume = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        sfxVolume = PlayerPrefs.GetFloat("SFXVolume", 0.5f);
        
        SetMusicVolume(musicVolume);
        SetSFXVolume(sfxVolume);
    }

    public void PlaySFX(Type type, Vector3 position)
    {
        var audioSource = SFXSourcePool.Instance.Get(AudioType.SFX);
        audioSource.Setup(audioClips[type], position);
    }

    private void PlayBackground(Type type)
    {
        backgroundSource.clip = audioClips[type];
        backgroundSource.Play();
    }

    public void OnGameStateChangedHandler(GameSceneManager.Scene gameState)
    {
        switch (gameState)
        {
            case GameSceneManager.Scene.MainMenu:
                PlayBackground(Type.MainMenu);
                break;
            case GameSceneManager.Scene.Loading:
                Debug.Log("Loading");
                break;
            case GameSceneManager.Scene.InGame:
                PlayBackground(Type.InGame);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(gameState), gameState, null);
        }
    }

    public void SetMusicVolume(float musicVolume)
    {
        backgroundSource.volume = musicVolume;
    }

    public void SetSFXVolume(float sfxVolume)
    {
        sfxMixer.SetFloat("SFX", Mathf.Log10(sfxVolume) * 20);
    }
}