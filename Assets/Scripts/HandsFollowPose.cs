using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using LockingPolicy = Thalmic.Myo.LockingPolicy;
using Pose = Thalmic.Myo.Pose;
using UnlockType = Thalmic.Myo.UnlockType;
using VibrationType = Thalmic.Myo.VibrationType;
using Arm = Thalmic.Myo.Arm;

public class HandsFollowPose : MonoBehaviour {
    public GameObject GameManager;
    private ThalmicMyo thalmicMyo;
    public Pose _lastPose = Pose.Unknown;

    Animator anim;
    int Idle = Animator.StringToHash("Idle");
    int Fist = Animator.StringToHash("Fist");

    /*
    int Point = Animator.StringToHash("Point");
    int GrabLarge = Animator.StringToHash("GrabLarge");
    int GrabSmall = Animator.StringToHash("GrabSmall");
    int GrabStickUp = Animator.StringToHash("GrabStickUp");
    int GrabStickFront = Animator.StringToHash("GrabStickFront");
    int ThumbUp = Animator.StringToHash("ThumbUp");
    int Gun = Animator.StringToHash("Gun");
    int GunShoot = Animator.StringToHash("GunShoot");
    int PushButton = Animator.StringToHash("PushButton");
    int Spread = Animator.StringToHash("Spread");
    int MiddleFinger = Animator.StringToHash("MiddleFinger");
    int Peace = Animator.StringToHash("Peace");
    int OK = Animator.StringToHash("OK");
    int Phone = Animator.StringToHash("Phone");
    int Rock = Animator.StringToHash("Rock");
    int Natural = Animator.StringToHash("Natural");
    int Number3 = Animator.StringToHash("Number3");
    int Number4 = Animator.StringToHash("Number4");
    int Number3V2 = Animator.StringToHash("Number3V2");
    int HoldViveController = Animator.StringToHash("HoldViveController");
    int PressTriggerViveController = Animator.StringToHash("PressTriggerViveController");
    int HoldOculusController = Animator.StringToHash("HoldOculusController");
    int PressTriggerOculusController = Animator.StringToHash("PressTriggerOculusController");
    */

    void Start()
    {
        GameManager = GameObject.FindGameObjectWithTag("GameManager");
        Arm arm = GetComponent<Controller>().arm;
        thalmicMyo = GameManager.GetComponent<MyoManager>().GetMyoByArm(arm);
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Debug.Log("Pose: " + thalmicMyo.pose.ToString());

		// Check if the pose has changed since last update.
		// The ThalmicMyo component of a Myo game object has a pose property that is set to the
		// currently detected pose (e.g. Pose.Fist for the user making a fist). If no pose is currently
		// detected, pose will be set to Pose.Rest. If pose detection is unavailable, e.g. because Myo
		// is not on a user's arm, pose will be set to Pose.Unknown.
		if (thalmicMyo.pose != _lastPose) {
			_lastPose = thalmicMyo.pose;


            bool fist = (thalmicMyo.pose == Pose.Fist);
            //Debug.Log(fist);
            if (fist)
            {
                Debug.Log("if");
                anim.SetTrigger(Fist);
            }
            
            else if(thalmicMyo.pose == Pose.Rest || thalmicMyo.pose == Pose.Unknown)
            {
                Debug.Log("else");
                anim.SetTrigger(Idle);
            }
            

            //	ExtendUnlockAndNotifyUserAction (thalmicMyo);
            /*

            // Change material when wave in, wave out or double tap poses are made.
        } else if (thalmicMyo.pose == Pose.WaveIn) {
            anim.SetTrigger(Gun);


            ExtendUnlockAndNotifyUserAction(thalmicMyo);
        } else if (thalmicMyo.pose == Pose.WaveOut) {
            anim.SetTrigger(OK);


            ExtendUnlockAndNotifyUserAction(thalmicMyo);
        } else if (thalmicMyo.pose == Pose.DoubleTap) {
            anim.SetTrigger(GunShoot);

            //ExtendUnlockAndNotifyUserAction (thalmicMyo);
        } else if (thalmicMyo.pose == Pose.Rest) {
            anim.SetTrigger(Natural);


        }

        else if (thalmicMyo.pose == Pose.FingersSpread) {
            anim.SetTrigger(Spread);


        }else if (thalmicMyo.pose == Pose.Unknown) {
            anim.SetTrigger(Idle);


        }
        */
        }
	}

    	// Extend the unlock if ThalmcHub's locking policy is standard, and notifies the given myo that a user action was
	// recognized.
	void ExtendUnlockAndNotifyUserAction(ThalmicMyo myo)
{
    ThalmicHub hub = ThalmicHub.instance;

    if (hub.lockingPolicy == LockingPolicy.Standard)
    {
        myo.Unlock(UnlockType.Timed);
    }

    myo.NotifyUserAction();
}
}
