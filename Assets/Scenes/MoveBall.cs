using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBall : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rigidbody;

    public Collider2D levier = null;

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
        rigidbody.velocity += new Vector2(0, 0);

        if (Input.GetKey(KeyCode.DownArrow)&& levier != null)
        {
            Debug.Log("nextlevel");
        }
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.tag == "levier")
        {
            levier = collider2D;

        }

    }

    private void OnTriggerExit2D(Collider2D collider2D)
    {
        if (collider2D.tag == "levier")
        {
            levier = null;

        }

    }

}