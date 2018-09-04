using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    // Game index until song picker is ready
    public int nextIndex;
    public GameObject gameManager;
    public GameObject songPickBtn;
    public GameObject syncButton;
    public GameObject mainMenuCanvas;
    public GameObject songPickCanvas;
    public GameObject songList;

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
            syncButton.SetActive(false);
            songPickBtn.SetActive(true);
        } else
        {
            Debug.LogError("Pairing failed");
        }
    }
}
