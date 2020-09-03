using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    private Transform cam;

    private float startY;

    void Awake()
    {
        cam = Camera.main.transform;
    }

    void Start()
    {
        startY = transform.position.y;
    }
}
