using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : SongData {

    public override SongDataStruct GetSongData()
    {
        SongDataStruct sd;
        sd.SongName = "Rocket";
        sd.Artist = "Kevin MacLeod";
        sd.SongDuration = "2:26";

        return sd;
    }
}
