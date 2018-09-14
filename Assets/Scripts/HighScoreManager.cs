using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

public static class HighScoreManager {
    public static HighScoreList HighScores = null;
    public static FileStream file = null;
    private static string _savePath = Application.persistentDataPath + "/player.sav";

    // Write the current score to the high score list stored in the persistentDataPath
    public static void SaveScore(string currentSong, string playerName, 
                            int score, int maxCombo, int hits, int misses)
    {
        BinaryFormatter bf = new BinaryFormatter();
        //HighScoreList highScores = null;

        if (File.Exists(_savePath))
        {
            file = new FileStream(_savePath, FileMode.Open);
            // if(file.Length != 0){
            HighScores = bf.Deserialize(file) as HighScoreList;
            // }
        }
        //Debug.Log("(!File.Exists(_savePath) || file.Length == 0): " + (!File.Exists(_savePath) || file.Length == 0));
        // if(!File.Exists(_savePath) || file.Length == 0)
        else
        {
            file = new FileStream(_savePath, FileMode.Create);
            HighScores = new HighScoreList();
        }

        //Debug.Log(_savePath);
        // Debug.Log("Pre add: highScores.scoreList.Count: " + highScores.scoreList.Count);
        //Debug.Log("Pre Add: " + HighScores.ToString());

        // TODO: Player profile
        HighScores.AddNewScore(currentSong, playerName, score, maxCombo, hits, misses);

        //Debug.Log("Post Add: " + HighScores.ToString());
        // Debug.Log("Post add: highScores.scoreList.Count: " + highScores.scoreList.Count);

        bf.Serialize(file, HighScores);

        //HighScores = (HighScoreList)bf.Deserialize(file);
        //Debug.Log("Immediately Deserialized: " + HighScores.ToString());

        file.Close();

        // file = File.Open(_savePath, FileMode.Open);
        // highScores = (HighScoreList)bf.Deserialize(file);

        // Debug.Log("Closed and reopened: " + highScores.ToString());
        // // Debug.Log("End step: highScores.scoreList.Count: " + highScores.scoreList.Count);

        // file.Close();

    }

    // Load the current score from the high score list stored in the persistentDataPath
    public static HighScoreList LoadScores()
    {
        if (!File.Exists(_savePath))
            return null;

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(_savePath, FileMode.Open);
        HighScores = (HighScoreList)bf.Deserialize(file);
        file.Close();

        return HighScores;
    }
}

// Object for holding high scores
[Serializable]
public class HighScoreList
{
    public ScoreStorage[] scoreList;

    public HighScoreList()
    {
        scoreList = new ScoreStorage[100];
    }

    public override string ToString()
    {
        string retStr = "";
        foreach (ScoreStorage score in scoreList)
        {
            retStr += score.SongName + ". " + score.PlayerName + ". " + score.Score + "\n";
        }
        return retStr;
    }

    public void AddNewScore(string SongName, string PlayerName,
                            int Score, int MaxCombo, int Hits, int Misses)
    {
        ScoreStorage newScore;
        newScore.SongName = SongName;
        newScore.PlayerName = PlayerName;
        newScore.Score = Score;
        newScore.MaxCombo = MaxCombo;
        newScore.Hits = Hits;
        newScore.Misses = Misses;

        scoreList[scoreList.Length] = newScore;
        Debug.Log("AddNewScore after add: scoreList.Count: " + scoreList.Length);
    }

    [Serializable]
    public struct ScoreStorage
    {
        public string SongName;
        public string PlayerName;
        public int Score;
        public int MaxCombo;
        public int Hits;
        public int Misses;
    }


}
