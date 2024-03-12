using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public Vector3 puPos1;
    public int score;
    public bool isGameOver;
    public bool playerWon;
    public bool playerLost;
    public float putimer;
    public GameObject puPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameOver == false)
        {
            if(score >= 3)
            {
                isGameOver = true;
                playerWon = true;
                Debug.Log("You win!");
            }
            
            if (playerLost == true)
            {
                isGameOver = true;
                Debug.Log("You lose...");
            }

            putimer += Time.deltaTime;
            if(putimer > 3f)
            {
                Instantiate(puPrefab, puPos1, Quaternion.identity);
                putimer=0;
            }
        }
    }
}
