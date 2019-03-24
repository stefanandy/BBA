using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level5FirstCameraChanger : MonoBehaviour {

	//private int changer=0;

	// Use this for initialization
	[SerializeField]
	private float y;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter2D(Collision2D other) {
		if(other.gameObject.tag=="Player"){
			FindObjectOfType<CameraController>().yMax=0.68f;
			
		}
	}
	private void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag=="Player"){
			//ymax=17.6f
			FindObjectOfType<CameraController>().yMax=y;
		}
	}
}
