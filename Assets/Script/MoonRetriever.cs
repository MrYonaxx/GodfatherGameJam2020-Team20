using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonRetriever : MonoBehaviour
{
    [SerializeField]
    Moon moonObject;
    [SerializeField]
    Transform retrievePosition;
    [SerializeField]
    GameObject buttonPrompt;

    Square character;
    Triangle triangle;

    private void OnTriggerEnter(Collider other)
    {
        character = other.GetComponent<Square>();
        if (character == null)
        {
            triangle = other.GetComponent<Triangle>();
            triangle.AssignMoon(moonObject, retrievePosition.position);
            buttonPrompt.SetActive(true);
        }
        else
        {
            character.AssignMoon(moonObject, retrievePosition.position);
            buttonPrompt.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (character != null)
        {
            character.AssignMoon(null, retrievePosition.position);
            character = null;
            buttonPrompt.SetActive(false);
        }
        else if (triangle != null)
        {
            triangle.AssignMoon(null, retrievePosition.position);
            triangle = null;
            buttonPrompt.SetActive(false);
        }
    }

    private void OnDisable()
    {
        if (character != null)
        {
            character.AssignMoon(null, retrievePosition.position);
            character = null;
            buttonPrompt.SetActive(false);
        }
        else if (triangle != null)
        {
            triangle.AssignMoon(null, retrievePosition.position);
            triangle = null;
            buttonPrompt.SetActive(false);
        }
        /*if (character != null)
            character.AssignMoon(null, retrievePosition.position);
        character = null;*/
        buttonPrompt.SetActive(false);
    }

}
