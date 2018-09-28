using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

/**
 * Handles the end of game screen
  */
public class EndGameScreen : MonoBehaviour {
    public int GameSceneIndex;
    public int MainMenuSceneIndex;

    private ScoreManager _scoreManager;

    // Text objects on canvas showing stats
    public GameObject ScoreObject;
    public GameObject MaxComboObject;
    private TextMeshProUGUI _scoreText;
    private TextMeshProUGUI _maxComboText;
    
    void OnEnable()
    {
        _scoreManager = ScoreManager.instance;
        _scoreText = ScoreObject.GetComponent<TextMeshProUGUI>();
        _maxComboText = MaxComboObject.GetComponent<TextMeshProUGUI>();
        
        DisplayEndScore();
    }

    private void DisplayEndScore()
    {
        if(_scoreManager == null)
        {
            _scoreManager = ScoreManager.instance;
        }
        int scoreLength = _scoreManager.score.ToString().Length;
        string scoreString;
        for(int i = 0; i < (scoreLength - 4); i++)
        {
            scoreString = "0" + _scoreText;
        }
        
        _scoreText.text = _scoreManager.score.ToString();
        _maxComboText.text = _scoreManager.MaxCombo.ToString();

        //sm.SaveScore();
    }

    // TODO: Reset score?
    public void PlayAgain()
    {
        SceneManager.LoadScene(GameSceneIndex);
        LoadSongInGame.instance.PlayAgain();
    }

    /**
     * Delete the Game Manager so that there won't be duplicates at the main menu
     */
    public void GoToMainMenu()
    {
        // These should be unnecessary because of singleton pattern? 
        // But also might be the most efficient way to reset things? 
        // Will change is something valuable is getting lost in the reset

        GameObject gm = GameObject.FindGameObjectWithTag("GameManager");
        Destroy(gm);


        SceneManager.LoadScene(MainMenuSceneIndex);
    }
}
