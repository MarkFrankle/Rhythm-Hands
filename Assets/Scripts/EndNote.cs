using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pose = Thalmic.Myo.Pose;

public class EndNote : Note {

    private EndOfGame eog;

	void Awake()
    {
        AwakeTasks();
        eog = gameManager.GetComponent<EndOfGame>();
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "DestroyPlane")
        {
            eog.SwitchEndScreen();
        }
    }

    protected override void MakeVisible()
    {
        if (RequiredPose == Pose.Unknown)
        {
            GetComponent<MeshRenderer>().enabled = true;
        }
        else
        {
            Hand.GetComponent<SkinnedMeshRenderer>().enabled = true;
            Sleeve.GetComponent<MeshRenderer>().enabled = true;
        }
    }

    protected override void MakeInvisible()
    {
        if (RequiredPose == Pose.Unknown)
        {
            GetComponent<MeshRenderer>().enabled = false;
        }
        else
        {
            Hand.GetComponent<SkinnedMeshRenderer>().enabled = false;
            Sleeve.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
