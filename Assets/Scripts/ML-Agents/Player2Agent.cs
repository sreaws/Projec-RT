using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class Player2Agent : Agent
{
    [SerializeField]
    CharacterController2D controller;
    [SerializeField]
    MassProduceP2 massproducer;
    [SerializeField]
    CharacterController2D playerController;

    public float count = 0;
    public float tempCount = 0;
    public float timeLeft = 0;
    public float episodeTimer = 0;


    float horizontalMove = 0f;
    public float runSpeed = 30f;
    bool jump = false;
    public void Update()
    {
        tempCount = count;
        if (timeLeft > 0f)
        {
            timeLeft -= Time.deltaTime;
        }
        else
        {
            episodeTimer -= 5f;
            timeLeft = 5f;
            AddReward(-2f);
            count -= 2f;
        }



        if (count >= 10 || count <= -10 || episodeTimer <= 0)
        {
            count = 0;
            EndEpisode();
        }
    }

    public override void OnEpisodeBegin()
    {
        timeLeft = 5f;
        episodeTimer = 25f;
        transform.position = new Vector3(1.74f, -4.09f, 0);
        massproducer.Respawn();
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        base.OnActionReceived(actions);

        int actToMoveSide = actions.DiscreteActions[0];
        int actToJump = actions.DiscreteActions[1];

        if (actToMoveSide == 1)
        {
            horizontalMove = -1f * runSpeed; //go left
        }
        else if (actToMoveSide == 2)
        {
            horizontalMove = 1f * runSpeed; //go right
        }
        else
        {
            horizontalMove = 0f ; // dont move side ways
        }

        if(actToJump == 1)
        {
            jump = true;
        }
        tempCount = count;
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
        jump = false;
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var discreteActionsOut = actionsOut.DiscreteActions;
        if (Input.GetKey(KeyCode.D))
        {
            // right
            discreteActionsOut[0] = 2;
        }
        if (Input.GetKey(KeyCode.W))
        {
            // left
            discreteActionsOut[1] = 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            // jump
            discreteActionsOut[0] = 1;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Collectible"))
        {
            AddReward(1f);
            timeLeft = 5f;
            count++;
        }

    }
}
