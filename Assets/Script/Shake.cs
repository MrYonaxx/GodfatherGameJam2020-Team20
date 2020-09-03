using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{

    public void ScreenShake()
    {
        ScreenShakeController.instance.StartShake(0.2f, 0.2f);
    }
}
