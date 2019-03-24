using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour {

	public Rigidbody2D grRB;
	public bool contact;

	// Use this for initialization
	void Start () {
		contact=false;
		grRB=GetComponent<Rigidbody2D>();
		grRB.velocity=new Vector2(0f,0f);
	}
	
	// Update is called once per frame
	void Update () {

		if(contact==true){
			//grRB.velocity=new Vector2(0f,20f);
			grRB.AddForce(Vector3.up*300);
		}
		
	}
}
