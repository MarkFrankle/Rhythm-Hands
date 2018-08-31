using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SongListItem : MonoBehaviour {
    public GameObject AlbumArtObject;
    public GameObject SongNameObject;
    public GameObject ArtistNameObject;
    public GameObject SongDurationObject;
    private Image _albumArt;
    private Text _songName;
    private Text _artistName;
    private Text _songDuration;

    void Awake()
    {
        _albumArt = AlbumArtObject.GetComponent<Image>();
        _songName = SongNameObject.GetComponent<Text>();
        _artistName = ArtistNameObject.GetComponent<Text>();
        _songDuration = SongDurationObject.GetComponent<Text>();
    }

    public void SetFields(Sprite albumArt, string songName, string artistName, string songDuration)
    {
        _albumArt.sprite = albumArt;
        _songName.text = songName;
        _artistName.text = artistName;
        _songDuration.text = songDuration;
    }
}
