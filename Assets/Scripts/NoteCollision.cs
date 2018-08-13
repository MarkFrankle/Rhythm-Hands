using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteCollision : MonoBehaviour
{
    public GameObject gameManager;
    private ScoreManager sm;

    void Awake()
    {
        sm = gameManager.GetComponent<ScoreManager>();
    }

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("Triggered  by " + col.gameObject.name);
        //Debug.Log("Tag: " + col.gameObject.tag);
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
