using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

	[SerializeField]
	private Transform twoDimTransform;
	[SerializeField]
	private Transform threeDimTransform;

	private Camera camera;
	private Vector3 toPosition;
	private Quaternion toRotation;
	
	private float camChangeSpeed = 10f;

	void Start(){
		camera = GetComponent<Camera>();
		transform.position = SetPosition();
		transform.rotation = SetRotation();
	}

	// Update is called once per frame
	void Update () {
		camera.orthographic = SceneManager.inTwoDimensions;
		toPosition = SetPosition();
		toRotation = SetRotation();
		transform.position = Vector3.Lerp(transform.position, toPosition, camChangeSpeed * Time.deltaTime);
		transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, camChangeSpeed * Time.deltaTime);
	}

	Vector3 SetPosition(){ return SceneManager.inTwoDimensions ? twoDimTransform.position : threeDimTransform.position; }

	Quaternion SetRotation(){ return SceneManager.inTwoDimensions ? twoDimTransform.rotation : threeDimTransform.rotation; }
}
