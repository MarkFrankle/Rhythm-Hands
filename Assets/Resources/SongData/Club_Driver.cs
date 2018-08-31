using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Club_Driver : SongData {

    public override SongDataStruct GetSongData()
    {
        SongDataStruct sd;
        sd.SongName = "Club Driver";
        sd.Artist = "Kevin MacLeod";
        sd.SongDuration = "2:25";

        return sd;
    }
}
