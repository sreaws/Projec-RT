using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleBehaviourP1 : MonoBehaviour
{
    [SerializeField] private CollectibleControllerP1 controller;
    [SerializeField] float rayLenght = 10.0f;
    [SerializeField] float runningSpeedFromPlayer = 2.0f;
    [SerializeField] float runningSpeed = 1.0f;

    private Vector2 directionUp = new Vector2(0.0f, 1.0f);
    private Vector2 directionUpRight = new Vector2(0.707f, 0.707f);  // 1^2 = 2x^2  // sqrt(1/2) = x //Mathf.Sqrt(1 / 2), Mathf.Sqrt(1 / 2)
    private Vector2 directionRight = new Vector2(1.0f, 0.0f);
    private Vector2 directionDownRight = new Vector2(0.707f, -0.707f);
    private Vector2 directionDown = new Vector2(0.0f, -1.0f);
    private Vector2 directionDownLeft = new Vector2(-0.707f, -0.707f);
    private Vector2 directionLeft = new Vector2(-1.0f, 0.0f);
    private Vector2 directionUpLeft = new Vector2(-0.707f, 0.707f);

    private RaycastHit2D raycastHitR;
    private RaycastHit2D raycastHitL;
    private RaycastHit2D raycastHitUp;
    private RaycastHit2D raycastHitDown;

    private RaycastHit2D raycastHitUpRight;
    private RaycastHit2D raycastHitDownRight;
    private RaycastHit2D raycastHitDownLeft;
    private RaycastHit2D raycastHitUpLeft;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        SetRayCasts();
        //controller.Move(directionUpRight * 0.707f * Time.fixedDeltaTime);
    }

    private void SetRayCasts()
    {

        Vector2 finalVector2D = new Vector2(0f, 0f);


        // Right RayCasting

        Vector2 positionR = new Vector2(transform.position.x + 0.11f, transform.position.y);
        raycastHitR = Physics2D.Raycast(positionR, directionRight, rayLenght);


        if (raycastHitR.collider != null)
        {
            float denominator = 1f;
            if(raycastHitR.distance > 1f)
            {
                denominator = 1/(raycastHitR.distance * raycastHitR.distance);
            }

            if (raycastHitR.collider.tag == "Player")
            {
                finalVector2D += (directionLeft * denominator * runningSpeedFromPlayer);
                controller.isRun = true;
            }
            if (raycastHitR.collider.tag == "Platform" && raycastHitR.distance < 0.5f)
            {
                finalVector2D += (directionLeft * denominator * runningSpeed);
                controller.isRun = true;
            }
            if (raycastHitR.collider.tag == "Collectible" && raycastHitR.distance < 0.12f)
            {
                finalVector2D += (directionLeft * denominator * runningSpeed);
                controller.isRun = true;
            }
        }

        // Left Raycasting

        Vector2 positionL = new Vector2(transform.position.x - 0.11f, transform.position.y);
        raycastHitL = Physics2D.Raycast(positionL, directionLeft, rayLenght);


        if (raycastHitL.collider != null)
        {
            float denominator = 1;
            if (raycastHitL.distance > 1f)
            {
                denominator = 1 / (raycastHitL.distance * raycastHitL.distance);
            }

            if (raycastHitL.collider.tag == "Player")
            {
                finalVector2D += (directionRight * denominator * runningSpeedFromPlayer);
                controller.isRun = true;
            }
            if (raycastHitL.collider.tag == "Platform" && raycastHitL.distance < 0.5f)
            {
                finalVector2D += (directionRight * denominator * runningSpeed);
                controller.isRun = true;
            }
            if (raycastHitL.collider.tag == "Collectible" && raycastHitL.distance < 0.12f)
            {
                finalVector2D += (directionRight * denominator * runningSpeed);
                controller.isRun = true;
            }
        }

        // Up RayCasting

        Vector2 positionUp = new Vector2(transform.position.x, transform.position.y + 0.11f);
        raycastHitUp = Physics2D.Raycast(positionUp, directionUp, rayLenght);

        if (raycastHitUp.collider != null)
        {
            float denominator = 1f;
            if (raycastHitUp.distance > 1f)
            {
                denominator = 1 / (raycastHitUp.distance * raycastHitUp.distance);
            }

            if (raycastHitUp.collider.tag == "Player")
            {
                finalVector2D += (directionDown * denominator * runningSpeedFromPlayer);
                controller.isRun = true;
            }
            if (raycastHitUp.collider.tag == "Platform" && raycastHitUp.distance < 0.5f)
            {
                finalVector2D += (directionDown * denominator * runningSpeed);
                controller.isRun = true;
            }
            if (raycastHitUp.collider.tag == "Collectible" && raycastHitUp.distance < 0.12f)
            {
                finalVector2D += (directionDown * denominator * runningSpeed);
                controller.isRun = true;
            }
        }

        // Down RayCasting

        Vector2 positionDown = new Vector2(transform.position.x, transform.position.y - 0.11f);
        raycastHitDown = Physics2D.Raycast(positionDown, directionDown, rayLenght);

        if (raycastHitDown.collider != null)
        {
            float denominator = 1f;
            if (raycastHitDown.distance > 1f)
            {
                denominator = 1 / (raycastHitDown.distance * raycastHitDown.distance);
            }

            if (raycastHitDown.collider.tag == "Player")
            {
                finalVector2D += (directionUp * denominator * runningSpeedFromPlayer);
                controller.isRun = true;
            }
            if (raycastHitDown.collider.tag == "Platform" && raycastHitDown.distance < 0.5f)
            {
                finalVector2D += (directionUp * denominator * runningSpeed);
                controller.isRun = true;
            }
            if (raycastHitDown.collider.tag == "Collectible" && raycastHitDown.distance < 0.12f)
            {
                finalVector2D += (directionUp * denominator * runningSpeed);
                controller.isRun = true;
            }
        }


        // UpRight RayCasting

        Vector2 positionUpRight = new Vector2(transform.position.x + 0.0777f, transform.position.y + 0.0777f ); //0.11f = sqrt(2x^2), x ~= 0.0777f
        raycastHitUpRight = Physics2D.Raycast(positionUpRight, directionUpRight, rayLenght);

        if (raycastHitUpRight.collider != null)
        {
            float denominator = 1f;
            if (raycastHitUpRight.distance > 1f)
            {
                denominator = 1 / (raycastHitUpRight.distance * raycastHitUpRight.distance);
            }

            if (raycastHitUpRight.collider.tag == "Player")
            {
                finalVector2D += (directionDownLeft * denominator * runningSpeedFromPlayer);
                controller.isRun = true;
            }
            if (raycastHitUpRight.collider.tag == "Platform" && raycastHitUpRight.distance < 0.5f)
            {
                finalVector2D += (directionDownLeft * denominator * runningSpeed);
                controller.isRun = true;
            }
            if (raycastHitUpRight.collider.tag == "Collectible" && raycastHitUpRight.distance < 0.12f)
            {
                finalVector2D += (directionDownLeft * denominator * runningSpeed);
                controller.isRun = true;
            }
        }

        // DownRight RayCasting

        Vector2 positionDownRight = new Vector2(transform.position.x + 0.0777f, transform.position.y - 0.0777f); //0.11f = sqrt(2x^2), x ~= 0.0777f
        raycastHitDownRight = Physics2D.Raycast(positionDownRight, directionDownRight, rayLenght);

        if (raycastHitDownRight.collider != null)
        {
            float denominator = 1f;
            if (raycastHitDownRight.distance > 1f)
            {
                denominator = 1 / (raycastHitDownRight.distance * raycastHitDownRight.distance);
            }

            if (raycastHitDownRight.collider.tag == "Player")
            {
                finalVector2D += (directionUpLeft * denominator * runningSpeedFromPlayer);
                controller.isRun = true;
            }
            if (raycastHitDownRight.collider.tag == "Platform" && raycastHitDownRight.distance < 0.5f)
            {
                finalVector2D += (directionUpLeft * denominator * runningSpeed);
                controller.isRun = true;
            }
            if (raycastHitDownRight.collider.tag == "Collectible" && raycastHitDownRight.distance < 0.12f)
            {
                finalVector2D += (directionUpLeft * denominator * runningSpeed);
                controller.isRun = true;
            }
        }
        // DownLeft RayCasting

        Vector2 positionDownLeft = new Vector2(transform.position.x - 0.0777f, transform.position.y - 0.0777f); //0.11f = sqrt(2x^2), x ~= 0.0777f
        raycastHitDownLeft = Physics2D.Raycast(positionDownLeft, directionDownLeft, rayLenght);

        if (raycastHitDownLeft.collider != null)
        {
            float denominator = 1f;
            if (raycastHitDownLeft.distance > 1f)
            {
                denominator = 1 / (raycastHitDownLeft.distance * raycastHitDownLeft.distance);
            }

            if (raycastHitDownLeft.collider.tag == "Player")
            {
                finalVector2D += (directionUpRight * denominator * runningSpeedFromPlayer);
                controller.isRun = true;
            }
            if (raycastHitDownLeft.collider.tag == "Platform" && raycastHitDownLeft.distance < 0.5f)
            {
                finalVector2D += (directionUpRight * denominator * runningSpeed);
                controller.isRun = true;
            }
            if (raycastHitDownLeft.collider.tag == "Collectible" && raycastHitDownLeft.distance < 0.12f)
            {
                finalVector2D += (directionUpRight * denominator * runningSpeed);
                controller.isRun = true;
            }
        }

        // UpLeft Raycasting

        Vector2 positionUpLeft = new Vector2(transform.position.x - 0.0777f, transform.position.y + 0.0777f); //0.11f = sqrt(2x^2), x ~= 0.0777f
        raycastHitUpLeft = Physics2D.Raycast(positionUpLeft, directionUpLeft, rayLenght);

        if (raycastHitUpLeft.collider != null)
        {
            float denominator = 1f;
            if (raycastHitUpLeft.distance > 1f)
            {
                denominator = 1 / (raycastHitUpLeft.distance * raycastHitUpLeft.distance);
            }

            if (raycastHitUpLeft.collider.tag == "Player")
            {
                finalVector2D += (directionDownRight * denominator * runningSpeedFromPlayer);
                controller.isRun = true;
            }
            if (raycastHitUpLeft.collider.tag == "Platform" && raycastHitUpLeft.distance < 0.5f)
            {
                finalVector2D += (directionDownRight * denominator * runningSpeed);
                controller.isRun = true;
            }
            if (raycastHitUpLeft.collider.tag == "Collectible" && raycastHitUpLeft.distance < 0.12f)
            {
                finalVector2D += (directionDownRight * denominator * runningSpeed);
                controller.isRun = true;
            }
        }

        controller.Move(finalVector2D * Time.fixedDeltaTime);

    }
}
