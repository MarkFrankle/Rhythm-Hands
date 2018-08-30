using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Arm = Thalmic.Myo.Arm;
using Pose = Thalmic.Myo.Pose;

public class ShortPoseBeat : MonoBehaviour {

    public GameObject gameManager;
    public GameObject ParentToDestroy;
    public GameObject Hand;
    public GameObject Sleeve;

    public Pose RequiredPose = Pose.Unknown;
    public Arm requiredArm = Arm.Unknown;
    protected ScoreManager sm;
    protected ThalmicMyo _touchedMyo = null;


    void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        sm = gameManager.GetComponent<ScoreManager>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "DestroyPlane")
        {
            DestroyPlaneTouched();
        }
        else if (col.gameObject.tag == "GameController")
        {
            ControllerTouched(col);
        }
        else if (col.gameObject.tag == "VisibleNotes")
        {
            MakeHandVisible();
        }
    }

    private void MakeHandVisible()
    {
        Hand.GetComponent<SkinnedMeshRenderer>().enabled = true;
        Sleeve.GetComponent<SkinnedMeshRenderer>().enabled = true;
    }

    private void ControllerTouched(Collider col)
    {
        Destroy(ParentToDestroy);

        Arm touchedArm = col.gameObject.GetComponent<Controller>().arm;

        // Vibrate the arm that touched, even if it's the wrong arm
        gameManager.GetComponent<MyoManager>().VibrateMyo(touchedArm);

        // Unknown will stand in for "either"
        bool correctPose = (_touchedMyo.pose == RequiredPose || RequiredPose == Pose.Unknown);
        bool correctArm = (touchedArm == requiredArm || requiredArm == Arm.Unknown);
        if (correctPose && correctArm)
        {
            sm.NoteHit();

        }
        else
        {
            sm.NoteMissed();

        }

    }

    protected virtual void DestroyPlaneTouched()
    {
        Destroy(ParentToDestroy);
        sm.NoteMissed();
    }
}
