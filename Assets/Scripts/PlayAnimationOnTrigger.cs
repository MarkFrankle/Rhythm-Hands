using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class PlayAnimationOnTrigger : MonoBehaviour {
    public GameObject ObjectWithAnimator;
    private VRTK_ControllerEvents _controller;
    public GameObject AnimationPrefab;
    private SteamVR_TrackedController _steamVRController;

    public bool trigger; 

    void Start()
    {
        _steamVRController = GetComponent<SteamVR_TrackedController>();
        _steamVRController.TriggerClicked += PlayAnimationSteamVR;

        _controller = GetComponent<VRTK_ControllerEvents>();
        _controller.TriggerHairlineStart += PlayAnimation;
        _controller.TriggerPressed += PlayAnimation;


    }

    public void PlayAnimation(object sender, ControllerInteractionEventArgs e)
    {
        
        //SteamVR_Controller.Input((int)_steamVRController.controllerIndex).TriggerHapticPulse((ushort)9999);
        Instantiate(AnimationPrefab, this.transform);
    }

    public void PlayAnimationSteamVR(object sender, ClickedEventArgs e)
    {
        //SteamVR_Controller.Input((int)_steamVRController.controllerIndex).TriggerHapticPulse((ushort)9999);

        Instantiate(AnimationPrefab, this.transform);
    }

    void Update()
    {
        if (_controller.triggerTouched)
        {
            trigger = true;
            PlayAnimation(this, new ControllerInteractionEventArgs());
        } else
        {
            trigger = false;
        }

    }
	
}
