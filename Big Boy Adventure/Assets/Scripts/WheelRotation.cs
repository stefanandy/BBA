using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelRotation : MonoBehaviour {


	public PlayerController thePlayer;
	// Use this for initialization
	[SerializeField]
	float RotateSpeed;

	void Start () {
		thePlayer=FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	 private void FixedUpdate() {
		
		 if(thePlayer.moveLeft==true|| thePlayer.moveRight==true) 
		 	transform.Rotate(Vector3.forward*-RotateSpeed);
	}
}
