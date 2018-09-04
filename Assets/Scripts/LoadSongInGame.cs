using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSongInGame : MonoBehaviour {
    public AudioSource audioSource;
    public GameObject Prefab;
    public AudioClip clip;
    public GameObject NotesParent;

    public void StartGame(SongData sd, GameObject coursePrefab, AudioClip ac)
    {
        clip = ac;
        Prefab = coursePrefab;
        Instantiate(coursePrefab, NotesParent.transform);
        // Play the song
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = ac;
        audioSource.Play();
    }
}
