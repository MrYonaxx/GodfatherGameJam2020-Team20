using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : CharacterMovement
{
    [Header("Square")]
    [SerializeField]
    GameObject attackSquare;

    bool canInput = true;

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        InputAttack();
    }

    public void InputAttack()
    {
        if (player.GetButtonDown("Action") && canInput == true)
        {
            animator.SetTrigger("Stomp");
            canInput = false;
            StartCoroutine(AttackCoroutine());
        }
    }

    private IEnumerator AttackCoroutine()
    {
        yield return new WaitForSeconds(1f);
        canInput = true;
    }


}
