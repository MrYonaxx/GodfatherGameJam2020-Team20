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

    private void OnTriggerEnter(Collider other)
    {
        character = other.GetComponent<Square>();
        character.AssignMoon(moonObject, retrievePosition.position);
        buttonPrompt.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        character.AssignMoon(null, retrievePosition.position);
        character = null;
        buttonPrompt.SetActive(false);
    }

    private void OnDisable()
    {
        if(character != null)
            character.AssignMoon(null, retrievePosition.position);
        character = null;
        buttonPrompt.SetActive(false);
    }

}
