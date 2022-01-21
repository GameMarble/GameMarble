using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager_sc : MonoBehaviour
{
    private static AudioManager_sc audioManager = null;
    
    public AudioSource audioSource; // Audio
    public AudioSource _audioSource; // Temp

    public AudioClip mainMenuAudioClip;
    public AudioClip gameAudioClip;

    void Awake()
    {
        if (audioManager == null)
            audioManager = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += SceneChanged;
    }

    // Main Menu ile oyun sahnesi arasýnda geçiþ olduðunda oynatýlacak ses klibini deðiþtirir
    void SceneChanged(Scene scene, LoadSceneMode sceneMode)
    {
        // Build index deðerine göre istenilen klibin geçici deðiþkene atanmasý
        if (scene.buildIndex == 0)
            _audioSource.clip = mainMenuAudioClip;
        else
            _audioSource.clip = gameAudioClip;

        // Sadece deðiþiklik olduðunda çalýþmasý için
        if (audioSource.clip != _audioSource.clip)
        {
            audioSource.enabled = false;
            audioSource.clip = _audioSource.clip;
            audioSource.enabled = true;
        }
    }
}
