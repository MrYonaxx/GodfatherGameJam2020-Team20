﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShakeController : MonoBehaviour
{
    public static ScreenShakeController instance;
    // Pour l'appeller dans d'autre script :ScreenShakeController.instance.Startshake(xAmount, yAmount);
    private float shakeTimeRemaining;
    // Le temps que le Shake camera dure
    private float shakePower;
    // La puissance du Shake camera à
    private float shakeFadeTime;
    // 
    private float shakeRotation;
    // La valeur de rotaion du shake camera
    public float rotationMultiplier = 15f;

    Transform cam;
    Vector3 camOrigin;
    // 
    void Start()
    {
        cam = Camera.main.transform;
        camOrigin = Camera.main.transform.position;
        instance = this;
    }

    private void LateUpdate()
    {
        if (cam == null)
        {
            cam = Camera.main.transform;
            camOrigin = Camera.main.transform.position;
        }
        if (shakeTimeRemaining > 0)
        {

            shakeTimeRemaining -= Time.deltaTime;

            float xAmount = Random.Range(-1f, 1f) * shakePower;

            float yAmount = Random.Range(-1f, 1f) * shakePower;

            cam.transform.position += new Vector3(xAmount, yAmount, 0f);

            shakePower = Mathf.MoveTowards(shakePower, 0f, shakeFadeTime * Time.deltaTime);

            shakeRotation = Mathf.MoveTowards(shakeRotation, 0f, shakeFadeTime * rotationMultiplier * Time.deltaTime);
        }

        cam.rotation = Quaternion.Euler(0f, 0f, shakeRotation * Random.Range(-1f, 1f));
        cam.transform.position = camOrigin;
    }
    public void StartShake(float lenght, float power)
    {
        shakeTimeRemaining = lenght;

        shakePower = power;

        shakeFadeTime = power / lenght;

        shakeRotation = power * rotationMultiplier;
    }
}
