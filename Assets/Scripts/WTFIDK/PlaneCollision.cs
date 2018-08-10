using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneCollision : MonoBehaviour {

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("Trigger!");
        //Debug.Log("Tag: " + col.gameObject.tag);
        if (col.gameObject.tag == "DestroyPlane")
        {
            Destroy(this.gameObject);
        }
        else if (col.gameObject.tag == "ValidPlane")
        {
            GetComponent<Note>().isValid = true;
        }
}
}
