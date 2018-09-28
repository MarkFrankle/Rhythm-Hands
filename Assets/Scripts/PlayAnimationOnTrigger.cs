using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class PlayAnimationOnTrigger : MonoBehaviour {
    public GameObject ObjectWithAnimator;
    private VRTK_ControllerEvents _controller;
    public GameObject AnimationPrefab;

    void Start()
    {
        _controller = GetComponent<VRTK_ControllerEvents>();
        _controller.TriggerHairlineStart += PlayAnimation;
    }

    public void PlayAnimation(object sender, ControllerInteractionEventArgs e)
    {
        Instantiate(AnimationPrefab, this.transform);
    }
	
}
