using UnityEngine;
using System.Collections;

using LockingPolicy = Thalmic.Myo.LockingPolicy;
using Pose = Thalmic.Myo.Pose;
using UnlockType = Thalmic.Myo.UnlockType;
using VibrationType = Thalmic.Myo.VibrationType;
using Arm = Thalmic.Myo.Arm;

public class DummyAnimatorScript : MonoBehaviour
{
    public GameObject GameManager;
    private ThalmicMyo thalmicMyo;
    public Pose LastPose;
    public bool running;

    Animator anim;
    int Idle = Animator.StringToHash("Idle");
    int Fist = Animator.StringToHash("Fist");

    void Awake()
    {
        anim = GetComponent<Animator>();
        GameManager = GameObject.FindGameObjectWithTag("GameManager");
        Arm arm = GetComponent<Controller>().arm;
        thalmicMyo = GameManager.GetComponent<MyoManager>().GetMyoByArm(arm);

        StartCoroutine(Bullshit());

        //StartCoroutine(PoseRecognition());
        /*
        if(arm == Arm.Left)
        {
            GameManager.GetComponent<MyoManager>().leftArm = this;
        }
        else
        {
            GameManager.GetComponent<MyoManager>().rightArm = this;
        }
        */
    }
    
    IEnumerator Bullshit()
    {

        Debug.Log("Frustration");
        yield return null;
    }

    IEnumerator PoseRecognition()
    {
        while (true)
        {
            //if (thalmicMyo.pose == Pose.Unknown || thalmicMyo.pose == Pose.Rest)
            Debug.Log("Pose: " + thalmicMyo.pose);
            if(thalmicMyo.pose != Pose.Fist)
            {
                anim.SetTrigger(Idle);
                LastPose = Pose.Rest;
                Debug.Log("Dong");
                yield return new WaitForEndOfFrame();
            }

            if (thalmicMyo.pose == Pose.Fist)
            {
                anim.SetTrigger(Fist);
                LastPose = Pose.Fist;
            }
            Debug.Log("Ding");
            yield return new WaitForSeconds(.5f);
            yield return null;
        }
    }

    void Update()
    {

    }

}
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
    
    /*
        else if (Input.GetKeyDown(KeyCode.W))
        {
            anim.SetTrigger(Point);
            OculusController.SetActive(false);
            ViveController.SetActive(false);
            StickUp.SetActive(false);
            StickFront.SetActive(false);
        }

        else if (Input.GetKeyDown(KeyCode.E))
        {
            anim.SetTrigger(GrabLarge);
            OculusController.SetActive(false);
            ViveController.SetActive(false);
            StickUp.SetActive(false);
            StickFront.SetActive(false);
        }

        else if (Input.GetKeyDown(KeyCode.R))
        {
            anim.SetTrigger(GrabSmall);
            OculusController.SetActive(false);
            ViveController.SetActive(false);
            StickUp.SetActive(false);
            StickFront.SetActive(false);
        }

        else if (Input.GetKeyDown(KeyCode.T))
        {
            anim.SetTrigger(GrabStickUp);
            OculusController.SetActive(false);
            ViveController.SetActive(false);
            StickUp.SetActive(true);
            StickFront.SetActive(false);
        }

        else if (Input.GetKeyDown(KeyCode.Y))
        {
            anim.SetTrigger(GrabStickFront);
            OculusController.SetActive(false);
            ViveController.SetActive(false);
            StickUp.SetActive(false);
            StickFront.SetActive(true);
        }

        else if (Input.GetKeyDown(KeyCode.U))
        {
            anim.SetTrigger(ThumbUp);
            OculusController.SetActive(false);
            ViveController.SetActive(false);
            StickUp.SetActive(false);
            StickFront.SetActive(false);
        }



        else if (Input.GetKeyDown(KeyCode.O))
        {
            anim.SetTrigger(Gun);
            OculusController.SetActive(false);
            ViveController.SetActive(false);
            StickUp.SetActive(false);
            StickFront.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            anim.SetTrigger(GunShoot);
            OculusController.SetActive(false);
            ViveController.SetActive(false);
            StickUp.SetActive(false);
            StickFront.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            anim.SetTrigger(PushButton);
            OculusController.SetActive(false);
            ViveController.SetActive(false);
            StickUp.SetActive(false);
            StickFront.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            anim.SetTrigger(Spread);
            OculusController.SetActive(false);
            ViveController.SetActive(false);
            StickUp.SetActive(false);
            StickFront.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            anim.SetTrigger(MiddleFinger);
            OculusController.SetActive(false);
            ViveController.SetActive(false);
            StickUp.SetActive(false);
            StickFront.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            anim.SetTrigger(Peace);
            OculusController.SetActive(false);
            ViveController.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            anim.SetTrigger(OK);
            OculusController.SetActive(false);
            ViveController.SetActive(false);
            StickUp.SetActive(false);
            StickFront.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.H))
        {
            anim.SetTrigger(Phone);
            OculusController.SetActive(false);
            ViveController.SetActive(false);
            StickUp.SetActive(false);
            StickFront.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.J))
        {
            anim.SetTrigger(Rock);
            OculusController.SetActive(false);
            ViveController.SetActive(false);
            StickUp.SetActive(false);
            StickFront.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            anim.SetTrigger(Natural);
            OculusController.SetActive(false);
            ViveController.SetActive(false);
            StickUp.SetActive(false);
            StickFront.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            anim.SetTrigger(Number3);
            OculusController.SetActive(false);
            ViveController.SetActive(false);
            StickUp.SetActive(false);
            StickFront.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            anim.SetTrigger(Number4);
            OculusController.SetActive(false);
            ViveController.SetActive(false);
            StickUp.SetActive(false);
            StickFront.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            anim.SetTrigger(Number3V2);
            OculusController.SetActive(false);
            ViveController.SetActive(false);
            StickUp.SetActive(false);
            StickFront.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            anim.SetTrigger(HoldViveController);
            ViveController.SetActive(true);
            OculusController.SetActive(false);
            StickUp.SetActive(false);
            StickFront.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.V))
        {
            anim.SetTrigger(PressTriggerViveController);
            ViveController.SetActive(true);
            OculusController.SetActive(false);
            StickUp.SetActive(false);
            StickFront.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            anim.SetTrigger(HoldOculusController);
            OculusController.SetActive(true);
            ViveController.SetActive(false);
            StickUp.SetActive(false);
            StickFront.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.N))
        {
            anim.SetTrigger(PressTriggerOculusController);
            OculusController.SetActive(true);
            ViveController.SetActive(false);
            StickUp.SetActive(false);
            StickFront.SetActive(false);
        }
        */