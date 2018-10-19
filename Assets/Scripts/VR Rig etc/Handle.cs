using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Manages how handles react when touched
 * 
 * When a controller collides with a handle, if it's gripping, then an effect plays
 * 
 */
public class Handle : MonoBehaviour {
    public GameObject GrabEffectPrefab;

    private GameObject _currentEffect = null;

    public PlayAnimationOnTrigger triggerCheck;

    void Start()
    {

        //public event ClickedEventHandler TriggerClicked;
        //public delegate void ClickedEventHandler(object sender, ClickedEventArgs e);
        //_steamVRController.TriggerClicked += MakeFist;
        //public void MakeFist(object sender, ClickedEventArgs e)

    //public event OnAttachedToHandDelegate onAttachedToHand;
    //public delegate void OnAttachedToHandDelegate(Hand hand);


    }

    public void MakeGlow(Valve.VR.InteractionSystem.Hand hand)
    {
    }

    //void OnTriggerEnter(Collider col)
    //{
    //    Debug.Log("Entered" + gameObject.name);

    //    if(col.gameObject.tag == "LeftController" || col.gameObject.tag == "RightController")
    //    {
    //        triggerCheck = col.transform.parent.gameObject.GetComponent<PlayAnimationOnTrigger>();

    //        if (triggerCheck.trigger && _currentEffect == null)
    //        {
    //            _currentEffect = Instantiate(GrabEffectPrefab, this.transform);
    //        }
    //    }
    //}

    //void OnTriggerExit(Collider col)
    //{
    //    Debug.Log("Left" + gameObject.name);

    //    if (col.gameObject.tag == "LeftController" || col.gameObject.tag == "RightController")
    //    {
    //        if(_currentEffect != null)
    //        {
    //            Destroy(_currentEffect);
    //            _currentEffect = null;
    //        }
    //    }
    //}
}
