using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardiaAI : MonoBehaviour
{

	public GameObject player;
	Animator anim;

	float rotationSpeed = 2.0f;
	float speed = 2.0f;
	float visDist = 40.0f;
	float visAngle = 30.0f;
	float shootDist = 20.0f;

	string state = "IDLE";

	// Use this for initialization
	void Start()
	{
		anim = this.GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{
		Vector3 direction = player.transform.position - this.transform.position;
		float angle = Vector3.Angle(direction, this.transform.forward);

		if (direction.magnitude < visDist && angle < visAngle)
		{

			direction.y = 0;


			this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
										Quaternion.LookRotation(direction),
										Time.deltaTime * rotationSpeed);

			if (direction.magnitude > shootDist)
			{
				state = "WALKING";
				this.transform.Translate(0, 0, Time.deltaTime * speed);
			}
			else
            {
				state = "SHOOTING";
            }
		}
		else
		{
			state = "IDLE";
		}	
	}
}