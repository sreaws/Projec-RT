using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Movement : MonoBehaviour
{

    public CharacterController2D controller;
    public float runSpeed = 40f;

    bool jump;
    float horizontalMove = 0f;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal2") * runSpeed;
        if (Input.GetButtonDown("Jump2"))
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
