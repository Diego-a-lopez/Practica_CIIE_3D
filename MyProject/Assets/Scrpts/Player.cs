using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private float speed = 7;
    private float rotationSpeed = 720;
    private bool jumpKeyWasPressed;
    private Rigidbody rigidBody;
    GameObject Obj;
    private Director director;

    // Start is called before the first frame update
    void Start()
    {
        Obj = GameObject.Find("Director");
        director = Obj.GetComponent<Director>();
        rigidBody = GetComponent<Rigidbody>();
    }



    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        movementDirection.Normalize();
        transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);

        if (movementDirection != Vector3.zero)
        {


            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpKeyWasPressed = true;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            director.GoToMain();
        }

    }


    private void FixedUpdate()
    {

        if (jumpKeyWasPressed)
        {
            rigidBody.AddForce(Vector3.up * 5, ForceMode.VelocityChange);
            jumpKeyWasPressed = false;
        }
    }
}





