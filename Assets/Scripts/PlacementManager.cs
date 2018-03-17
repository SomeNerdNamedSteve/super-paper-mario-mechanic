using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementManager : MonoBehaviour {

	enum Interactability {TWO_DIMS_ONLY, THREE_DIMS_ONLY, TWO_AND_THREE_DIMS};


	[SerializeField]
	private Interactability interactability;

	private Collider collider;
	private MeshRenderer renderer;

	private Vector3 position;

	// Use this for initialization
	void Start () {
		collider = GetComponent<Collider>();
		renderer = GetComponent<MeshRenderer>();
		position = transform.position;
		if(interactability == Interactability.TWO_DIMS_ONLY){
			transform.position = new Vector3(0, transform.position.y, transform.position.z);
		}
	}



	// Update is called once per frame
	void Update () {
		Vector3 toPosition;
		float toPositionX = 2;
		switch(interactability){
			case Interactability.TWO_DIMS_ONLY:
				renderer.enabled = SceneManager.inTwoDimensions;
				collider.enabled = SceneManager.inTwoDimensions;
				break;
			case Interactability.THREE_DIMS_ONLY:
				renderer.enabled = !SceneManager.inTwoDimensions;
				collider.enabled = !SceneManager.inTwoDimensions;
				break;
			case Interactability.TWO_AND_THREE_DIMS:
				RaycastHit hit;
				bool objectInFront = Physics.Raycast(transform.position, Vector3.left, out hit, 5);
				toPositionX = objectInFront ? 2 : 0;
				toPosition = SceneManager.inTwoDimensions ? new Vector3(toPositionX, position.y, position.z) : position;
				transform.position = Vector3.Lerp(transform.position, toPosition, 5 * Time.deltaTime);
				break;
			default:
				break;
		}
		
	}

}
