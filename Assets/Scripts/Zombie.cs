using System.Collections.Generic; 
using System.Drawing;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    Rigidbody rb;
    private PatrolPoint[] patrolPoints; 
    PatrolPoint destinationPoint;

    void Start() 
    { 
        rb = GetComponent<Rigidbody>();
        patrolPoints = GetPatrolPoints();
        SetDestinationPoint();  
    }

    void FixedUpdate()
    {  
        MoveZombie();
    }

    void OnTriggerEnter(Collider other) {
        destinationPoint.Visited = true; 
        SetDestinationPoint();
    }

    void MoveZombie()
    {
        Vector3 movement = (destinationPoint.transform.position - transform.position).normalized; 
        rb.MovePosition(rb.position + movement * 5f * Time.fixedDeltaTime); 

        if (movement.magnitude > 0)
        {
            // Get the child GameObject (visual model)
            Transform visualModel = transform.GetChild(0);

            // Create a rotation based on movement
            Quaternion targetRotation = Quaternion.LookRotation(movement);

            // Apply the rotation to the child
            visualModel.rotation = targetRotation;
        }
    }

    PatrolPoint[] GetPatrolPoints() {  
        return transform.parent.Find("Route").GetComponentsInChildren<PatrolPoint>();
    } 

    void SetDestinationPoint()
    {
        float shortestDistance = Mathf.Infinity; 
        float distance = Mathf.Infinity;

        foreach(PatrolPoint point in patrolPoints)
        {
            if(!point.Visited) 
            { 
                distance = Vector3.Distance(transform.position, point.transform.position); 
            } 

            if(distance < shortestDistance)
            {
                shortestDistance = distance;
                destinationPoint = point;
            }
        }
        Debug.Log("Destination: " + destinationPoint.gameObject.name);
    }
}
