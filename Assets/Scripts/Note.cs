using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Arm = Thalmic.Myo.Arm;


public class Note : MonoBehaviour
{
    public bool isLastNote = false;

    public GameObject gameManager;
	public float noteSpeed = -.922f;
    public Arm requiredArm = Arm.Unknown;
    protected ScoreManager sm;
    protected ThalmicMyo _touchedMyo = null;


    protected virtual void AwakeTasks()
	{
	    gameManager = GameObject.FindGameObjectWithTag("GameManager");
        sm = gameManager.GetComponent<ScoreManager>();
        GetComponent<Rigidbody>().velocity = new Vector3(0,0,noteSpeed);
	}

    protected virtual void DestroyPlaneTouched()
    {
        Destroy(this.gameObject);
        sm.NoteMissed();
    }
}
