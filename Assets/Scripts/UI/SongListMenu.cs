using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SongListMenu : MonoBehaviour {
    public GameObject MusicManager;
    public GameObject SongListItemPrefab;
    public GameObject ListParent;
    public GameObject SelectedSong = null;
    private string _gameSceneName = "TestingGame";
    private int _timeToPreview = 30;
    private bool _previewPlaying = false;
    private float _timer = 0f;

    void Awake () {
	}

    void Update(){
        if(_previewPlaying){
            _timer += Time.deltaTime;

            if(_timer > _timeToPreview){
                GetComponent<AudioSource>().Stop();
                _previewPlaying = false;
                _timer = 0;
            }
        }
    }

    public bool PopulateSongs()
    {
        List<SongData> songDatas;

        songDatas = new List<SongData>(MusicManager.transform.GetComponentsInChildren<SongData>());

        GameObject currentListItem;

        foreach (SongData sd in songDatas)
        {
            currentListItem = Instantiate(SongListItemPrefab, ListParent.transform);
            SongDataStruct sds = sd.GetSongData();
            currentListItem.GetComponent<SongListItem>().SetFields(sd.AlbumArt, sds.SongName, sds.Artist, sds.SongDuration, sd);
            Debug.Log("Name: " + sds.SongName + ", Artist: " + sds.Artist + ", Time: " + sds.SongDuration);
        }


        return true;
    }

    // Called when leaving song pick window to avoid duplication
    public void DeleteList()
    {
        foreach(Transform child in ListParent.transform)
        {
            Destroy(child.gameObject);
        }
    }

    // Sets the currently selected song and plays a preview of length _timeToPreview
    public void SelectSong(GameObject currentSong)
    {
        SelectedSong = currentSong;
        SongData sd = SelectedSong.GetComponent<SongListItem>().SongData;
        coursePrefab = sd.CoursePrefab;

        GetComponent<AudioSource>().clip = sd.song;
        GetComponent<AudioSource>().Play();
        _previewPlaying = true;


    }

    public void DeselectSong()
    {
        if(_previewPlaying){
                GetComponent<AudioSource>().Stop();
                _previewPlaying = false;
                _timer = 0;
        }
    }

    // TODO: Temporary
    public GameObject coursePrefab;


    // Uses the selected song to start game: Switch the scene, create the course, and play the music
    public void StartGame()
    {
        if(SelectedSong == null)
        {
            return;
        }

        // Save the data required for next scene
        SongData sd = SelectedSong.GetComponent<SongListItem>().SongData;
        coursePrefab = sd.CoursePrefab;
        AudioClip ac = sd.song;

        // Switch the scene
        GetComponent<OnClickLoadScene>().LoadBySceneName(_gameSceneName);

        MusicManager.GetComponent<LoadSongInGame>().StartGame(sd, coursePrefab, ac);


        //// Make the course
        //// 0,0,-.35
        //Instantiate(coursePrefab);

        //// Play the song
        //AudioSource audioSource = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioSource>();
        //audioSource.clip = ac;
        //audioSource.Play();
    }
}
