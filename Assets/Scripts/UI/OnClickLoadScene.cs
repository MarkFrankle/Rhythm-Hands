using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnClickLoadScene : MonoBehaviour {
    
    public void LoadBySceneIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void LoadBySceneName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
