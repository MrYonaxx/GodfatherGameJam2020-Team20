﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triangle : CharacterMovement
{
    [Header("Triangle")]

    [SerializeField]
    float wallDetectionLenght;
    [SerializeField]
    Transform transform;
    [SerializeField]
    GameObject hitboxNormal;

    bool isDown = false;
    public int direction = 1;


    Moon charToRetrieve;
    Vector3 retrievePosition;

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        InputLieDown();
        InputRetrieveCharacter();
    }


    protected override void InputMovement()
    {
        if (isDown == true)
            return;
        base.InputMovement();
    }

    protected override void SetDirection()
    {
        if (speedX != 0)
        {
            if((int)Mathf.Sign(speedX) != directionX)
                sfx.ReturnTriangle();
            directionX = (int)Mathf.Sign(speedX);
            transform.localScale = new Vector3(directionX, 1, 1);
        }
    }
    private void InputLieDown()
    {
        if(player.GetButtonDown("Action"))
        {
            isDown = !isDown;
            //hitboxDown.SetActive(isDown);
            hitboxNormal.SetActive(!isDown);
            characterController.enabled = !isDown;
            animator.SetBool("LieDown", isDown);
            if (isDown == true)
            {
                SetValidDirection();
                sfx.HorizontalTriangle();
            }
        }
        else if (isDown == true && player.GetButtonDown("Rotate"))
        {
            direction = -direction;
            CheckDirection(direction);
            sfx.SwapHorizontalTriangle();
        }
    }

    // Call by unity Event
    public void StandUp()
    {
        isDown = false;
        hitboxNormal.SetActive(!isDown);
        characterController.enabled = !isDown;
        animator.SetBool("LieDown", isDown);
    }


    private void SetValidDirection()
    {
        int layerMask = 1 << 0;

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, Vector3.right, out hit, wallDetectionLenght, layerMask))
        {
            direction = -1;
        }
        else if (Physics.Raycast(transform.position, Vector3.left, out hit, wallDetectionLenght, layerMask))
        {
            direction = 1;
        }
        transform.localScale = new Vector3(direction, 1, 1);
    }

    private void CheckDirection(int direction)
    {
        int layerMask = 1 << 0;
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, Vector3.right * direction, out hit, wallDetectionLenght, layerMask))
        {
            direction = -direction;
        }
        transform.localScale = new Vector3(direction, 1, 1);
    }


    public override void Push(float x, float y)
    {
        if (isDown == true)
            return;
        else
            base.Push(x, y);
    }




    private IEnumerator AttackCoroutine()
    {
        yield return new WaitForSeconds(1f);
    }

    public void InputRetrieveCharacter()
    {
        if (player.GetButtonDown("Rotate") && isDown == false && charToRetrieve != null)
        {
            charToRetrieve.LerpPosition(new Vector3(retrievePosition.x, animator.transform.position.y));
            charToRetrieve.ResetState();
            StartCoroutine(AttackCoroutine());
        }
    }

    public void AssignMoon(Moon c, Vector3 v)
    {
        charToRetrieve = c;
        retrievePosition = v;
    }


}
