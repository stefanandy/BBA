using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level4CameraTransformer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	 private void OnCollisionEnter2D(Collision2D other) {
		FindObjectOfType<CameraController>().yMin=-8.3f;
	}
}
