using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Base class for notes
 * Currently only used by ShortNoteMusicInteractive, now that ShortNote handles poses and held notes are gone
 */
public abstract class NoteMusicInteractive : MonoBehaviour
{
    public bool testing = false;
    public bool isVisible;
    public float noteSpeed = -.7f;
    public GameObject gameManager;

    public Condition condition;

    protected ScoreManager sm;
    public GameObject Hand;
    public GameObject Sleeve;

    // Initialization for all beats
    // Find the game manager and score manager, start moving, and set visibility
    protected virtual void AwakeTasks()
	{
	    gameManager = GameObject.FindGameObjectWithTag("GameManager");
        sm = gameManager.GetComponent<ScoreManager>();
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, noteSpeed);

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

    // The requirements of the beat
    public enum Condition
    {
        Left,
        Right,
        LeftFist,
        LeftSpread,
        RightFist,
        RightSpread,
        NAFist,
        NASpread
    };

    // Returns which arm, if any, a condition requires
    public Arm ArmRequired(Condition condition)
    {
        if (condition == Condition.Left ||
            condition == Condition.LeftSpread || condition == Condition.LeftFist)
        {
            return Arm.Left;
        }

        if (condition == Condition.Right || condition == Condition.RightSpread || condition == Condition.RightFist)
        {
            return Arm.Right;
        }
        return Arm.Unknown;
    }

    // Returns which pose, if any, a condition requires
    public Pose PoseRequired(Condition condition)
    {
        if (condition == Condition.Left || condition == Condition.Right)
        {
            return Pose.Unknown;
        }

        if (condition == Condition.LeftFist || condition == Condition.RightFist)
        {
            return Pose.Fist;
        }
        if (condition == Condition.LeftSpread || condition == Condition.RightSpread)
        {
            return Pose.FingersSpread;
        }

        return Pose.Unknown;
    }

    // Checks if a given arm is acceptable based on the beat's condition
    public bool ArmCheck(Arm touchedArm)
    {
        return touchedArm == ArmRequired(condition) || ArmRequired(condition) == Arm.Unknown;
    }

    // Checks if a given pose is acceptable based on the beat's condition
    public bool PoseCheck(Pose currentPose)
    {
        return PoseRequired(condition) == Pose.Unknown || currentPose == PoseRequired(condition);
    }
}
