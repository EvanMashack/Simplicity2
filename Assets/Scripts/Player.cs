using System;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class Player : MonoBehaviour
{ 
    float speed = 10;
    private Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Start"); 
         rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Get input from the Horizontal and Vertical axes
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Create a movement vector
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // Apply movement using the Rigidbody
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);

        if (movement.magnitude > 0)
        {
            // Get the child GameObject (visual model)
            Transform visualModel = transform.GetChild(0);

            // Create a rotation based on movement
            Quaternion targetRotation = Quaternion.LookRotation(movement);

            // Apply the rotation to the child
            visualModel.rotation = targetRotation;
        }
        //Debug.Log("Horizontal: " + x + " Vertical: " + y);
    }
}
