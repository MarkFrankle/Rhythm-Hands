using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSongInGame : MonoBehaviour {
    public AudioSource audioSource;
    public GameObject Prefab;
    public AudioClip clip;
    public GameObject NotesParent;

    private SongData _sd;
    private GameObject _coursePrefab;
    private AudioClip _ac;


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
        _sd = sd;
        _coursePrefab = coursePrefab;
        _ac = ac;

        clip = ac;
        Prefab = coursePrefab;

        // Make the course
        Instantiate(coursePrefab, NotesParent.transform);
        
        // Play the song
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = ac;
        audioSource.Play();
    }

    // StartGame but with previous values
    public void PlayAgain()
    {
        StartGame(_sd, _coursePrefab, _ac);
    }
}
