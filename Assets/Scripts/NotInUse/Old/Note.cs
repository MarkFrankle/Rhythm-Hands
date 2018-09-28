//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;


//public abstract class Note : MonoBehaviour
//{
//    public bool isLastNote = false;
//    public bool testing = false;
//    public bool isVisible;

//    public GameObject gameManager;
//	public float noteSpeed = -.922f;

//    public Condition condition;

//    protected ScoreManager sm;

//    public GameObject Hand;
//    public GameObject Sleeve;

//    // Initialization for all beats
//    // Find the game manager and score manager, start moving, and set visibility
//    protected virtual void AwakeTasks()
//	{
//	    gameManager = GameObject.FindGameObjectWithTag("GameManager");
//        sm = gameManager.GetComponent<ScoreManager>();
//        GetComponent<Rigidbody>().velocity = new Vector3(0,0,noteSpeed);

//        if (isVisible)
//        {
//            MakeVisible();
//        }
//        else
//        {
//            MakeInvisible();
//        }
//    }

//    protected abstract void MakeVisible();

//    protected abstract void MakeInvisible();

//    protected virtual void DestroyPlaneTouched()
//    {
//        Destroy(this.gameObject);
//        sm.NoteMissed();
//    }

//    public enum Condition
//    {
//        Left,
//        Right,
//        LeftFist,
//        LeftSpread,
//        RightFist,
//        RightSpread,
//        NAFist,
//        NASpread
//    };

//    public Arm ArmRequired(Condition condition)
//    {
//        if (condition == Condition.Left ||
//            condition == Condition.LeftSpread || condition == Condition.LeftFist)
//        {
//            return Arm.Left;
//        }

//        if (condition == Condition.Right || condition == Condition.RightSpread || condition == Condition.RightFist)
//        {
//            return Arm.Right;
//        }
//        return Arm.Unknown;
//    }

//    public Pose PoseRequired(Condition condition)
//    {
//        if (condition == Condition.Left || condition == Condition.Right)
//        {
//            return Pose.Unknown;
//        }

//        if (condition == Condition.LeftFist || condition == Condition.RightFist)
//        {
//            return Pose.Fist;
//        }
//        if (condition == Condition.LeftSpread || condition == Condition.RightSpread)
//        {
//            return Pose.FingersSpread;
//        }

//        return Pose.Unknown;
//    }

//    public bool ArmCheck(Arm touchedArm)
//    {
//        return touchedArm == ArmRequired(condition) || ArmRequired(condition) == Arm.Unknown;
//    }

//    public bool PoseCheck(Arm touchedArm, Pose currentPose)
//    {
//        return PoseRequired(condition) == Pose.Unknown || currentPose == PoseRequired(condition);
//    }
//}
