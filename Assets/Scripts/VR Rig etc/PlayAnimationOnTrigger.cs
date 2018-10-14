using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class PlayAnimationOnTrigger : MonoBehaviour {
    public GameObject ObjectWithAnimator;
    private HandsFollowPose _handsFollowPose;
    private VRTK_ControllerEvents _controller;
    public GameObject AnimationPrefab;
    private SteamVR_TrackedController _steamVRController;

    public bool trigger;

    private float _timer = 0f;
    private bool _timing = false;
    private bool _idle = true;

    void Start()
    {
        _steamVRController = GetComponent<SteamVR_TrackedController>();
        _steamVRController.TriggerClicked += MakeFist;
        _steamVRController.TriggerUnclicked += MakeIdle;


        _handsFollowPose = ObjectWithAnimator.GetComponent<HandsFollowPose>();
    }

    public void MakeFist(object sender, ClickedEventArgs e)
    {
        _handsFollowPose.MakeFist();
        trigger = true;
    }

    public void MakeIdle(object sender, ClickedEventArgs e)
    {
        _handsFollowPose.MakeIdle();
        trigger = false;
    }

    void Update()
    {
        
    }
	
}
