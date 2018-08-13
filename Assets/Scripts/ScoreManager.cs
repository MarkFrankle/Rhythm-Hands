using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public GameObject scorePanel;
    private ScoreDisplay sd;

    private int score = 0;
    private int combo = 0;
    private int multiplier = 0;
    private int comboCounter = 0;

    void Awake()
    {
        sd = scorePanel.GetComponent<ScoreDisplay>();
    }

    public void NoteMissed()
    {
        combo = 0;
        comboCounter = 0;
        multiplier = 1;
        sd.Miss();
    }

    /*
     * When a note is hit, the user gains points equal to the note times the multiplier
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
    }
}
