using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    List<string> instructions;
    int randomNumber;
    string stringToRetrieve;
    float instructionTimer = 1.0f;
    int currentInstructions = 0;
    int maxInstructions = 10;
    int previousInstructionIndex = 0;

    private bool canRestart = false;

    public SpiderScore scoreManager;
    public TextMeshProUGUI randomInstruction;
    public TextMeshProUGUI scoreTracker;

    // Start is called before the first frame update
    void Start()
    {
        instructions = new List<string>();
        instructions.Add("Left");
        instructions.Add("Right");
        instructions.Add("Up");
        instructions.Add("Down");

        randomInstruction.text = stringToRetrieve;
    }

    // Update is called once per frame
    void Update()
    {
        instructionTimer -= Time.deltaTime;

        if (currentInstructions < maxInstructions)
        {
            if (instructionTimer <= 0.0f)
            {
                do
                {
                    randomNumber = Random.Range(0, 4);
                }
                while (randomNumber == previousInstructionIndex);

                previousInstructionIndex = randomNumber;
                stringToRetrieve = instructions[randomNumber].ToString();
                randomInstruction.text = stringToRetrieve;
                instructionTimer = 1.0f;
                currentInstructions++;
            }
        }
        else {
            EndGame();
        }

        //if(canRestart)
        //{
        //    Debug.Log("canrestart");
        //    if(Input.GetKeyDown(KeyCode.Space))
        //    {
        //        Debug.Log("load");
        //        SceneManager.LoadScene("StartScene");
        //    }
        //}

#if !UNITY_EDITOR
        if(Input.GetKeyDown (KeyCode.Escape))
        {
            Application.Quit();
        }
#endif
    }

    void EndGame()
    {
        enabled = false;

        if (scoreManager.score >= 7)
        {
           scoreTracker.text = "You win!";
            Debug.Log("pass");

            //canRestart = true;
            StartCoroutine(RestartGame());
        }
        else 
        {
           scoreTracker.text = "Try again";
            Debug.Log("fail");

            //canRestart = true;
            StartCoroutine(RestartGame());
        }
    }

    private IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(5.0f);

        SceneManager.LoadScene("StartScene");
    }

}