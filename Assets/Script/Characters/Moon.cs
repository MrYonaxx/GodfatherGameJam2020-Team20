﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum MoonState
{
    Normal,
    Down,
    Boat,
    BoatInWater
}



public class Moon : CharacterMovement
{
    [Header("Moon")]
    [SerializeField]
    Transform transformRotation;
    [SerializeField]
    GameObject hitboxNormal;
    [SerializeField]
    GameObject hitboxCollision;
    [SerializeField]
    GameObject movingPlatform;
    [SerializeField]
    GameObject moonRetriever;
    [SerializeField]
    CharacterRotation characterRotation;

    [SerializeField]
    float wallDetectionLenght = 1f;

    bool canInput = true;
    private MoonState moonState;

    bool inWater = false;

    private Vector2 waterClamp;

    protected override void Update()
    {
        if (canInput == false)
            return;
        if(moonState == MoonState.BoatInWater)
        {
            InputMovement();
            SetDirection();
            UpdateWater();
            return;
        }
        base.Update();
        InputLieDown();
        InputBoat();
    }


    protected override void InputMovement()
    {
        if (moonState == MoonState.Down || moonState == MoonState.Boat)
            return;
        base.InputMovement();
    }
    protected override void SetDirection()
    {
        if (speedX != 0)
        {
            directionX = (int)Mathf.Sign(speedX);
            transformRotation.localScale = new Vector3(directionX, 1, 1);
        }
    }


    private void InputLieDown()
    {
        if (player.GetButtonDown("Action"))
        {
            if (moonState == MoonState.Normal)
            {
                SetValidDirection();
                SetState(MoonState.Down);
                sfx.ReturnHalfMoon();
            }
            else if (moonState == MoonState.Down || moonState == MoonState.Boat)
            {
                SetState(MoonState.Normal);
            }
        }
    }

    private void InputBoat()
    {
        if (player.GetButtonDown("Rotate"))
        {
            if (moonState == MoonState.Down && inWater == false)
            {
                SetState(MoonState.Boat);

            }
            else if (moonState == MoonState.Down && inWater == true)
            {
                SetState(MoonState.BoatInWater);
            }
            else if (moonState == MoonState.Boat)
            {
                SetState(MoonState.Down);
            }
        }
    }


    private void SetValidDirection()
    {
        int layerMask = 1 << 0;

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position + new Vector3(0,0.1f,0), Vector3.right, out hit, wallDetectionLenght, layerMask))
        {
            //Debug.Log(hit.collider.gameObject.name);
            directionX = -1;
        }
        else if (Physics.Raycast(transform.position + new Vector3(0, 0.1f, 0), Vector3.left, out hit, wallDetectionLenght, layerMask))
        {
            //Debug.Log(hit.collider.gameObject.name);
            directionX = 1;
        }
        transformRotation.localScale = new Vector3(directionX, 1, 1);
    }

    private void SetState(MoonState state)
    {
        moonState = state;
        switch (moonState)
        {
            // Oskour
            case MoonState.Normal:
                animator.SetBool("LieDown", false);
                animator.SetBool("Boat", false);
                hitboxNormal.SetActive(true);
                hitboxCollision.SetActive(false);
                characterController.enabled = true;
                movingPlatform.SetActive(false);
                moonRetriever.SetActive(false);
                characterRotation.enabled = true;
                break;
            case MoonState.Down:
                animator.SetBool("LieDown", true);
                animator.SetBool("Boat", false);
                hitboxNormal.SetActive(false);
                hitboxCollision.SetActive(true);
                characterController.enabled = false;
                movingPlatform.SetActive(false);
                moonRetriever.SetActive(true);
                characterRotation.enabled = true;
                break;
            case MoonState.Boat:
                animator.SetBool("LieDown", true);
                animator.SetBool("Boat", true);
                hitboxNormal.SetActive(true);
                hitboxCollision.SetActive(false);
                characterController.enabled = true;
                movingPlatform.SetActive(false);
                moonRetriever.SetActive(false);
                characterRotation.enabled = true;
                break;
            case MoonState.BoatInWater:
                animator.SetBool("LieDown", true);
                animator.SetBool("Boat", true);
                hitboxNormal.SetActive(false);
                hitboxCollision.SetActive(false);
                characterController.enabled = false;
                movingPlatform.SetActive(true);
                moonRetriever.SetActive(true);
                characterRotation.enabled = false;
                break;
        }
    }


    public override void Push(float x, float y)
    {
        if (moonState == MoonState.BoatInWater || moonState == MoonState.Down)
            return;
        base.Push(x, y);
    }

    public void SetInWater(Vector2 waterSize)
    {
        animator.SetTrigger("Water");
        SetState(MoonState.BoatInWater);
        waterClamp = waterSize;
        sfx.waterRowboatMode();
    }

    public void ResetState()
    {
        SetState(MoonState.Normal);
    }

    public void LerpPosition(Vector3 pos)
    {
        StartCoroutine(LerpPositionCoroutine(pos));
    }
    private IEnumerator LerpPositionCoroutine(Vector3 pos)
    {
        characterController.enabled = false;
        characterController.detectCollisions = false;
        canInput = false;
        float t = 0f;
        Vector3 origin = this.transform.position;
        while(t<1f)
        {
            t += Time.deltaTime * 2;
            this.transform.position = Vector3.Lerp(this.transform.position, pos, t);
            yield return null;
        }
        canInput = true;
        characterController.detectCollisions = true;
        characterController.enabled = true;
    }

    private void UpdateWater()
    {
        this.transform.position += new Vector3(speedX * Time.deltaTime, 0);
        this.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x, waterClamp.x, waterClamp.y), this.transform.position.y, 0);
    }

    protected override bool PreventFall()
    {
        if (base.PreventFall() == true)
        {
            if (hit.collider.tag == "NoFallWater")
                return false;
        }
        return base.PreventFall();

    }

}
