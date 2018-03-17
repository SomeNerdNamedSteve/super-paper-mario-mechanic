using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour {

	public static bool inTwoDimensions;

	// Use this for initialization
	void Start () {
		inTwoDimensions = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.LeftShift)){
			inTwoDimensions = !inTwoDimensions;
		}
	}
}
