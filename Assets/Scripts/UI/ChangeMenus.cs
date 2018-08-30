using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMenus : MonoBehaviour {
    public GameObject fromCanvas;
    public GameObject toCanvas;

    public void SwitchCanvases()
    {
        fromCanvas.SetActive(false);
        toCanvas.SetActive(true);
    }
	
}
