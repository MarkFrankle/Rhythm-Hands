using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ScoreManager : MonoBehaviour
{
    // Using singleton pattern for consistency and simplicity
    public static ScoreManager instance;

    public GameObject scorePanel = null;

	// TODO: This shoudl get renamed
    private ScoreDisplay sd;

    public int score;
    public int combo;
    public int multiplier;
    public int comboCounter;
    private int maxCombo = 0;
    private int hits = 0;
    private int misses = 0;
    public string currentSong = "INVALID";


    void Awake()
    {
        if(instance == null){
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if(instance != this){
            Destroy(gameObject);
        }    
    }

    void Update()
    {
        if(scorePanel == null && (SceneManager.GetActiveScene().name == "Game" || SceneManager.GetActiveScene().name == "TestingGame"))
        {
            scorePanel = GameObject.FindGameObjectWithTag("ScorePanel");
            
            score = 0;
            combo = 0;
            multiplier = 1;

			if(scorePanel != null){
				sd = scorePanel.GetComponent<ScoreDisplay>();
				sd.SetAll(score, combo, multiplier);
			}
        }
    }

    public void SaveScore()
    {
        HighScoreManager.SaveScore(currentSong, "Joe Pesci", score, maxCombo, hits, misses);
    }


    public int MaxCombo
    {
        get
        {
            return maxCombo;
        }

        set
        {
            maxCombo = value;
        }
    }


    public void NoteMissed()
    {
        // TODO: More feedback for missing
        combo = 1;
        comboCounter = 0;
        multiplier = 1;
        sd.Miss();
        misses++;
    }

    /*
     * When a note is hit, the user gains points equal to the multiplier
     * Then, the combo counter increases by one
     * If the combo counter >= multiplier, multiplier goes to the next power of two
     */
    public void NoteHit()
    {
        score += multiplier;

        IncreaseCombo();
        if(sd != null)
        {
            sd.SetAll(score, combo, multiplier);
        }
        hits++;
    }


    public void ScoreLongNote(float time)
    {
        score += (int)(time * multiplier * 10);

        IncreaseCombo();
        if (sd != null)
            sd.SetAll(score, combo, multiplier);
    }

    private void IncreaseCombo()
    {
        combo++;
        comboCounter++;

        if (comboCounter > multiplier)
        {
            comboCounter = 0;
            multiplier *= 2;
        }

        MaxCombo = Mathf.Max(combo, MaxCombo);
    }

	
}

