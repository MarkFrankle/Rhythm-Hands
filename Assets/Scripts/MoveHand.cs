using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHand : MonoBehaviour {
    // public Vector3 velocity;

    public Rigidbody rb;

	void Awake()
    {
        rb = GetComponent<Rigidbody>();
        //GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -1f);
    }

    void FixedUpdate()
    {
        rb.MovePosition(transform.position + transform.right * Time.deltaTime * .1f);
    }
}
