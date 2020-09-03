using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevel : MonoBehaviour
{
    public LevelLoader levelLoader;
    [SerializeField]
    private string index;

    int count = 0;

    private void OnTriggerEnter(Collider other)
    {
        count += 1;
        if(count == 2)
        {
            levelLoader.LoadNextLevel(index);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        count -= 1;
    }
}
