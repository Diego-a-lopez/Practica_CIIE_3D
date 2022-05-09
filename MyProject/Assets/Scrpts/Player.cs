using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Controllers for the player movement speed, turning, jumping, falling, and
    //manual gravity since we are not working with rigidbodies.
    public float speed = 5f;
    public float turnSmoothT = 0.1f;
    public float turnSmoothV;
    public float jumpVelocity = 2f;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public float gravity = -9.81f;
    Vector3 velocity;

    

    //Variables for ground check and jumping.
    public bool grounded;
    public Transform groundCheck;
    public float groundDistance = 0.1f;
    public LayerMask groundMask;

    //Extra stuff that does not fit previous categories.
    public CharacterController controller;
    public Transform cam;
    public GameObject ODirector;
    public GameAssets assets;
    public Director director;

    // Start is called before the first frame update
    void Start()
    {
        GameObject Obj;
        //ODirector = GameObject.Find("Director");
        Obj = GameObject.Find("GameAssets");
        assets = Obj.GetComponent<GameAssets>();
        director = Obj.GetComponent<Director>();
    }

    // Update is called once per frame
    void Update()
    {
        //Check to assign value to grounded variable and determine where it is.
        grounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if(grounded && velocity.y < 0){
            //If it's on the ground, keep it on there.
            velocity.y = -2f;
        }
        //Getting Horizontal and Vertical axis for player movement.
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        //Vector direction that controlls player movement in the x and z axis.
        Vector3 movementDirection = new Vector3(horizontalInput,0,verticalInput).normalized;

        //Calculating general jump ecuation. Before adding gravity so it doesn't
        //cancel it out.
        if(Input.GetButtonDown("Jump") && grounded){
            velocity.y = Mathf.Sqrt(jumpVelocity * -2f * gravity);
            assets.PlayJump();
        }

        //Adding the gravity permanently before any other movement other than jump.
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        //Rotation is cursor dependant. The forward movement will always be where the
        //camera is looking at.
        if(movementDirection.magnitude >= 0.1f){

            float targetAngle = Mathf.Atan2(movementDirection.x, movementDirection.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            //Making the turning of the camera more smooth so its not extremely sudden.
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothV, turnSmoothT);
            transform.rotation = Quaternion.Euler(0f, angle,0f);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            //We make the character turn and the camera if neccesary
            controller.Move(moveDir * speed * Time.deltaTime);

        }

        //Fast version of the fall after jumping. Also works for falling of a ledge.
        if(velocity.y < 0){
            velocity.y += gravity * (fallMultiplier -1) * Time.deltaTime; 
        }
        //Slow version of the fall. Condition of getButton Jump as to check the 
        //user is not holding key, and apply different physics of falling.
        else if(velocity.y > 0 && !Input.GetButton("Jump")){
            velocity.y += gravity * (lowJumpMultiplier - 1) * Time.deltaTime; 
        }

        //Director call so we can call the menu.
        if (Input.GetKeyDown(KeyCode.Escape)){
            director.GoToMain();
        }
    }
}

          

    
    
    





