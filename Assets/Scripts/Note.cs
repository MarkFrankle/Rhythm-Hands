using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Note : MonoBehaviour
{
    public bool isValid = false;
    public bool isLastNote = false;

    public GameObject gameManager;
    private ScoreManager sm;
	public float noteSpeed = -.922f;

	void Awake()
	{
	    gameManager = GameObject.FindGameObjectWithTag("GameManager");
        sm = gameManager.GetComponent<ScoreManager>();
        GetComponent<Rigidbody>().velocity = new Vector3(0,0,noteSpeed);
	}

    void OnTriggerEnter(Collider col)
    {
        //Debug.Log("Triggered  by " + col.gameObject.name);
        //Debug.Log("Tag: " + col.gameObject.tag);
        if (isLastNote)
        {
            EndOfGame eog = gameManager.GetComponent<EndOfGame>();
            eog.SwitchEndScreen();
        }

        if (col.gameObject.tag == "DestroyPlane")
        {
            Destroy(this.gameObject);
            
            sm.NoteMissed();
        }
        else if (col.gameObject.tag == "ValidPlane")
        {
            GetComponent<Note>().isValid = true;
        }
        else if (col.gameObject.tag == "GameController")
        {
            Destroy(this.gameObject);
            sm.NoteHit();
        }
    }
}
