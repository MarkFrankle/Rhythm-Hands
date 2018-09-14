using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreDisplay : MonoBehaviour {
	public GameObject HighScoreListItemPrefab;
	private ScoreManager _scoreManager;

    public void PopulateHighScores()
    {
		_scoreManager = ScoreManager.instance;
		_scoreManager.SaveScore();
		_scoreManager.score = 100;
		_scoreManager.SaveScore();
		_scoreManager.score = 200;
		_scoreManager.SaveScore();
		
		HighScoreList highScores = HighScoreManager.LoadScores();

		if(highScores == null)
			return;
		
		GameObject currentListItem;
		foreach(HighScoreList.ScoreStorage score in highScores.scoreList)
		{
			currentListItem = Instantiate(HighScoreListItemPrefab, this.transform);
			// currentListItem.GetComponent<HighScoreListItem>().SetFields(score);
		}
    }
}
