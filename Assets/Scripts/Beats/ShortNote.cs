using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Arm = Thalmic.Myo.Arm;
using Pose = Thalmic.Myo.Pose;

public class ShortNote : Note
{
    public GameObject LeftNoteCanvasPrefab;
    public GameObject RightNoteCanvasPrefab;
    public GameObject InnerCylinder;

    void Awake()
	{
        // Put the face on beats that require specific arms
        if (requiredArm != Arm.Unknown)
        {
            if (requiredArm == Arm.Right)
            {
                Instantiate(RightNoteCanvasPrefab, InnerCylinder.transform);
            }
            else
            {
                Instantiate(LeftNoteCanvasPrefab, InnerCylinder.transform);
            }
        }

        AwakeTasks();
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "DestroyPlane")
        {
            DestroyPlaneTouched();
        }
        else if (col.gameObject.tag == "LeftController" || col.gameObject.tag == "RightController")
        {
            ControllerTouched(col);
        }
        else if (col.gameObject.tag == "VisibleNotes")
        {
            MakeVisible();
        }
    }

    protected override void MakeVisible()
    {
        if (RequiredPose == Pose.Unknown)
        {
            GetComponent<MeshRenderer>().enabled = true;
            if(InnerCylinder != null)
            {
                InnerCylinder.SetActive(true);
            }
        }
        else
        {
            Hand.GetComponent<SkinnedMeshRenderer>().enabled = true;
            Sleeve.GetComponent<MeshRenderer>().enabled = true;
        }
    }

    protected override void MakeInvisible()
    {
        if (RequiredPose == Pose.Unknown)
        {
            GetComponent<MeshRenderer>().enabled = false;
            if (InnerCylinder != null)
            {
                InnerCylinder.SetActive(false);
            }
        }
        else
        {
            Hand.GetComponent<SkinnedMeshRenderer>().enabled = false;
            Sleeve.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    private void ControllerTouched(Collider col)
    {

        Arm touchedArm = col.gameObject.GetComponent<Controller>().arm;
        _touchedMyo = gameManager.GetComponent<MyoManager>().GetMyoByArm(touchedArm);
        Debug.Log("Pose on touch: " + _touchedMyo.pose + ", Req: " + RequiredPose);

        // Vibrate the arm that touched, even if it's the wrong arm
        gameManager.GetComponent<MyoManager>().VibrateMyo(touchedArm);


        bool poseIsCorrect = (RequiredPose == Pose.Unknown || gameManager.GetComponent<MyoManager>().GetPoseByArm(touchedArm) == RequiredPose);
        bool armIsCorrect = (touchedArm == requiredArm || requiredArm == Arm.Unknown);
        if (!testing)
        {
            if (poseIsCorrect && armIsCorrect)
            {
                sm.NoteHit();
            
            }
            else
            {
                sm.NoteMissed();

            }
        }
        Destroy(this.gameObject);

    }
}
