using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private bool jumpKeyWasPressed;
    private int axis;
    private int speed = 10;
    private Rigidbody rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // check if space key is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpKeyWasPressed = true;
        }
        // check if W key is pressed
        else if (Input.GetKey(KeyCode.W))
        {
            axis = 8;
        }
        // check if S key is pressed
        else if (Input.GetKey(KeyCode.S))
        {
            axis = 2;
        }
        // check if A key is pressed
        else if (Input.GetKey(KeyCode.A))
        {
            axis = 4;
        }
        // check if D key is pressed
        else if (Input.GetKey(KeyCode.D))
        {
            axis = 6;
        }
        else {
            axis = 5;
        }
    }

    private void FixedUpdate() {

        if (jumpKeyWasPressed) {
            rigidBody.AddForce(Vector3.up * 5, ForceMode.VelocityChange);
            jumpKeyWasPressed = false;
        }

        switch (axis) {
            case 2:
                rigidBody.velocity = new Vector3(0, rigidBody.velocity.y, -speed);
                break;
            case 4:
                rigidBody.velocity = new Vector3(-speed, rigidBody.velocity.y, 0);
                break;
            case 5:
                rigidBody.velocity = new Vector3(0, rigidBody.velocity.y, 0);
                break;
            case 6:
                rigidBody.velocity = new Vector3(speed, rigidBody.velocity.y, 0);
                break;
            case 8:
                rigidBody.velocity = new Vector3(0, rigidBody.velocity.y, speed);
                break;
        }
          

    
    }
}
