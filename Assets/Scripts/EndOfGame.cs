using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfGame : MonoBehaviour {
	public static EndOfGame instance;

    public int EndGameSceneIndex;

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

    public void SwitchEndScreen()
    {
        SceneManager.LoadScene(EndGameSceneIndex);
    }


}
