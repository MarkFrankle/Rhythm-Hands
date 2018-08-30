using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetSongInfo : MonoBehaviour {
    public Text songTextInfo;

    public void SetTextField(string songName, string songAuthor, string songLength)
    {
        songTextInfo.text = songName + " by " + songAuthor + ": " + songLength;
    }
}
