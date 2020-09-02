using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour
{

    [SerializeField]
    bool alwaysActive = false;
    [SerializeField]
    UnityEvent eventButtonActive;
    [SerializeField]
    UnityEvent eventButtonInactive;

    [Header("---")]
    [SerializeField]
    Animator animatorButton;

    bool active = false;
    int numberOfPeople = 0;

    private void Start()
    {
        if (animatorButton == null)
            animatorButton = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (active == true)
            return;
        numberOfPeople += 1;
        CheckButton();
    }
    private void OnTriggerExit(Collider other)
    {
        if (active == true)
            return;
        numberOfPeople -= 1;
        CheckButton();
    }

    private void CheckButton()
    {
        if(numberOfPeople == 0)
        {
            eventButtonInactive.Invoke();
            animatorButton.SetBool("Active", false);
        }
        else
        {
            animatorButton.SetBool("Active", true);
            eventButtonActive.Invoke();
            if (alwaysActive == true)
                active = true;
        }
    }

}
