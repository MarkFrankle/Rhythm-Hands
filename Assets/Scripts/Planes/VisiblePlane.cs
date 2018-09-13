﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisiblePlane : MonoBehaviour {
    public static VisiblePlane instance;

    public Vector3 PlanePosition;

    private void Awake()
    {
        if(instance == null){
            instance = this;
        }
        else if(instance != this){
            Destroy(gameObject);
        }

    }

    private void OnEnable()
    {
        PlanePosition = transform.position;
    }
}
