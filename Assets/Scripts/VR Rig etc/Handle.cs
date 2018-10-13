using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handle : MonoBehaviour {

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("Entered" + gameObject.name);
    }
}
