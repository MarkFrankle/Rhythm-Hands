using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Arm = Thalmic.Myo.Arm;
using Pose = Thalmic.Myo.Pose;


public abstract class Note : MonoBehaviour
{
    public bool isLastNote = false;
    public bool testing = false;
    public bool isVisible;

    public GameObject gameManager;
	public float noteSpeed = -.922f;
    public Arm requiredArm = Arm.Unknown;
    public Pose RequiredPose = Pose.Unknown;
    protected ScoreManager sm;
    protected ThalmicMyo _touchedMyo = null;
    public GameObject Hand;
    public GameObject Sleeve;

    // Initialization for all beats
    // Find the game manager and score manager, start moving, and set visibility
    protected virtual void AwakeTasks()
	{
	    gameManager = GameObject.FindGameObjectWithTag("GameManager");
        sm = gameManager.GetComponent<ScoreManager>();
        GetComponent<Rigidbody>().velocity = new Vector3(0,0,noteSpeed);

        if (isVisible)
        {
            MakeVisible();
        }
        else
        {
            MakeInvisible();
        }
    }

    protected abstract void MakeVisible();

    protected abstract void MakeInvisible();

    protected virtual void DestroyPlaneTouched()
    {
        Destroy(this.gameObject);
        sm.NoteMissed();
    }
}
