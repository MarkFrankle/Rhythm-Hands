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
    
    void OnEnable()
    {
        sm = ScoreManager.instance;
        scoreText = score.GetComponent<TextMeshProUGUI>();
        maxComboText = maxCombo.GetComponent<TextMeshProUGUI>();
        
        DisplayEndScore();
    }

    private void DisplayEndScore()
    {
        if(sm == null)
        {
            sm = ScoreManager.instance;
        }
        int scoreLength = sm.score.ToString().Length;
        string scoreString;
        for(int i = 0; i < (scoreLength - 4); i++)
        {
            scoreString = "0" + scoreText;
        }
        
        scoreText.text = sm.score.ToString();
        maxComboText.text = sm.MaxCombo.ToString();

        sm.SaveScore();
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(GameSceneIndex);
        LoadSongInGame.instance.PlayAgain();
    }

    /**
     * Delete the Myo hub and  Game Manager so that there won't be duplicates at the main menu
     */
    public void GoToMainMenu()
    {
        // These should be unnecessary because of singleton pattern? 
        // But also might be the most efficient way to reset things? 
        // Will change is something valuable is getting lost in the reset

        GameObject myoHub = GameObject.FindGameObjectWithTag("MyoHub");
        Destroy(myoHub);
        GameObject gm = GameObject.FindGameObjectWithTag("GameManager");
        Destroy(gm);


        SceneManager.LoadScene(MainMenuSceneIndex);
    }
}
