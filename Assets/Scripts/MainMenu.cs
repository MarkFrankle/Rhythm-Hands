using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    // Game index until song picker is ready
    public int nextIndex;

    public void PlayGame()
    {
        SceneManager.LoadScene(nextIndex);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
