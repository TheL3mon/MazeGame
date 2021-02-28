using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simpleEnemyScript : MonoBehaviour
{
    float distanceToPlayer;
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        distanceToPlayer = Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, transform.position);
        if(distanceToPlayer<=3){
            transform.position = Vector3.MoveTowards(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position, 3f * Time.deltaTime);
        }
    }
}
