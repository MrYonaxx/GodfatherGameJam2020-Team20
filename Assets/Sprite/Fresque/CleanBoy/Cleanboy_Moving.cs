using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleanboy_Moving : MonoBehaviour
{
    public float vitesse = 10;
    public float xmax = 100;
    public float xbase = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += new Vector3(vitesse,0)*Time.deltaTime;
            if(gameObject.transform.position.x >= xmax)
            {
                gameObject.transform.position = new Vector3(xbase,gameObject.transform.position.y,gameObject.transform.position.z);
            }
    }
}
