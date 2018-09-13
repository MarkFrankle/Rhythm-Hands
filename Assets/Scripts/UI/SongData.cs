using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SongData : MonoBehaviour
{
    public AudioClip song;
    public Sprite AlbumArt;
    public GameObject CoursePrefab;

    public abstract SongDataStruct GetSongData();
}

public struct SongDataStruct {
    public string SongName;
    public string Artist;
    public string SongDuration;
}
