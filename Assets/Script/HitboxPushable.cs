using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxPushable : MonoBehaviour, IPushable
{
    // C'est ptet pas ouf
    [SerializeField]
    CharacterMovement characterMovement;

    public void Push(float x, float y)
    {
        characterMovement.Push(x, y);
    }
}
