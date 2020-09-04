using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    [SerializeField]
    float offsetClamp = 0.5f;
    [SerializeField]
    GameObject waterParticle = null;

    Vector2 clampPos;
    Moon moonObject;

    private void Start()
    {
        BoxCollider collider = GetComponent<BoxCollider>();
        clampPos = new Vector2(this.transform.position.x - (collider.size.x * 0.5f * this.transform.localScale.x) + offsetClamp, 
                               this.transform.position.x + (collider.size.x * 0.5f * this.transform.localScale.x) - offsetClamp);
    }

    private void OnTriggerEnter(Collider other)
    {
        moonObject = other.GetComponent<Moon>();
        if (moonObject != null)
        {
            Instantiate(waterParticle, other.transform.position, Quaternion.identity);
            moonObject.SetInWater(clampPos);
        }
    }

    /*private void OnTriggerExit(Collider other)
    {
        if (moonObject == null)
            return;
        if (moonObject.gameObject == other.gameObject)
            moonObject.ExitWater();
    }*/
}
