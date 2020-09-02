using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class CharacterMovementRigidbody : MonoBehaviour
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
    private float gravity = -2;

    [SerializeField]
    private float acceleration = 1;
    [SerializeField]
    private float decceleration = 2;


    Rigidbody2D rigidbody;
    private float speedX = 0;
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.freezeRotation = true;
        //rigidbody.gravityScale = 0;
        player = ReInput.players.GetPlayer(playerID);
    }


    private void InputMovement()
    {
        if (player == null)
            return;
        if (Mathf.Abs(player.GetAxis("MoveHorizontal")) > leftStickSensibility)
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

    void Update()
    {
        InputMovement();

        // Apply a force that attempts to reach our target velocity
        float velocityX = rigidbody.velocity.x;
        float finalSpeed = (speedX - velocityX);
        finalSpeed = Mathf.Clamp(finalSpeed, -speedMax, speedMax);

        // We apply gravity manually for more tuning control
        rigidbody.AddForce(new Vector3(finalSpeed, -gravity * rigidbody.mass, 0));

    }




}
