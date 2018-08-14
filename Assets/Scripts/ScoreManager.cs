using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public GameObject scorePanel;
    private ScoreDisplay sd;

    public int score;
    public int combo;
    public int multiplier;
    public int comboCounter;

    void Awake()
    {
        score = 0;
        combo = 0;
        multiplier = 1;
        sd = scorePanel.GetComponent<ScoreDisplay>();
        sd.SetAll(score, combo, multiplier);
    }

    public void NoteMissed()
    {
        combo = 1;
        comboCounter = 0;
        multiplier = 1;
        sd.Miss();
    }

    /*
     * When a note is hit, the user gains points equal to the multiplier
     * Then, the combo counter increases by one
     * If the combo counter >= multiplier, multiplier goes to the next power of two
     */
    public void NoteHit()
    {
        score += multiplier;
        combo++;
        comboCounter++;

        if (comboCounter > multiplier)
        {
            comboCounter = 0;
            multiplier *= 2;
        }

        Debug.Log("Hit! Score: " + score);
        //sd.SetScore(score);
        sd.SetAll(score, combo, multiplier);
    }
}
