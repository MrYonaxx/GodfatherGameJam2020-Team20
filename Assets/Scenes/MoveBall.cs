using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBall : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rigidbody;

    private void Update()
    {
        if(Input.GetKey("right"))
        {
            rigidbody.velocity += new Vector2(1, 0);
        }
        else if (Input.GetKey("left"))
        {
            rigidbody.velocity -= new Vector2(1, 0);
        }
        rigidbody.velocity += new Vector2(0, 1);
    }
}
