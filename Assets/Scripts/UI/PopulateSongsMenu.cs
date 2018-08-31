using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PopulateSongsMenu : MonoBehaviour {
    public GameObject MusicManager;
    public GameObject SongListItemPrefab;
    public GameObject ListParent;

    void Awake () {
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
            currentListItem.GetComponent<SongListItem>().SetFields(sd.AlbumArt, sds.SongName, sds.Artist, sds.SongDuration);
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
}
