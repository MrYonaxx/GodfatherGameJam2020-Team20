using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : CharacterMovement
{
    [Header("Square")]
    [SerializeField]
    GameObject attackSquare;


    Moon charToRetrieve;
    Vector3 retrievePosition;
    bool canInput = true;

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        InputAttack();
        InputRetrieveCharacter();
    }

    protected override void InputMovement()
    {
        if (canInput == false)
            return;
        base.InputMovement();
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


    public void InputRetrieveCharacter()
    {
        if (player.GetButtonDown("Rotate") && canInput == true && charToRetrieve != null)
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
