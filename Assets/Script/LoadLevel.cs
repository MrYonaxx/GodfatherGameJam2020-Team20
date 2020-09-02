using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevel : MonoBehaviour
{
    public LevelLoader levelLoader;
    [SerializeField]
    private string index;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player1") && other.gameObject.CompareTag("Player2"))
        {
            levelLoader.LoadNextLevel(index);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player1") && other.gameObject.CompareTag("Player2"))
        {
            levelLoader.LoadNextLevel(index);
        }
    }
}
