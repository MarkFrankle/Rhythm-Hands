using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public GameObject scorePanel = null;
    private ScoreDisplay sd;

    public int score;
    public int combo;
    public int multiplier;
    public int comboCounter;
    private int maxCombo = 0;
    private int hits = 0;
    private int misses = 0;

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

    void Update()
    {
        if(scorePanel == null && (SceneManager.GetActiveScene().name == "Game" || SceneManager.GetActiveScene().name == "TestingGame"))
        {
            scorePanel = GameObject.FindGameObjectWithTag("ScorePanel");
            
            score = 0;
            combo = 0;
            multiplier = 1;
            sd = scorePanel.GetComponent<ScoreDisplay>();
            sd.SetAll(score, combo, multiplier);
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
        if(SceneManager.GetActiveScene().name != "NoteTesting")
        {
            sd.SetAll(score, combo, multiplier);
        }
        hits++;
    }


    public void ScoreLongNote(float time)
    {
        score += (int)(time * multiplier * 10);

        IncreaseCombo();
        if (SceneManager.GetActiveScene().name != "NoteTesting")
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
