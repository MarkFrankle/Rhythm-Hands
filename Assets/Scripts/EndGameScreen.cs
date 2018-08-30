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
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(MainMenuSceneIndex);
    }
}
