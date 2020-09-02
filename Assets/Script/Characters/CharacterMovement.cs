using System.Collections;
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

    // Debug
    protected int playerIDDebug = 0;
    protected Player playerDebug;
    //

    protected CharacterController characterController;
    protected float speedX = 0;
    protected float speedY = 0;
    protected Player player;


    protected float forceX = 0;
    protected float forceY = 0;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        player = ReInput.players.GetPlayer(playerID);

        if (playerID == 0)
            playerIDDebug = 1;
        playerDebug = ReInput.players.GetPlayer(playerID);

    }

    // Update is called once per frame
    protected virtual void Update()
    {
        InputMovement();
        UpdateGravity();
        if(characterController.enabled == true) // A faire plus propre si j'ai le temps
            characterController.Move(new Vector3((speedX + forceX) * Time.deltaTime, (speedY + forceY) * Time.deltaTime));
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
        }
        else
        {
            if (animator != null)
                animator.SetBool("Walk", false);
            speedX -= decceleration * Mathf.Sign(speedX);
            if (Mathf.Abs(speedX) <= decceleration)
                speedX = 0;
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

}
