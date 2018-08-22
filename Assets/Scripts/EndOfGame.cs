using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfGame : MonoBehaviour {
    public int EndGameSceneIndex;

    public void SwitchEndScreen()
    {
        SceneManager.LoadScene(EndGameSceneIndex);
    }
}
