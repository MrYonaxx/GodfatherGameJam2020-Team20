using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRotation : MonoBehaviour
{
    [SerializeField]
    private float raycastLenght = 1;
    [SerializeField]
    private float rotationSpeed = 1;

    private Quaternion targetRotation;


    // Update is called once per frame
    void Update()
    {
        GetGroundRotation();
        UpdateRotation();
    }

    private void GetGroundRotation()
    {
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 0;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        //layerMask = ~layerMask;

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, Vector3.down, out hit, raycastLenght, layerMask))
        {
            targetRotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
            //transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
            /*hit.normal;
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");*/
        }
        else
        {
            targetRotation = Quaternion.Euler(0, 0, 0);
        }
        Debug.DrawRay(transform.position, Vector3.down * raycastLenght, Color.yellow);
    }

    private void UpdateRotation()
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }


}
