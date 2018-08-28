using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Arm = Thalmic.Myo.Arm;


public class ShortNote : Note
{
	void Awake()
	{
        AwakeTasks();
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
            GetComponent<MeshRenderer>().enabled = true;
        }
    }

    private void ControllerTouched(Collider col)
    {
        Destroy(this.gameObject);

        Arm touchedArm = col.gameObject.GetComponent<Controller>().arm;

        // Vibrate the arm that touched, even if it's the wrong arm
        gameManager.GetComponent<MyoManager>().VibrateMyo(touchedArm);

        // Unknown will stand in for "either"
        if(touchedArm == requiredArm || requiredArm == Arm.Unknown)
        {
            sm.NoteHit();
            
        }
        else
        {
            sm.NoteMissed();

        }

    }
}
