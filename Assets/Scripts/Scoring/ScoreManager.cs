﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * Tracks score
 * Lives on GameManager gameObject
 */
public class ScoreManager : MonoBehaviour
{
    // Using singleton pattern for consistency and simplicity
    public static ScoreManager instance;

    public GameObject scorePanel = null;

	// TODO: This shoudl get renamed
    private ScoreDisplay _scoreDisplay;

    public int score;
    public int combo;
    public int multiplier;
    public int comboCounter;
    public string currentSong = "INVALID";

    private int _maxCombo = 0;
    private int _hits = 0;
    private int _misses = 0;


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
        // When the game scene is loaded, initialize and set up the scoreboard
        // Should probably refactor this into an OnSceneLoad event or something like that
        if(scorePanel == null && (SceneManager.GetActiveScene().name == "Game" || SceneManager.GetActiveScene().name == "TestingGame"))
        {
            scorePanel = GameObject.FindGameObjectWithTag("ScorePanel");
            
            score = 0;
            combo = 0;
            multiplier = 1;

			if(scorePanel != null){
				_scoreDisplay = scorePanel.GetComponent<ScoreDisplay>();
				_scoreDisplay.SetAll(score, combo, multiplier);
			}
        }
    }

    public int MaxCombo
    {
        get{ return _maxCombo;  }
        set{ _maxCombo = value; }
    }


    public void NoteMissed()
    {
        combo = 1;
        comboCounter = 0;
        multiplier = 1;
        _scoreDisplay.Miss();
        _misses++;
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
        if(_scoreDisplay != null)
        {
            _scoreDisplay.SetAll(score, combo, multiplier);
        }
        _hits++;
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

    //public void ScoreLongNote(float time)
    //{
    //    score += (int)(time * multiplier * 10);

    //    IncreaseCombo();
    //    if (_scoreDisplay != null)
    //        _scoreDisplay.SetAll(score, combo, multiplier);
    //}

    //public void SaveScore()
    //{
    //    HighScoreManager.SaveScore(currentSong, "Joe Pesci", score, maxCombo, hits, misses);
    //}
	
}

