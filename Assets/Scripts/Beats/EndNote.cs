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

    }

    protected override void MakeInvisible()
    {

    }
}
