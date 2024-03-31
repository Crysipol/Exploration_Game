using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float radius = 5f;
    public float angle = 150f; 
    public LayerMask targetLayer;
    public LayerMask obstructionLayer;
    public GameObject playerRef;
    private float distance;
    public GameObject player;
    public float speed;

    public bool CanSeePlayer {get; private set;}

    void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FOVCheck());
    }

    private IEnumerator FOVCheck(){
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while(true){
            yield return wait;
            FOV();
        }
    }

    private void FOV(){
        Collider2D[] rangeCheck = Physics2D.OverlapCircleAll(transform.position, radius, targetLayer);

        if(rangeCheck.Length > 0) {
            Transform target = rangeCheck[0].transform;
            Vector2 directionToTarget = (target.position - transform.position).normalized;
            
            if(Vector2.Angle(transform.up, directionToTarget) < angle * 0.5){
                float distanceToTarget = Vector2.Distance(transform.position, target.position);
                
                if(Physics2D.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionLayer)){
                    CanSeePlayer = true;
                }
                else{
                    CanSeePlayer = false;
                    distance = Vector2.Distance(transform.position, player.transform.position);
                    Vector2 direction  = player.transform.position - transform.position;

                    transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
                    
                }
            }
            else{
                CanSeePlayer = false;
            }
        }
        else if (CanSeePlayer){
            CanSeePlayer = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Player"){
            Destroy(gameObject);
        }
    }
}
