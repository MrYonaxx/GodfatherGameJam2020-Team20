using System.Collections;
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




    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        InputLieDown();
    }


    protected override void InputMovement()
    {
        if (isDown == true)
            return;
        base.InputMovement();

        if (speedX != 0)
        {
            direction = (int)Mathf.Sign(speedX);
            transform.localScale = new Vector3(direction, 1, 1);
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
            if(isDown == true)
                SetDirection();
        }
        else if (isDown == true && player.GetButtonDown("Rotate"))
        {
            direction = -direction;
            CheckDirection(direction);
        }
    }


    private void SetDirection()
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

}
