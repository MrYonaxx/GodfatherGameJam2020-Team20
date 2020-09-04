using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDestructible : MonoBehaviour
{

    [SerializeField]
    GameObject particle;
    [SerializeField]
    Transform particlePosition;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("CubeAttack"))
        {
            Instantiate(particle, particlePosition.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

}
