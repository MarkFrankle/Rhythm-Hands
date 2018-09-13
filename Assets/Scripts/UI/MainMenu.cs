using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    // Game index until song picker is ready
    public int nextIndex;
    public GameObject gameManager;
    public GameObject songPickBtn;
    public GameObject syncBtn;
    public GameObject highScoreBtn;
    public GameObject mainMenuCanvas;
    public GameObject songPickCanvas;
    public GameObject highScoreCanvas;
    public GameObject songList;
    public GameObject highScoreList;

    public void PlayGame()
    {

        SceneManager.LoadScene(nextIndex);
    }

    public void PopulateSongMenu()
    {
        mainMenuCanvas.SetActive(false);
        songPickCanvas.SetActive(true);
        songList.GetComponent<SongListMenu>().PopulateSongs();
        

    }

    public void PopulateHighScores()
    {
        mainMenuCanvas.SetActive(false);
        highScoreCanvas.SetActive(true);
        highScoreList.GetComponent<HighScoreDisplay>().PopulateHighScores();

    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void SyncMyos()
    {
        MyoManager mm = gameManager.GetComponent<MyoManager>();
        mm.PairMyos();
        if (mm.MyoPairCheck())
        {
            syncBtn.SetActive(false);
            songPickBtn.SetActive(true);
        } else
        {
            Debug.LogError("Pairing failed");
        }
    }
}
