using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using LockingPolicy = Thalmic.Myo.LockingPolicy;
using Pose = Thalmic.Myo.Pose;
using UnlockType = Thalmic.Myo.UnlockType;
using VibrationType = Thalmic.Myo.VibrationType;
using Arm = Thalmic.Myo.Arm;

public class HandsFollowPose : MonoBehaviour {
    public Animator anim;
    int Idle = Animator.StringToHash("Idle");
    int Fist = Animator.StringToHash("Fist");

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void MakeIdle()
    {
        if(anim != null)
        {

            anim.SetTrigger(Idle);
        }
    }

    public void MakeFist()
    {
        if(anim != null)
        {
            anim.SetTrigger(Fist);
        }
    }



}
