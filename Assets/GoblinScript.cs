using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinScript : MonoBehaviour
{
    public float radius = 5f;
    [Range(1, 180)]public float angle = 45f; 
    public LayerMask targetLayer;
    public LayerMask obstructionLayer;
    public GameObject playerRef;

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
            
            if(Vector2.Angle(transform.up, directionToTarget) < angle / 2){
                float distanceToTarget = Vector2.Distance(transform.position, target.position);
                
                if(Physics2D.Raycasting(transform.position, directionToTarget, distanceToTarget, obstructionLayer)){
                    CanSeePlayer = true;
                }
                else
                    CanSeePlayer = false;
            }
            else
                CanSeePlayer = false;
        }
        else if (CanSeePlayer){
            CanSeePlayer = false;
        }
    }
}
