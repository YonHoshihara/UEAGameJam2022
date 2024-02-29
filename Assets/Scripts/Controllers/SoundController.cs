using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class SoundController : MonoBehaviour
{
    public static SoundController Instance;
    
    [SerializeField]
    private AudioSource[] m_AudioSourceSFX;
    
    [SerializeField]
    private AudioClip [] m_AudioClips;

    [SerializeField]
    private AudioClip m_MenuBGM;

    [SerializeField]
    private AudioClip m_SceneBGMAudio;

    [SerializeField]
    private AudioSource m_bgmAudioSource;

    void Awake()
    {
        if (Instance != null && Instance !=this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        
        DontDestroyOnLoad(gameObject);
        EventManager.playSound += PlaySound;
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name.Contains("Stage"))
        {
            if (m_bgmAudioSource.clip != m_SceneBGMAudio)
            {
                m_bgmAudioSource.Stop();
                m_bgmAudioSource.clip = m_SceneBGMAudio;
                m_bgmAudioSource.Play();
            }
        }
        else
        {
            if (m_bgmAudioSource.clip != m_MenuBGM)
            {
                m_bgmAudioSource.Stop();
                m_bgmAudioSource.clip = m_MenuBGM;
                m_bgmAudioSource.Play();
            }
        }
    }
        
    public void PlaySound(GameDefines.Sounds position)
    {
        switch (position)
        {
            case GameDefines.Sounds.BoxCrash:
                m_AudioSourceSFX[0].PlayOneShot(m_AudioClips[(int) GameDefines.Sounds.BoxCrash],1f);
                break;
            
            case GameDefines.Sounds.EatFood:
                m_AudioSourceSFX[0].PlayOneShot(m_AudioClips[(int) GameDefines.Sounds.EatFood],0.5f);
                break;
            
            case GameDefines.Sounds.Jump:
                m_AudioSourceSFX[1].PlayOneShot(m_AudioClips[(int) GameDefines.Sounds.Spring],1f);
                break;
            
            case GameDefines.Sounds.PressButton:
                m_AudioSourceSFX[0].PlayOneShot(m_AudioClips[(int) GameDefines.Sounds.PressButton],1f);
                break;
            
            case GameDefines.Sounds.Spring:
                m_AudioSourceSFX[0].PlayOneShot(m_AudioClips[(int) GameDefines.Sounds.Spring],1f);
                break;
            
            case GameDefines.Sounds.Walk:
                m_AudioSourceSFX[0].PlayOneShot(m_AudioClips[(int) GameDefines.Sounds.Walk],1f);
                break;
            case GameDefines.Sounds.Water:
                m_AudioSourceSFX[0].PlayOneShot(m_AudioClips[(int) GameDefines.Sounds.Water],1f);
                break;
            
            case GameDefines.Sounds.Lose:
                m_AudioSourceSFX[0].PlayOneShot(m_AudioClips[(int) GameDefines.Sounds.Lose],1f);
                break;
            
            case GameDefines.Sounds.Win:
                m_AudioSourceSFX[0].PlayOneShot(m_AudioClips[(int) GameDefines.Sounds.Win],1f);
                break;
        }
        
    }

    private void OnDestroy()
    {
        EventManager.playSound -= PlaySound;
    }
}
