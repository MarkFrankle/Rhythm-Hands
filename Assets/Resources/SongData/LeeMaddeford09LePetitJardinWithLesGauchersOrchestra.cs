using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeeMaddeford09LePetitJardinWithLesGauchersOrchestra : SongData {

    public override SongDataStruct GetSongData()
    {
        SongDataStruct sd;
        sd.SongName = "Le Petit Jardin";
        sd.Artist = "Lee Maddeford with Les Gauchers Orchestra";
        sd.SongDuration = "1:22";

        return sd;
    }
}
