using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/**
 * Tells the hands to make poses
 */
public class HandsFollowPose : MonoBehaviour {
    public Animator anim;
    int Idle = Animator.StringToHash("Idle");
    int Fist = Animator.StringToHash("Fist");
    int Spread = Animator.StringToHash("Spread");

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


    public void MakeSpread()
    {
        if (anim != null)
        {
            anim.SetTrigger(Spread);
        }
    }


}
