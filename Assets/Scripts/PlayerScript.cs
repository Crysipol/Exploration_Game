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
    public static int playerHealth = 100;
    public static int playerDamage = 5;

    // Jump, Dash, and stun situations
    public bool canJump = true;
    private bool canDoubleJump = true;
    private bool canDash = true;
    private bool isStunned = false;

    // PowerUps
    private bool slowFalling = false;
    public static bool doubleDamage = false;
    private bool healing = false;
    private bool stun = false;

    public static int playerFacing;

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
            Debug.Log("Work In Progress");
        }

        //Powerups
        if(healing == true)
        {
            if(playerHealth <= 95)
            {
                playerHealth += 5;
                Debug.Log("Health: " + playerHealth);
            }

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            canJump = true;
        }

        // PowerUps
        if(collision.gameObject.tag == "SlowfallingPower")
        {
            slowFalling = true;
            Destroy(collision.gameObject);
        }

        if(collision.gameObject.tag == "DoubledamagePower")
        {
            doubleDamage = true;
            Destroy(collision.gameObject);
        }

        if(collision.gameObject.tag == "HealingPower")
        {
            healing = true;
            Destroy(collision.gameObject);
        }

        if(collision.gameObject.tag == "StunPower")
        {
            stun = true;
            Destroy(collision.gameObject);
        }  
    }

    
}
