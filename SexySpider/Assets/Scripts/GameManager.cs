using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    List<string> instructions;
    int randomNumber;
    string stringToRetrieve;
    float instructionTimer = 2.0f;
    int currentInstructions = 0;
    int maxInstructions = 10;

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
                randomNumber = Random.Range(0, 4);
                stringToRetrieve = instructions[randomNumber].ToString();
                randomInstruction.text = stringToRetrieve;
                instructionTimer = 2.0f;
                currentInstructions++;
            }
        }
        else {
            EndGame();
        }
    }

    void EndGame()
    {
        enabled = false;

        if (scoreManager.score >= 7)
        {
           scoreTracker.text = "You win!";
            Debug.Log("pass");
        }
        else 
        {
           scoreTracker.text = "Try again";
            Debug.Log("fail"); 
        }
    }

}