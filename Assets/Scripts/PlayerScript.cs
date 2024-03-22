using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // Player Movement
    public Vector3 leftMoveForce;
    public Vector3 rightMoveForce;
    public Vector3 jumpForce;

    // Player Health and damage
    public static int playerHealth = 100;
    public static int playerDamage = 5;

    // Jump, Dash, and stun situations
    public bool canJump = true;
    private bool canDoubleJump = true;
    public static int playerFacing;

    public GameObject leftprojectilePrefab;
    public GameObject rightprojectilePrefab;
    public Vector3 leftprojectileOffset;
    public Vector3 rightprojectileOffset;



    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody2D>().AddForce(leftMoveForce);
            playerFacing = -1;
            transform.localScale = new Vector2(0.3f,0.3f);
        }

        if(Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody2D>().AddForce(rightMoveForce);
            playerFacing = 1;
            transform.localScale = new Vector2(-0.3f,0.3f);
        }

        if(Input.GetKey(KeyCode.Space))
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

        if(Input.GetKeyDown(KeyCode.E))
        {
            if(playerFacing == 1)
            {
                Instantiate(rightprojectilePrefab,GetComponent<Transform>().position + leftprojectileOffset,Quaternion.identity);
            }

            if(playerFacing == -1){
                Instantiate(leftprojectilePrefab,GetComponent<Transform>().position + rightprojectileOffset,Quaternion.identity);
            }
        }
        
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            canJump = true;
        }
    }
}
