﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class CharacterMovement : MonoBehaviour, IPushable
{
    [SerializeField]
    protected int playerID = 0;

    [Header("Controller")]
    [SerializeField]
    protected Animator animator;

    [Header("Controller")]
    [SerializeField]
    protected float leftStickSensibility = 0.5f;

    [Header("Parameter")]
    [SerializeField]
    protected float speedMax = 10;
    [SerializeField]
    protected float gravity = 5;
    [SerializeField]
    protected float acceleration = 1;
    [SerializeField]
    protected float decceleration = 2;

    [Header("PreventFall")]
    [SerializeField]
    protected float raycastLenght = 1f;

    [Header("Sounds")]
    [SerializeField]
    public SfxProvider sfx;
    [SerializeField]
    public float footstepInterval;

    protected CharacterController characterController;
    protected float speedX = 0;
    protected float speedY = 0;
    protected Player player;

    protected Vector3 move;

    protected float forceX = 0;
    protected float forceY = 0;

    private IEnumerator footstepCoroutine;

    public void SetPosition(Vector3 pos)
    {
        characterController.enabled = false;
        this.transform.position = pos;
        characterController.enabled = true;
    }




    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        player = ReInput.players.GetPlayer(playerID);
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        InputMovement();
        UpdateGravity();
        move = new Vector3((speedX + forceX) * Time.deltaTime, (speedY + forceY) * Time.deltaTime);
        if (PreventFall() == true)
            move = Vector3.zero;
        if (characterController.enabled == true && move != Vector3.zero) // A faire plus propre si j'ai le temps
            characterController.Move(move);
        if (forceX != 0)
            forceX = 0;
        if (forceY != 0)
            forceY = 0;

        // Mal rangé ça 
        if(player.GetButtonDown("Reset"))
        {
            GameManager.instance.ReloadScene();
        }
    }

    protected virtual void InputMovement()
    {
        if (player == null)
            return;
        if(Mathf.Abs(player.GetAxis("MoveHorizontal")) > leftStickSensibility)
        {
            if(animator != null)
                animator.SetBool("Walk", true);
            speedX += acceleration * Mathf.Sign(player.GetAxis("MoveHorizontal"));
            speedX = Mathf.Clamp(speedX, -speedMax, speedMax);
            if (footstepCoroutine == null) 
            {
                footstepCoroutine = FootstepCoroutine();
                StartCoroutine(footstepCoroutine);
            }
        }
        else
        {
            if (animator != null)
                animator.SetBool("Walk", false);
            speedX -= decceleration * Mathf.Sign(speedX);
            if (Mathf.Abs(speedX) <= decceleration)
                speedX = 0;
            StopFootstepCoroutine();
        }

    }

    private void UpdateGravity()
    {
        if (characterController.isGrounded == false)
        {
            speedY = -gravity;
        }
        else
        {
            speedY = 0;
        }
    }






    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.CompareTag("Player"))
        {
            IPushable collision = hit.gameObject.GetComponent<IPushable>();
            if(collision != null)
                collision.Push(speedX, hit.moveDirection.y);
        }
    }

    public virtual void Push(float x, float y)
    {
        forceX = x;
        forceY = y;
    }


    private IEnumerator FootstepCoroutine()
    {
        float t = 0;
        while(true)
        {
            t = 0f;
            sfx.WalkSquare();
            while (t <= footstepInterval)
            {
                t += Time.deltaTime;
                yield return null;
            }

        }
    }

    protected void StopFootstepCoroutine()
    {
        if (footstepCoroutine != null)
            StopCoroutine(footstepCoroutine);
    }


    protected virtual bool PreventFall()
    {
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 0;
        if (Physics.Raycast(transform.position, Vector3.down, raycastLenght, layerMask))
        {
            // On est au sol (presqe) donc on doit lancer un autre raycast en avant
            layerMask = 1 << 0;
            layerMask = ~layerMask;
            RaycastHit hit;
            if (Physics.Raycast(transform.position + new Vector3(move.x, 0, 0), Vector3.down, raycastLenght, layerMask))
            {
                // On a touché le layer NoFall faut stop
                return true;
            }
            else
            {
                // Y'a rien on tombe
                return false;
            }
        }
        else // On est au dessus du vide, c'est deja perdu on tombe
            return false;

    }


}
