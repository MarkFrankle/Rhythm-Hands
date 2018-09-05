﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using Arm = Thalmic.Myo.Arm;
using LockingPolicy = Thalmic.Myo.LockingPolicy;
using Pose = Thalmic.Myo.Pose;
using UnlockType = Thalmic.Myo.UnlockType;
using VibrationType = Thalmic.Myo.VibrationType;

public class MyoManager : MonoBehaviour {
    // Myo game object to connect with.
    // This object must have a ThalmicMyo script attached.
    public GameObject myoHub;
    private ThalmicHub hub = null;
    public ThalmicMyo leftMyo = null;
    public ThalmicMyo rightMyo = null;

    public GameObject leftArmObject;
    public GameObject rightArmObject;
    public HandsFollowPose leftArm = null;
    public HandsFollowPose rightArm = null;

    public Pose LeftLastPose = Pose.Unknown;
    public Pose RightLastPose = Pose.Unknown;
    public bool TrackingPoses = false;
    bool paired = false;
    float _leftWaitingTime;
    bool _leftWaiting = false;
    float _rightWaitingTime;
    bool _rightWaiting = false;


    void Awake()
    {
    }
    void Update()
    {
        if (_leftWaiting)
        {
            _leftWaitingTime += Time.deltaTime;
            if(_leftWaitingTime > .5f)
            {
                _leftWaiting = false;
            }
        }
        if (_rightWaiting)
        {
            _rightWaitingTime += Time.deltaTime;
            if (_rightWaitingTime > .5f)
            {
                _rightWaiting = false;
            }
        }

        if (SceneManager.GetActiveScene().name == "TraditionalEndScreen")
        {
            TrackingPoses = false;
        }
            
        if (SceneManager.GetActiveScene().name == "Game" || SceneManager.GetActiveScene().name == "TestingGame")
        {
            if (leftArmObject == null || rightArmObject == null)
            {
                leftArmObject = GameObject.FindGameObjectWithTag("LeftController");
                rightArmObject = GameObject.FindGameObjectWithTag("RightController");
                if(leftArmObject != null && rightArmObject != null)
                {
                    leftArm = leftArmObject.GetComponent<HandsFollowPose>();
                    rightArm = rightArmObject.GetComponent<HandsFollowPose>();
                }
            }

            if(!(leftArm == null || rightArm == null)){
                if (leftMyo.pose == Pose.Fist)
                {
                    leftArm.MakeFist();
                    LeftLastPose = Pose.Fist;
                    _leftWaiting = true;
                    _leftWaitingTime = 0f;
                    
                }
                else if (!_leftWaiting)
                {
                    leftArm.MakeIdle();
                    LeftLastPose = Pose.Rest;
                }

                if (rightMyo.pose == Pose.Fist)
                {
                    rightArm.MakeFist();
                    RightLastPose = Pose.Fist;
                    _rightWaiting = true;
                    _rightWaitingTime = 0f;

                }
                else if (!_rightWaiting)
                {
                    rightArm.MakeIdle();
                    RightLastPose = Pose.Rest;
                }

            }
        }

        if (SceneManager.GetActiveScene().name == "NoteTesting")
        {
            NoteTesting();
        }
    }

    private void NoteTesting()
    {
        if (!paired)
        {
            PairMyos();
            if (MyoPairCheck())
                paired = true;
        }
        
        //if (leftArmObject == null || rightArmObject == null)
        //{
        //    leftArmObject = GameObject.FindGameObjectWithTag("LeftController");
        //    rightArmObject = GameObject.FindGameObjectWithTag("RightController");
        //    leftArm = leftArmObject.GetComponent<HandsFollowPose>();
        //    rightArm = rightArmObject.GetComponent<HandsFollowPose>();
        //    leftArm.MakeFist();
        //    rightArm.MakeFist();
        //}

        if (Input.GetKeyDown(KeyCode.U))
        {
            leftArm.MakeIdle();
            rightArm.MakeIdle();
        }

        else if (Input.GetKeyDown(KeyCode.I))
        {
            leftArm.MakeFist();
            rightArm.MakeFist();
        }

        if (paired && leftMyo.pose == Pose.Fist)
        {
            leftArm.MakeFist();
        }

        if (paired && rightMyo.pose == Pose.Fist)
        {
            rightArm.MakeFist();
        }

        if (paired && leftMyo.pose != Pose.Fist)
        {
            //leftArm.MakeIdle();
        }

        if (paired && rightMyo.pose != Pose.Fist)
        {
            //rightArm.MakeIdle();
        }
    }

    public Pose GetPoseByArm(Arm arm)
    {
        if(arm == Arm.Right)
        {
            return RightLastPose;
        }
        return LeftLastPose;
    }

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
