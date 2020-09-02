using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDestructible : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("CubeAttack"))
        {
            Destroy(this.gameObject);
        }
    }

}
