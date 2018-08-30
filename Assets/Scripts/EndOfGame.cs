using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfGame : MonoBehaviour {
    public int EndGameSceneIndex;
    public GameObject ScorePanel;

    public void SwitchEndScreen()
    {
        SceneManager.LoadScene(EndGameSceneIndex);
    }


}
