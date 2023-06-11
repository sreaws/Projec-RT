using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Movement : MonoBehaviour
{

    public CharacterController2D controller;
    public float runSpeed = 40f;

    bool jump;
    float horizontalMove = 0f;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }

    private void FixedUpdate()
    {
        // Move our Character
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
        jump = false;
    }
}
