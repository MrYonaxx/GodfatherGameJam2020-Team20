using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Dialog : MonoBehaviour
{
    public GameObject triangleGO, squareGO, moonGO, triangleText, squareText, moonText;

    private bool isTriangleActivated, isSquareActivated, isMoonActivated, specialLineForTriangle;

    public bool activationNeedTriangle, activationNeedSquare, activationNeedMoon;

    private float timeLeft;

    private Scene currentScene;

    private string nameScene;

    public void Awake()
    {
        isMoonActivated = false;
        isTriangleActivated = false;
        isSquareActivated = false;

        timeLeft = 4f;

        currentScene = SceneManager.GetActiveScene();

        specialLineForTriangle = false;

        nameScene = currentScene.name;
    }

    // Update is called once per frame
    void Update()
    {

        if(isMoonActivated)
        {
            timeLeft -= Time.deltaTime;

            if(timeLeft < 0)
            {
                moonGO.SetActive(false);
                isMoonActivated = false;

                activationNeedMoon = false;
            }
        }

        if(isSquareActivated)
        {
            timeLeft -= Time.deltaTime;

            if (timeLeft < 0)
            {
                squareGO.SetActive(false);
                activationNeedSquare = false;

                if (nameScene == "Lvl 6" && specialLineForTriangle)
                {
                    triangleGO.SetActive(true);
                    triangleText.GetComponent<TextMeshPro>().text = "Come on ! We'll talk later";
                    timeLeft = 4f;
                    isTriangleActivated = true;
                    isSquareActivated = false;

                }
            }
        }

        if(isTriangleActivated)
        {
            timeLeft -= Time.deltaTime;

            if (timeLeft < 0)
            {
                triangleGO.SetActive(false);
                isTriangleActivated = false;

            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        switch(nameScene)
        {
            case "Lvl 1":


                if(other.name == "PlayerTriangle" && activationNeedTriangle)
                {
                    triangleGO.SetActive(true);
                    triangleText.GetComponent<TextMeshPro>().text = "Hurry up, we have to go!";
                    isTriangleActivated = true;
                }

                if(other.name == "PlayerSquare" && activationNeedSquare)
                {
                    squareGO.SetActive(true);
                    squareText.GetComponent<TextMeshPro>().text = "Could we go any slower, please?";
                    isSquareActivated = true;
                }
                break;

            case "Lvl 2":

                if (other.name == "PlayerMoon" && activationNeedMoon)
                {
                    moonGO.SetActive(true);
                    moonText.GetComponent<TextMeshPro>().text = "Indeed, it was fun!";
                    isMoonActivated = true;
                }

                if (other.name == "PlayerSquare" && activationNeedSquare)
                {
                    squareGO.SetActive(true);
                    squareText.GetComponent<TextMeshPro>().text = "Ah! Ah! It was funny! Wasn't it?";
                    isSquareActivated = true;
                }

                break;

            case "Lvl 3":

                if (other.name == "PlayerSquare" && activationNeedSquare)
                {
                    squareGO.SetActive(true);
                    squareText.GetComponent<TextMeshPro>().text = "Why don't we stay here?";
                    isSquareActivated = true;
                }

                if (other.name == "PlayerMoon" && activationNeedMoon)
                {
                    moonGO.SetActive(true);
                    moonText.GetComponent<TextMeshPro>().text = "Why stay here when we can go further?";
                    isMoonActivated = true;
                }

                break;

            case "Lvl 4":

                if (other.name == "PlayerSquare" && activationNeedSquare)
                {
                    squareGO.SetActive(true);
                    squareText.GetComponent<TextMeshPro>().fontSize = 4.5f;
                    squareText.GetComponent<TextMeshPro>().text = "They're funny upstair, all doing the same things everyday easily!";
                    isSquareActivated = true;
                }

                if (other.name == "PlayerTriangle" && activationNeedTriangle)
                {
                    triangleGO.SetActive(true);
                    triangleText.GetComponent<TextMeshPro>().text = "At least they are moving on faster...";
                    isTriangleActivated = true;
                }

                break;

            case "Lvl 5":

                if (other.name == "PlayerSquare" && activationNeedSquare)
                {
                    squareGO.SetActive(true);
                    squareText.GetComponent<TextMeshPro>().fontSize = 5f;
                    squareText.GetComponent<TextMeshPro>().text = "Why is the triangle always in a grumpy mood?";
                    isSquareActivated = true;
                }

                if (other.name == "PlayerMoon" && activationNeedMoon)
                {
                    moonGO.SetActive(true);
                    moonText.GetComponent<TextMeshPro>().text = "Don't worry with him, he's always been like that.";
                    isMoonActivated = true;
                }

                break;

            case "Lvl 6":

                if (other.name == "PlayerSquare" && activationNeedSquare)
                {
                    squareGO.SetActive(true);
                    squareText.GetComponent<TextMeshPro>().text = "Don't you think...";
                    isSquareActivated = true;
                    specialLineForTriangle = true;
                }

                break;

            case "Lvl 7":

                if (other.name == "PlayerTriangle" && activationNeedTriangle)
                {
                    triangleGO.SetActive(true);
                    triangleText.GetComponent<TextMeshPro>().text = "I will never be able to catch up with them...";
                    isTriangleActivated = true;
                }

                if (other.name == "PlayerMoon" && activationNeedMoon)
                {
                    moonGO.SetActive(true);
                    moonText.GetComponent<TextMeshPro>().text = "We've already passed them a long time ago, look up.";
                    isMoonActivated = true;
                }

                break;

            default:
                Debug.Log("Nous ne sommes pas dans un niveau référencé");

                break;
        }
    }

    public void ActivateSpecialUI()
    {

    }
}
