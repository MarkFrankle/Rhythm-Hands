using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PopulateSongsMenu : MonoBehaviour {

    public GameObject SongMenuItemPrefab;

    private string path;
    
	void Awake () {
        path = "Songs";
        PopulateSongs(path);
	}
	
    public void PopulateSongs(string songPath)
    {
        //DirectoryInfo dir = new DirectoryInfo(songPath);
        //FileInfo[] songFiles = dir.GetFiles("*.mp3");
        var audioClips = Resources.LoadAll<AudioClip>(songPath);
        GameObject currentPrefab;
        List<string> songInfo;
        string songTitle, songAuthor, songTime;
        foreach(AudioClip ac in audioClips)
        {
            Debug.Log(ac.name);
        }
        /*
        foreach(AudioClip ac in audioClips)
        {
            try
            {
                songInfo = GetSongData(ac);
                currentPrefab = Instantiate(SongMenuItemPrefab);

                songTitle = songInfo[0];
                songAuthor = songInfo[1];
                songTime = songInfo[2];
                currentPrefab.GetComponent<SetSongInfo>().SetTextField(songTitle, songAuthor, songTime);
            }
            catch (System.FormatException e)
            {
                Debug.LogError("Invalid audio title format");
            }
        }
        */
        //components = PrefabLoader.PFL.LoadAllPrefabsOfType <MonoBehaviour>(songPath);
    }

    private List<string> GetSongData(AudioClip ac)
    {
        List<string> songData = new List<string>();

        string[] songInfo = ac.name.Split('!');
        if (songInfo.Length != 2)
        {
            throw new System.FormatException();
        }

        songData.AddRange(songInfo);

        int songSeconds = (int)ac.length;
        string songLength = (int)songSeconds / 60 + ":" + songSeconds % 60;
        songData.Add(songLength);
        return songData;
    }
}
