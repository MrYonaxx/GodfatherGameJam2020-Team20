using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float Speed = 10f;
    // Start is called before the first frame update
    [SerializeField]
    Rigidbody2D rg2d;
    void Start()
    {
        rg2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("right"))
        {
            rg2d.velocity +=  new Vector2(Speed, 0);
        }
        if (Input.GetKey("left"))
        {
            rg2d.velocity -= new Vector2(Speed, 0);
        }
    }
}
