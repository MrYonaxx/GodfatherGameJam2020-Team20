﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Transform cam;

    private float startY;

    void Awake()
    {
        cam = Camera.main.transform;
    }

    void Start()
    {

        startY = transform.position.y;

    }

    void Update()
    {
        if (target != null)
        {

            cam.position = new Vector3(target.position.x, startY, transform.position.z);

        }
    }
}
