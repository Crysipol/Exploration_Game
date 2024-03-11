using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // Player Movement
    public Vector3 leftMoveForce;
    public Vector3 rightMoveForce;
    public Vector3 jumpForce;
    public Vector3 dash;

    // Player Health and damage
    public int playerHealth = 100;
    public int playerDamage = 5;

    // Jump, Dash, and stun situations
    public bool canJump = true;
    public bool canDoubleJump = true;
    public bool canDash = true;
    public bool isStunned = false;

    // PowerUps
    public bool slowFalling = false;
    public bool doubleDamage = false;
    public bool healing = false;
    public bool stun = false;

    public int playerFacing;

    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        // Checks first if the player is stunned
        if(isStunned == true)
        {
            Debug.Log("Your stunned!, You cant move!");
        }

        // Player movement
        if(Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody2D>().AddForce(leftMoveForce);
            playerFacing = -1;
        }

        if(Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody2D>().AddForce(rightMoveForce);
            playerFacing = 1;
        }

        if(Input.GetKey(KeyCode.W))
        {
            if(canJump == true)
            {
                canJump = false;
                GetComponent<Rigidbody2D>().AddForce(jumpForce);
            }

            else if(canDoubleJump == true)
            {
                canDoubleJump = false;
                GetComponent<Rigidbody2D>().AddForce(jumpForce);
            }
        }

        if(Input.GetKeyDown(KeyCode.Q) && canDash == true)
        {
            GetComponent<Rigidbody2D>().AddForce(dash);
            canDash = false;
        }

        else if(canDash == false)
        {
            for(int i = 0, 1)
            {
                Debug.Log("Dash in Cooldown");
                canDash = true;
            }

        }

        //Powerups
        if(healing == true)
        {
            if(playerHealth <= 95)
            {
                playerHealth += 5;
                Debug.Log("Health: " + playerHealth)
            }

        }

    }
}
