using System;
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
    private SongListMenu _songList;
    public SongData SongData;

    void Awake()
    {
        _albumArt = AlbumArtObject.GetComponent<Image>();
        _songName = SongNameObject.GetComponent<Text>();
        _artistName = ArtistNameObject.GetComponent<Text>();
        _songDuration = SongDurationObject.GetComponent<Text>();
        _songList = GameObject.FindGameObjectWithTag("SongList").GetComponent<SongListMenu>();
    }

    public void SetFields(Sprite albumArt, string songName, string artistName, string songDuration, SongData songData)
    {
        _albumArt.sprite = albumArt;
        _songName.text = songName;
        _artistName.text = artistName;
        _songDuration.text = songDuration;
        SongData = songData;
    }

    // When clicked in the menu, a song will "select" itself
    // Register itself with the menu, set its outline to show selection, start playing the song
    public void Select()
    {
        if(_songList.SelectedSong != null)
        {
            _songList.SelectedSong.GetComponent<SongListItem>().Deselect();
        }
        _songList.SelectSong(this.gameObject);
        
        GetComponent<Outline>().enabled = true;      
        
    }

    // Remove the outline when no longer selected
    private void Deselect()
    {
        GetComponent<Outline>().enabled = false;
        _songList.DeselectSong();
    }


}
