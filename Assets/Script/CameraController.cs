using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;

    public Transform target;

    private float startY;

    void Awake()
    {

        instance = this;
    }

    void Start()
    {

        startY = transform.position.y;

    }

    void Update()
    {
        if (target != null)
        {

            transform.position = new Vector3(target.position.x, startY, transform.position.z);

        }
    }
}
