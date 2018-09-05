using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class EndGameScreen : MonoBehaviour {
    public int GameSceneIndex;
    public int MainMenuSceneIndex;

    public GameObject score;
    public GameObject maxCombo;
    private TextMeshProUGUI scoreText;
    private TextMeshProUGUI maxComboText;
    public ScoreManager sm = null;
    
    void Awake()
    {
        sm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<ScoreManager>();
        scoreText = score.GetComponent<TextMeshProUGUI>();
        maxComboText = maxCombo.GetComponent<TextMeshProUGUI>();
        
        DisplayEndScore();
    }

    private void DisplayEndScore()
    {
        if(sm == null)
        {
            sm = GameObject.Find("GameManager").GetComponent<ScoreManager>();
        }
        int scoreLength = sm.score.ToString().Length;
        string scoreString;
        for(int i = 0; i < (scoreLength - 4); i++)
        {
            scoreString = "0" + scoreText;
        }
        
        scoreText.text = sm.score.ToString();
        maxComboText.text = sm.MaxCombo.ToString();
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(GameSceneIndex);
        GameObject.Find("MusicManager").GetComponent<LoadSongInGame>().PlayAgain();
    }

    /**
     * Delete the Myo hub and  Game Manager so that there won't be duplicates at the main menu
     */
    public void GoToMainMenu()
    {
        GameObject myoHub = GameObject.FindGameObjectWithTag("MyoHub");
        Destroy(myoHub);
        GameObject gm = GameObject.FindGameObjectWithTag("GameManager");
        Destroy(gm);
        SceneManager.LoadScene(MainMenuSceneIndex);
    }
}
