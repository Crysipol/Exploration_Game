using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public Vector3 projectileMove;
    public float projectileTimer;
    public GameObject gameManagerObject;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerObject = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Transform>().position += projectileMove;
        projectileTimer += Time.deltaTime;
        if(projectileTimer > 1f)
        {
            Destroy(gameObject);
        }

        if(PlayerScript.doubleDamage == true)
        {
            PlayerScript.playerDamage = 10;
            PlayerScript.doubleDamage = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            gameManagerObject.GetComponent<GameManagerScript>().score += 1;
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
