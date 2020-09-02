using System.Collections;
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
    Transform transform;
    [SerializeField]
    GameObject hitboxNormal;
    [SerializeField]
    GameObject hitboxCollision;


    private MoonState moonState;

    bool inWater = false;

    public int directionX = 1;

    protected override void Update()
    {
        base.Update();
        InputLieDown();
        InputBoat();
    }


    protected override void InputMovement()
    {
        if (moonState == MoonState.Down || moonState == MoonState.Boat)
            return;
        base.InputMovement();

        if (speedX != 0)
        {
            directionX = (int)Mathf.Sign(speedX);
            transform.localScale = new Vector3(directionX, 1, 1);
        }
    }


    private void InputLieDown()
    {
        if (player.GetButtonDown("Action"))
        {
            if (moonState == MoonState.Normal)
            {
                SetState(MoonState.Down);
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
            if (moonState == MoonState.Down)
            {
                SetState(MoonState.Boat);
            }
            else if (moonState == MoonState.Boat)
            {
                SetState(MoonState.Down);
            }
        }
    }

    private void SetState(MoonState state)
    {
        moonState = state;
        switch (moonState)
        {
            case MoonState.Normal:
                animator.SetBool("LieDown", false);
                animator.SetBool("Boat", false);
                hitboxNormal.SetActive(true);
                hitboxCollision.SetActive(false);
                characterController.enabled = true;
                break;
            case MoonState.Down:
                animator.SetBool("LieDown", true);
                animator.SetBool("Boat", false);
                hitboxNormal.SetActive(false);
                hitboxCollision.SetActive(true);
                characterController.enabled = false;
                break;
            case MoonState.Boat:
                animator.SetBool("LieDown", true);
                animator.SetBool("Boat", true);
                hitboxNormal.SetActive(true);
                hitboxCollision.SetActive(false);
                characterController.enabled = true;
                break;
        }
    }


    public override void Push(float x, float y)
    {
        if (moonState == MoonState.BoatInWater || moonState == MoonState.Down)
            return;
        base.Push(x, y);
    }

    public void SetInWater(bool b)
    {
        inWater = b;
    }

}
