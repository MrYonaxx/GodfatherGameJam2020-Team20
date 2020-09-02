using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class CharacterMovement : MonoBehaviour, IPushable
{
    [SerializeField]
    private int playerID = 0;

    [Header("Controller")]
    [SerializeField]
    private float leftStickSensibility = 0.5f;

    [Header("Parameter")]
    [SerializeField]
    private float speedMax = 10;

    [SerializeField]
    private float gravity = 5;

    [SerializeField]
    private float acceleration = 1;
    [SerializeField]
    private float decceleration = 2;


    CharacterController characterController;
    private float speedX = 0;
    private float speedY = 0;
    private Player player;

    float forceX = 0;
    float forceY = 0;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        player = ReInput.players.GetPlayer(playerID);
    }

    // Update is called once per frame
    void Update()
    {
        InputMovement();
        UpdateGravity();
        characterController.Move(new Vector3((speedX + forceX) * Time.deltaTime, (speedY + forceY) * Time.deltaTime));
        if (forceX != 0)
            forceX = 0;
        if (forceY != 0)
            forceY = 0;
    }

    private void InputMovement()
    {
        if (player == null)
            return;
        if(Mathf.Abs(player.GetAxis("MoveHorizontal")) > leftStickSensibility)
        {
            speedX += acceleration * Mathf.Sign(player.GetAxis("MoveHorizontal"));
            speedX = Mathf.Clamp(speedX, -speedMax, speedMax);
        }
        else
        {
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

    public void Push(float x, float y)
    {
        forceX = x;
        forceY = y;
    }
}
