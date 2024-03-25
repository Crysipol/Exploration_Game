using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    public string PowerUpspawn(){
        string [] powerUps = {"red",  "Orange", "blue", "green"};
        return powerUps [new System.Random().Next(powerUps.Length)];
    }
    // Update is called once per frame
    void Update()
    {

    }
        private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "FireBall")
        {
            Destroy(gameObject);
        }
    }
}
