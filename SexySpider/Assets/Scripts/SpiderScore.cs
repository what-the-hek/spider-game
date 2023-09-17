using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class SpiderScore : MonoBehaviour
{
    public int score = 0;
    public float Speed = 10;
    Rigidbody spider;
    public TextMeshProUGUI instructionText;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        spider = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            CheckMovement("Left");
            animator.SetTrigger("LeftMove");
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            CheckMovement("Right");
            animator.SetTrigger("RightMove");
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            CheckMovement("Up");
            animator.SetTrigger("ButtWiggle");
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            CheckMovement("Down");
            animator.SetTrigger("SassyLegs");
        }

    }

    public void MoveSideways(int amount)
    {
        Vector3 newPos = transform.position;
        newPos.x += amount;

        // newPos.x = Mathf.Clamp(newPos.x, 0, 4);
        transform.position = newPos;
    }

    void CheckMovement(string selectedDirection)
    {
        if (selectedDirection == instructionText.text)
        {
            score++;
            Debug.Log(score);
        }
    }
}
