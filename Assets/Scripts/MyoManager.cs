using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Arm = Thalmic.Myo.Arm;
using LockingPolicy = Thalmic.Myo.LockingPolicy;
using Pose = Thalmic.Myo.Pose;
using UnlockType = Thalmic.Myo.UnlockType;
using VibrationType = Thalmic.Myo.VibrationType;

public class MyoManager : MonoBehaviour {
    // Myo game object to connect with.
    // This object must have a ThalmicMyo script attached.
    public GameObject myoHub;
    public ThalmicMyo leftMyo = null;
    public ThalmicMyo rightMyo = null;
    //public DummyAnimatorScript leftArm;
    //public DummyAnimatorScript rightArm;
    private ThalmicHub hub = null;
    /*
    public bool PoseCheck(Arm arm, Pose requiredPose)
    {
        Pose currentPose;
        if(arm == Arm.Left)
        {
            currentPose = leftArm.LastPose;
        }
        else
        {
            currentPose = rightArm.LastPose;
        }
        return (currentPose == requiredPose);
    }
    */
    public void PairMyos()
    {
        if(hub == null)
        {
            hub = ThalmicHub.instance;
        }

        if(leftMyo == null || rightMyo == null)
        {
            List<ThalmicMyo> myos = hub.Myos;
            foreach(ThalmicMyo myo in myos)
            {
                Debug.Log("Getting Myos. Current: " + myo.arm);
                if(myo.arm == Thalmic.Myo.Arm.Right)
                {
                    rightMyo = myo;
                } else
                {
                    leftMyo = myo;
                }
            }
        }
        MyoPairCheck();
    }

    public ThalmicMyo GetMyoByArm(Arm arm)
    {
        ThalmicMyo returnMyo = (arm == Arm.Left) ? leftMyo : rightMyo;
        return returnMyo;
    }

    public void VibrateMyo(Arm arm)
    {
        if(arm == Arm.Left)
        {
            leftMyo.Vibrate(VibrationType.Short);
        }
        else
        {
            rightMyo.Vibrate(VibrationType.Short);
        }
    }

    public bool MyoPairCheck()
    {
        ThalmicHub hub = ThalmicHub.instance;

        if (!hub.hubInitialized)
        {
            // Hub is not working
            Debug.LogError("Hub is not initialized");
            return false;
        }

        if (hub.Myos.Count != 2)
        {
            // Hub is working but need two myos
            Debug.LogError("Hub is working but two Myo bands needed");
            return false;
        }

        if (rightMyo == null || leftMyo == null)
        {
            Debug.LogError("Left and right bands not set in myo manager");
            return false;
        }
        
        foreach(ThalmicMyo myo in hub.Myos)
        {
            if (!myo.armSynced)
            {
                Arm nonSyncedArm = myo.arm;
                Debug.LogError("Myo not synced on " + nonSyncedArm.ToString() + " arm");
                return false;
            }
        }

        return true;
    }
}
