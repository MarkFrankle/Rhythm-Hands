using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public Text scoreText;
    public Text comboText;
    public Text multiplierText;

    public void SetScore(int score)
    {
        string scoreString = score.ToString();
        // Create leading 0s
        for (int i = scoreString.Length; i < 3; i++)
        {
            scoreString = "0" + scoreString;
        }

        scoreText.text = "Score: " + scoreString;
    }

    public void SetCombo(int combo)
    {
        comboText.text = "Combo: " + combo;
    }

    public void SetMultiplier(int multiplier)
    {
        multiplierText.text = "Multiplier: x" + multiplier;
    }

    public void SetAll(int score, int combo, int multiplier)
    {
        SetScore(score);
        SetCombo(combo);
        SetMultiplier(multiplier);
    }

    public void Miss()
    {
        SetCombo(0);
        SetMultiplier(1);
    }

    void Awake ()
    {
    }
}
