using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public int health = 30;
    private float distance;
    public GameObject orangePowerUpPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction  = player.transform.position - transform.position;

        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "FireBall")
        {
            Destroy(gameObject);
            Instantiate(orangePowerUpPrefab);
        }
    }
}
