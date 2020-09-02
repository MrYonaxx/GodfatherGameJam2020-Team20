using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPushable : MonoBehaviour, IPushable
{
    [SerializeField]
    float mass = 5;

    Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    public void Push(float x, float y)
    {
        rigidbody.AddForce(new Vector3(x * mass * Time.deltaTime, 0, 0));
    }
}
