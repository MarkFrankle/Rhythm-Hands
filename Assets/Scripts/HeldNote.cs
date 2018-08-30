using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Arm = Thalmic.Myo.Arm;
using Pose = Thalmic.Myo.Pose;

public class HeldNote : Note
{
    public float HoldTime;
    public GameObject ChildWithMaterial;

    // TODO: These should all b e private
    public bool _noteInProgress;
    public Material _noteMaterial;
    public float _originalOutlineWidth;

    void Awake()
	{
        _noteMaterial = ChildWithMaterial.GetComponent<SkinnedMeshRenderer>().material;
        _originalOutlineWidth = _noteMaterial.GetFloat("_Thickness");
        AwakeTasks();


	}
    
    protected override void MakeVisible()
    {
        ChildWithMaterial.GetComponent<SkinnedMeshRenderer>().enabled = true;

        // TODO: If I make animated notes held
        /*
        if (RequiredPose == Pose.Unknown)
        {
            ChildWithMaterial.GetComponent<SkinnedMeshRenderer>().enabled = true;
        }
        else
        {
            Hand.GetComponent<SkinnedMeshRenderer>().enabled = true;
            Sleeve.GetComponent<MeshRenderer>().enabled = true;
        }
        */
    }

    protected override void MakeInvisible()
    {
        ChildWithMaterial.GetComponent<SkinnedMeshRenderer>().enabled = false;

        // TODO: If I make animated notes held
        /*
        if (RequiredPose == Pose.Unknown)
        {
            ChildWithMaterial.GetComponent<SkinnedMeshRenderer>().enabled = false;
        }
        else
        {
            Hand.GetComponent<SkinnedMeshRenderer>().enabled = false;
            Sleeve.GetComponent<MeshRenderer>().enabled = false;
        }
        */
    }

    void Update()
    {

        if (_noteInProgress)
        {
            // Make sure the pose is still held. If not, score it and reset
            if(RequiredPose != Pose.Unknown && _touchedMyo.pose != RequiredPose)
            {
                EndHeldNote();
            }

            // If the note has been held to completion
            if(_time > HoldTime)
            {
                EndHeldNote();
            }
        } 

        if (!_stopTimer)
        {
            _time += Time.deltaTime;
        }

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "DestroyPlane")
        {
            DestroyPlaneTouched();
        }
        else if (col.gameObject.tag == "VisibleNotes")
        {
            ChildWithMaterial.GetComponent<SkinnedMeshRenderer>().enabled = true;
        }
        else if (col.gameObject.tag == "GameController")
        {
            ControllerTouched(col);
        }
    }

    void OnTriggerExit(Collider col)
    {
        // End the note in progress if it hasn't already ended due to wrong pose
        if (_noteInProgress)
        {
            EndHeldNote();
        }
    }

    private void EndHeldNote()
    {
        _noteInProgress = false;
        _touchedMyo = null;
        EndTimer();
        if (!testing)
        {

            sm.ScoreLongNote(_time);
        }
        StopCoroutine(OutlineCountdown());
        _time = 0;
        Destroy(this.gameObject);
    }

    /*
     * When a user touches a held note, they need to make the appropriate pose and hold it for as long as the note is there
     */
    private void ControllerTouched(Collider col)
    {
        // Get the myo band
        Arm touchedArm = col.gameObject.GetComponent<Controller>().arm;
        _touchedMyo = gameManager.GetComponent<MyoManager>().GetMyoByArm(touchedArm);
        
        
        //bool correctPose = (RequiredPose == Pose.Unknown || gameManager.GetComponent<MyoManager>().PoseCheck(touchedArm, RequiredPose));
        bool correctPose = true;


        bool correctArm = (touchedArm == requiredArm || requiredArm == Arm.Unknown);
        if (correctPose && correctArm)
        {
            // Stop the note, start counting time, and start shrinking the outline
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            _noteInProgress = true;
            StartCoroutine(OutlineCountdown());
            StartTimer();
            Debug.Log("Pose is correct or doesnt care");
        } else
        {
            Debug.Log("Pose: " + correctPose + ", Arm: " + correctArm);
            Destroy(this.gameObject);
            sm.NoteMissed();
        }

        
        gameManager.GetComponent<MyoManager>().VibrateMyo(touchedArm);
        sm.NoteHit();
    }

    IEnumerator OutlineCountdown()
    {

        while(_time < HoldTime)
        {
            float percentTimePassed = _time / HoldTime;
            float outlineAmount = _originalOutlineWidth - (percentTimePassed * _originalOutlineWidth);
            _noteMaterial.SetFloat("_Thickness", outlineAmount);
            yield return null;
        }
        
    }

    /*************
     * Timer stuff
     ***********/

    private float _time;
    private bool _stopTimer = true;

    private void StartTimer()
    {
        _time = 0;
        _stopTimer = false;
    }

    private void EndTimer()
    {
        _stopTimer = true;
    }

}
