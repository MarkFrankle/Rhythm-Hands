using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class ScoreManager : MonoBehaviour
{
    // Using singleton pattern for consistency and simplicity
    public static ScoreManager instance;

    public HighScoreList HighScores = null;
    public GameObject scorePanel = null;
    public FileStream file = null;

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

    private string _savePath;

    void Awake()
    {
        if(instance == null){
            DontDestroyOnLoad(gameObject);
            instance = this;
            _savePath = Application.persistentDataPath + "highScores.dat";
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

	// Write the current score to the high score list stored in the persistentDataPath
    public void SaveScore()
    {
        BinaryFormatter bf = new BinaryFormatter();
        HighScoreList highScores = null;

        if(File.Exists(_savePath))
        {
            file = File.Open(_savePath, FileMode.Open);
            // if(file.Length != 0){
            highScores = (HighScoreList)bf.Deserialize(file);
            // }
        } 
        //Debug.Log("(!File.Exists(_savePath) || file.Length == 0): " + (!File.Exists(_savePath) || file.Length == 0));
        // if(!File.Exists(_savePath) || file.Length == 0)
        else {
            file = File.Create(_savePath);
            highScores = new HighScoreList();
        }
        string playerName = "Jane Schmoe";
        
        Debug.Log(_savePath);
		// Debug.Log("Pre add: highScores.scoreList.Count: " + highScores.scoreList.Count);
        Debug.Log("Pre Add: " + highScores.ToString());
        
		// TODO: Player profile
		highScores.AddNewScore(currentSong, playerName, score, maxCombo, hits, misses);
        
        Debug.Log("Post Add: " + highScores.ToString());
        // Debug.Log("Post add: highScores.scoreList.Count: " + highScores.scoreList.Count);

        bf.Serialize(file, highScores);
        highScores = (HighScoreList)bf.Deserialize(file);
        Debug.Log("Immediately Deserialized: " + highScores.ToString());

        file.Close();

        // file = File.Open(_savePath, FileMode.Open);
        // highScores = (HighScoreList)bf.Deserialize(file);
        
        // Debug.Log("Closed and reopened: " + highScores.ToString());
        // // Debug.Log("End step: highScores.scoreList.Count: " + highScores.scoreList.Count);
        
        // file.Close();

    }

	// Load the current score from the high score list stored in the persistentDataPath
    public HighScoreList LoadScores()
    {
        if(!File.Exists(_savePath))
            return null;
        
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(_savePath, FileMode.Open);
        HighScores = (HighScoreList) bf.Deserialize(file);
        file.Close();

        return HighScores;
    }
}

// Object for holding high scores
[Serializable]
public class HighScoreList {
    public List<ScoreStorage> scoreList;

    public HighScoreList()
    {
        scoreList = new List<ScoreStorage>();
    }

    public override string ToString(){
        string retStr = "";
        foreach(ScoreStorage score in scoreList){
            retStr += score.SongName + ". " + score.PlayerName + ". " + score.Score + "\n";
        }
        return retStr;
    }

	public void AddNewScore(string SongName, string PlayerName, 
							int Score, int MaxCombo, int Hits,  int Misses)
	{
		ScoreStorage newScore;
		newScore.SongName = SongName;
		newScore.PlayerName = PlayerName;
		newScore.Score = Score;
		newScore.MaxCombo = MaxCombo;
		newScore.Hits = Hits;
		newScore.Misses = Misses;
                
        scoreList.Add(newScore);
        Debug.Log("AddNewScore after add: scoreList.Count: " + scoreList.Count);
	}
 
    [Serializable]
    public struct ScoreStorage {
        public string SongName;
        public string PlayerName;
        public int Score;
        public int MaxCombo;
        public int Hits;
        public int Misses;
    }


}
