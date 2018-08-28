using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    // Game index until song picker is ready
    public int nextIndex;
    public GameObject gameManager;
    public GameObject playButton;
    public GameObject syncButton;

    public void PlayGame()
    {

        SceneManager.LoadScene(nextIndex);
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
            playButton.SetActive(true);
        } else
        {
            Debug.LogError("Pairing failed");
        }
    }
}
