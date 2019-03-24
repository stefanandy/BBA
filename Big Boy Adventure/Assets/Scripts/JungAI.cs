using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JungAI : MonoBehaviour {

	public bool see;
	public bool seePlayer;

	// Use this for initialization
	void Start () {

		see=false;
		seePlayer=false;
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(see==true){
			seePlayer=true;
		}
	}

	
	void OnTriggerEnter2D(Collider2D other)
	{

		if(other.gameObject.tag=="Player"){
			see=true;	
			//Debug.Log("Te-am gasit");
			Debug.Log("See variable=" + see);
		}
		
	}

	
	void OnTriggerStay2D(Collider2D other)
	{
		if(other.gameObject.tag=="Player"){
			see=true;
			//Debug.Log("Te-am gasit");	
		}
	}

	
	void OnTriggerExit2D(Collider2D other)
	{	
		if(other.gameObject.tag=="Player"){
			//Debug.Log("Te-am gasit");
			see=true;
			//Debug.Log(see);	
		}
		
	}
}
