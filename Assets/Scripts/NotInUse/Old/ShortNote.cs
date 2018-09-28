//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using Arm = Thalmic.Myo.Arm;
//using Pose = Thalmic.Myo.Pose;

//public class ShortNote : Note
//{
//    public GameObject LeftNoteCanvasPrefab;
//    public GameObject RightNoteCanvasPrefab;
//    public GameObject LeftSpreadPrefab;
//    public GameObject RightSpreadPrefab;
//    public GameObject LeftFistPrefab;
//    public GameObject RightFistPrefab;
//    public GameObject InnerCylinder;

//    //public GameObject Visibility

//    void Awake()
//	{
//        // Determine type of beat at runtime using in-editor selector
//        if (condition == Condition.Right)
//        {
//            Instantiate(RightNoteCanvasPrefab, InnerCylinder.transform);
//        } else if(condition == Condition.Left) { 
//            Instantiate(LeftNoteCanvasPrefab, InnerCylinder.transform);
//        }
//        else if (condition == Condition.LeftSpread)
//        {
//            Instantiate(LeftSpreadPrefab, InnerCylinder.transform);
//        }
//        else if (condition == Condition.LeftFist)
//        {
//            Instantiate(LeftFistPrefab, InnerCylinder.transform);
//        }
//        else if (condition == Condition.RightSpread)
//        {
//            Instantiate(RightSpreadPrefab, InnerCylinder.transform);
//        }
//        else if (condition == Condition.RightFist)
//        {
//            Instantiate(RightFistPrefab, InnerCylinder.transform);
//        }


//        AwakeTasks();
//	}

//    void OnTriggerEnter(Collider col)
//    {
//        if (col.gameObject.tag == "DestroyPlane")
//        {
//            DestroyPlaneTouched();
//        }
//        else if (col.gameObject.tag == "LeftController" || col.gameObject.tag == "RightController")
//        {
//            ControllerTouched(col);
//        }
//        else if (col.gameObject.tag == "VisibleNotes")
//        {
//            MakeVisible();
//        }
//    }

//    // Non pose beats need their canvas turned off
//    protected override void MakeVisible()
//    {
//        if (condition == Condition.Left || condition == Condition.Right)
//        {
//            GetComponent<MeshRenderer>().enabled = true;
//            if(InnerCylinder != null)
//            {
//                InnerCylinder.SetActive(true);
//            }
//        }
//        else
//        {
//            //Hand.GetComponent<SkinnedMeshRenderer>().enabled = true;
//            //Sleeve.GetComponent<MeshRenderer>().enabled = true;
//        }
//    }

//    protected override void MakeInvisible()
//    {
//        if (PoseRequired(condition) == Pose.Unknown)
//        {
//            GetComponent<MeshRenderer>().enabled = false;
//            if (InnerCylinder != null)
//            {
//                InnerCylinder.SetActive(false);
//            }
//        }
//        else
//        {
//            Hand.GetComponent<SkinnedMeshRenderer>().enabled = false;
//            Sleeve.GetComponent<MeshRenderer>().enabled = false;
//        }
//    }

//    private void ControllerTouched(Collider col)
//    {

//        Arm touchedArm = col.gameObject.GetComponent<Controller>().arm;
//        _touchedMyo = gameManager.GetComponent<MyoManager>().GetMyoByArm(touchedArm);
//        Debug.Log("Pose on touch: " + _touchedMyo.pose + ", Req: " + condition);

//        // Vibrate the arm that touched, even if it's the wrong arm
//        gameManager.GetComponent<MyoManager>().VibrateMyo(touchedArm);


//        bool poseIsCorrect = PoseCheck(touchedArm, gameManager.GetComponent<MyoManager>().GetPoseByArm(touchedArm));
//        bool armIsCorrect = ArmCheck(touchedArm);

//        // No scoreboard in testing
//        if (!testing)
//        {
//            if (poseIsCorrect && armIsCorrect)
//            {
//                sm.NoteHit();
            
//            }
//            else
//            {
//                sm.NoteMissed();

//            }
//        }
//        Destroy(this.gameObject);

//    }
//}
