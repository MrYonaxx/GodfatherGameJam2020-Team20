using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        other.transform.SetParent(this.transform);
        CharacterMovement c = other.GetComponent<CharacterMovement>();
        if (c != null)
            c.SetOnMovingPlatform(true);

    }

    private void OnTriggerExit(Collider other)
    {
        other.transform.SetParent(null);

        CharacterMovement c = other.GetComponent<CharacterMovement>();
        if (c != null)
            c.SetOnMovingPlatform(false);
    }

}
