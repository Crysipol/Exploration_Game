using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
    public GameObject orangePowerUpPrefab;
    public Animator destroyAnimation;

    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

    }
        private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "FireBall")
        {
            destroyAnimation.SetTrigger("Destroy");
            Destroy(gameObject);
            Instantiate(orangePowerUpPrefab);
        }
    }
}
