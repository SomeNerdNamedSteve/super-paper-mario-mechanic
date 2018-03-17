using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	private float speed = 5f;
	private CharacterController controller;
	private float gravity = -9.8f;

	private Vector3 movement = Vector3.zero;

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {

		if(controller.isGrounded){
			movement = GetPosition();
		}

		movement.y += gravity * Time.deltaTime;
		controller.Move(movement * speed * Time.deltaTime);
	}
	
	Vector3 GetPosition(){
		Vector3 move;
		float forwardMovement, sideMovement;

		if(SceneManager.inTwoDimensions){
			transform.position = new Vector3(0, transform.position.y, transform.position.z);
			forwardMovement = Input.GetAxis("Horizontal");
			sideMovement = 0;
			move = new Vector3(0, 0, forwardMovement);
		}else{
			forwardMovement = Input.GetAxis("Vertical");
			sideMovement = Input.GetAxis("Horizontal");
			move = new Vector3(sideMovement, 0, forwardMovement);
		}

		return move;
	}
}
