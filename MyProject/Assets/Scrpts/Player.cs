using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Controllers for the player movement speed, jump, fall, etc.
    public float speed = 5f;
    public float rotationSpeed = 720f;
    public float jumpVelocity = 6f;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    //Booleans for jump controll.
    private bool jumpKeyWasPressed;
    private bool grounded = true;
    //Extra stuff that does not fit previous categories.
    public GameObject ODirector;
    private GameAssets assets;
    private Rigidbody rigidBody;
    private Director director;

    // Start is called before the first frame update
    void Start()
    {
        GameObject Obj;
        rigidBody = GetComponent<Rigidbody>();
        //ODirector = GameObject.Find("Director");
        Obj = GameObject.Find("GameAssets");
        assets = Obj.GetComponent<GameAssets>();
        director = ODirector.GetComponent<Director>();
    }

    // Update is called once per frame
    void Update()
    {
        //Getting Horizontal and Vertical axis for player movement.
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        //Vector direction that controlls player movement in the x and y axis (or x and z)
        Vector3 movementDirection = new Vector3(horizontalInput,0,verticalInput);
        movementDirection.Normalize();

        //Movement controller with the translation. Uses the speed and direction as well
        //as world coordinates to know which direction is which.
        transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);

        //If we are moving towards something, we rotate the character, if neccessary.
        //The quaternion rotation makes it so we look at the place we clicked, and since
        //its aditive, we can make sure we always look at the correct way when rotating.
        if(movementDirection != Vector3.zero){


            Quaternion toRotation = Quaternion.LookRotation(movementDirection,Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed*Time.deltaTime);

        }

        //Control for jump and check if we are in the ground as an extra.
        if(Input.GetButtonDown("Jump") && grounded){
            assets.PlayJump();
           jumpKeyWasPressed = true;
        }

        //Director call so we can call the menu.
        if (Input.GetKeyDown(KeyCode.Escape)){
           director.GoToMain();
        }
    }


    private void FixedUpdate() {

        //Condition check in case we just drop down without jumping. The multiplier for
        //falling would activate regardless.
        if(rigidBody.velocity.y < 0){
            rigidBody.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        } 
        //If we are not falling we can check if we are jumping, so it would use a 
        //different multiplier and make the fall less sudden.
        else if (rigidBody.velocity.y > 0 && !Input.GetButton("Jump")){
            rigidBody.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;            
        }

        //Actions that are taken when the jumpkey is pressed, 
        //using addForce so its a sudden burst of upwards momentum. 
        //We also change the values of the booleans so the player doesn't jump infinitely.
        if(jumpKeyWasPressed){
             rigidBody.AddForce(Vector3.up * jumpVelocity, ForceMode.Impulse);
             jumpKeyWasPressed = false;
             grounded = false;
        }
    }

    //Checks collision with ground to enable jump. The Object MUST be tagged.
    private void OnCollisionStay(Collision collision){
        if(collision.gameObject.tag == "Ground"){
            grounded = true;
        }
    }

    //Checks exit of the collision state so jumping again is enabled.
    private void OnCollisionExit(Collision collision){
        if(grounded){
            grounded = false;
        }
    }
    
}

          

    
    





