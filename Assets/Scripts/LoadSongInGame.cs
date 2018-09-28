using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Sits on the AudioManager
 * At the start of the game, creates the course from a prefab and plays the music
 * Used by SongListMenu from main menu and EndGameScreen for play again
 */
public class LoadSongInGame : MonoBehaviour {
    public GameObject BeatParent;
    public GameObject CoursePrefab;

    private AudioSource _audioSource;
    private SongData _songData;
    private GameObject _coursePrefab;
    private AudioClip _audioClip;


    // Using singleton pattern for consistency and simplicity
    public static LoadSongInGame instance;

    void Awake()
    {
        if(instance == null){
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if(instance != this){
            Destroy(gameObject);
        }    
    }
    
    public void StartGame(SongData sd, GameObject coursePrefab, AudioClip ac)
    {
        _songData = sd;
        _coursePrefab = coursePrefab;
        _audioClip = ac;

        CoursePrefab = coursePrefab;

        // Make the course with BeatParent as parent
        Instantiate(coursePrefab, BeatParent.transform);
        
        // Play the song
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = ac;
        _audioSource.Play();
    }

    // StartGame with previous values
    public void PlayAgain()
    {
        StartGame(_songData, _coursePrefab, _audioClip);
    }
}
