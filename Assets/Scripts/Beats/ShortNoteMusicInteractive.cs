using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Arm = Thalmic.Myo.Arm;
using Pose = Thalmic.Myo.Pose;

public class ShortNoteMusicInteractive : NoteMusicInteractive
{
    public GameObject LeftNoteCanvasPrefab;
    public GameObject RightNoteCanvasPrefab;
    public GameObject LeftSpreadPrefab;
    public GameObject RightSpreadPrefab;
    public GameObject LeftFistPrefab;
    public GameObject RightFistPrefab;
    public GameObject InnerCylinder;

    // Ensures that Songs have the appropriate sensitivity
    public float preferredSensitivity = 1;

    private AudioSpectrum audioSpectrum = null;

    //public GameObject Visibility

    void OnEnable()
	{
        //AudioSpectrum.instance.BeatSensitivity = preferredSensitivity;

        // Determine type of beat at runtime using in-editor selector
        if (condition == Condition.Right)
        {
            Instantiate(RightNoteCanvasPrefab, InnerCylinder.transform);
        } else if(condition == Condition.Left) { 
            Instantiate(LeftNoteCanvasPrefab, InnerCylinder.transform);
        }
        else if (condition == Condition.LeftSpread)
        {
            Instantiate(LeftSpreadPrefab, this.transform);
        }
        else if (condition == Condition.LeftFist)
        {
            Instantiate(LeftFistPrefab, this.transform);
        }
        else if (condition == Condition.RightSpread)
        {
            Instantiate(RightSpreadPrefab, this.transform);
        }
        else if (condition == Condition.RightFist)
        {
            Instantiate(RightFistPrefab, this.transform);
        }


        AwakeTasks();
	}

    private void Update()
    {
        if(audioSpectrum == null)
        {
            audioSpectrum = AudioSpectrum.instance;
            audioSpectrum.BeatSensitivity = preferredSensitivity;
        }

        if (transform.position.z < VisiblePlane.instance.PlanePosition.z)
            MakeVisible();

        if (transform.position.z < DestroyPlane.instance.PlanePosition.z)
            DestroyPlaneTouched();
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

    // Non pose beats need their canvas turned off
    protected override void MakeVisible()
    {
        GetComponent<MeshRenderer>().enabled = true;
        if(InnerCylinder != null)
        {
            InnerCylinder.SetActive(true);
        }
        // if (condition == Condition.Left || condition == Condition.Right)
        // {
        // }
        // else
        // {
            //Hand.GetComponent<SkinnedMeshRenderer>().enabled = true;
            //Sleeve.GetComponent<MeshRenderer>().enabled = true;
        // }
    }

    protected override void MakeInvisible()
    {
        GetComponent<MeshRenderer>().enabled = false;
        if (InnerCylinder != null)
        {
            InnerCylinder.SetActive(false);
        }
        // if (PoseRequired(condition) == Pose.Unknown)
        // {
        // }
        // else
        // {
        //     Hand.GetComponent<SkinnedMeshRenderer>().enabled = false;
        //     Sleeve.GetComponent<MeshRenderer>().enabled = false;
        // }
    }

    private void ControllerTouched(Collider col)
    {

        Arm touchedArm = col.gameObject.GetComponent<Controller>().arm;
        _touchedMyo = gameManager.GetComponent<MyoManager>().GetMyoByArm(touchedArm);
        Debug.Log("Pose on touch: " + _touchedMyo.pose + ", Req: " + condition);

        // Vibrate the arm that touched, even if it's the wrong arm
        gameManager.GetComponent<MyoManager>().VibrateMyo(touchedArm);


        bool poseIsCorrect = PoseCheck(touchedArm, gameManager.GetComponent<MyoManager>().GetPoseByArm(touchedArm));
        bool armIsCorrect = ArmCheck(touchedArm);

        // No scoreboard in testing
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
