using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustPosition : MonoBehaviour {
    public GameObject VRRig;
    public GameObject NotesParent;
    public GameObject UICanvas;
    public GameObject RecordPlayers;
    public GameObject Headset;

    // TODO: Make private once acceptable
    public float _offsetY = .5f;
    public float _offsetZ = .5f;

    private bool _set = false;
    
    void Awake() {
    }

    void Update()
    {
        if (VRRig.activeSelf == true && !_set)
        {
            float headsetY = Headset.transform.position.y;
            float headsetZ = Headset.transform.position.z;
            if(NotesParent != null)
                NotesParent.transform.position = new Vector3(NotesParent.transform.position.x, headsetY - _offsetY, headsetZ + _offsetZ);
            if (UICanvas != null)
                UICanvas.transform.position = new Vector3(UICanvas.transform.position.x, headsetY, UICanvas.transform.position.z);
            if (RecordPlayers != null)
                RecordPlayers.transform.position = new Vector3(RecordPlayers.transform.position.x, headsetY - _offsetY, headsetZ + _offsetZ);
            _set = true;
        }

    }

}
