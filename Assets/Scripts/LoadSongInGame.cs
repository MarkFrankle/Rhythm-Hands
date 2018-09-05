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
