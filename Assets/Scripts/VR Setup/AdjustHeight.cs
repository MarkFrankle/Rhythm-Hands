using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustHeight : MonoBehaviour {
    public GameObject NotesParent;
    public GameObject UICanvas;
    public GameObject RecordPlayers;
    public GameObject Headset;

    // TODO: Make private once acceptable
    public float _offset = .5f;

    private bool _set = false;
    
    void Awake() {
    }

    void Update()
    {
        if (!_set)
        {
            float headsetY = Headset.transform.position.y;
            NotesParent.transform.position = new Vector3(NotesParent.transform.position.x, headsetY, NotesParent.transform.position.z);
            UICanvas.transform.position = new Vector3(UICanvas.transform.position.x, headsetY, UICanvas.transform.position.z);
            RecordPlayers.transform.position = new Vector3(RecordPlayers.transform.position.x, headsetY - _offset, RecordPlayers.transform.position.z);
            _set = true;
        }

    }

}
