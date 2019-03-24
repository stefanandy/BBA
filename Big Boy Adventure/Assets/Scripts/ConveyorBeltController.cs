using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBeltController : MonoBehaviour {

	public PlayerController thePlayer;
	public Rigidbody2D newRB;
	public bool moment;
	

	// Use this for initialization
	void Start () {
		moment=false;
		newRB=GetComponent<Rigidbody2D>();
		thePlayer=FindObjectOfType<PlayerController>();
		//newRB.velocity=new Vector3(0f,0f,0f);
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(moment==true){
			newRB.AddForce(Vector3.up*5); //add force to go up
		}
	}

	
	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag=="Player"){

			//thePlayer.myRigidbody.AddForce(new Vector2(20f,0f));
			//other.gameObject.SetActive(false);
		//newRB.AddForce(Vector3.up*5);
			moment=true;
		}

		if(other.gameObject.tag=="Enemy"){
			other.gameObject.SetActive(false);
		}
	}
}
