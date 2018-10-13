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
        _steamVRController.TriggerClicked += PlayAnimationSteamVR;

        _controller = GetComponent<VRTK_ControllerEvents>();
        _controller.TriggerHairlineStart += PlayAnimation;
        _controller.TriggerPressed += PlayAnimation;

        _handsFollowPose = ObjectWithAnimator.GetComponent<HandsFollowPose>();
    }

    public void PlayAnimation(object sender, ControllerInteractionEventArgs e)
    {

        //SteamVR_Controller.Input((int)_steamVRController.controllerIndex).TriggerHapticPulse((ushort)9999);
        //Instantiate(AnimationPrefab, this.transform);
        _handsFollowPose.MakeFist();
        _timing = true;
        _timer = 0f;
    }

    public void PlayAnimationSteamVR(object sender, ClickedEventArgs e)
    {
        //SteamVR_Controller.Input((int)_steamVRController.controllerIndex).TriggerHapticPulse((ushort)9999);

        //Instantiate(AnimationPrefab, this.transform);
        _handsFollowPose.MakeFist();
    }

    void Update()
    {
        if (_controller.triggerTouched)
        {
            trigger = true;
            
        } else
        {
            trigger = false;
        }

        if (_timing)
        {
            _timer += Time.deltaTime;
            if(_timer > .2)
            {
                _timing = false;
                _timer = 0;
            }
        }
        else
        {
            _handsFollowPose.MakeIdle();
        }
    }
	
}
