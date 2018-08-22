using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameScreen : MonoBehaviour {
    public int GameSceneIndex;
    public int MainMenuSceneIndex;

    public void PlayAgain()
    {
        SceneManager.LoadScene(GameSceneIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(MainMenuSceneIndex);
    }
}
