using System.Collections.Generic;
using System.Drawing;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    private PatrolPoint[] patrolPoints; 
    PatrolPoint closestPoint;

    void Start() 
    { 
        patrolPoints = getPatrolPoints();

        if(patrolPoints != null)
        {
            foreach(PatrolPoint point in patrolPoints)
            {
                Debug.Log("Name: " + point.gameObject.name);
            }
        }
    }

    void Update()
    { 
        float closestDistance = Mathf.Infinity; 

        foreach(PatrolPoint point in patrolPoints)
        {  
            float distance = Vector3.Distance(transform.position, point.transform.position); 
            
            if(distance < closestDistance)
            {
                closestDistance = distance;
                closestPoint = point;
            }
        } 

        Vector3 direction = (closestPoint.transform.position - transform.position).normalized;

        transform.Translate(direction * 5f * Time.deltaTime); 
    }

    PatrolPoint[] getPatrolPoints() {  
        return transform.parent.Find("Route").GetComponentsInChildren<PatrolPoint>();
    } 

    void OnTriggerEnter(Collider other) {
        Debug.Log("smeeb");
    }
}
