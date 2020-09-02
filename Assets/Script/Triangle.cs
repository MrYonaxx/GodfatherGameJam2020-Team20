using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triangle : CharacterMovement
{
    [Header("Triangle")]


    [SerializeField]
    Transform transform;
    [SerializeField]
    GameObject hitboxNormal;

    bool isDown = false;




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
            // Debug
            /*if (isDown == true)
            {
                sprite.localEulerAngles = new Vector3(0, 0, -90);
                sprite.localPosition = new Vector3(0, 0.85f, 0);
            }
            else
            {
                sprite.localEulerAngles = new Vector3(0, 0, 0);
                sprite.localPosition = Vector3.zero;
            }*/
        }
        else if (isDown == true && player.GetButtonDown("Rotate"))
        {
            transform.localScale = new Vector3(transform.localScale.x * -1, 1, 1);
        }
    }



    public override void Push(float x, float y)
    {
        if (isDown == true)
            return;
        else
            base.Push(x, y);
    }

}
