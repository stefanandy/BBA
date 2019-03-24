using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour {

	public NewPlayerController thePlayer;

	// Use this for initialization
	void Start () {
		thePlayer=FindObjectOfType<NewPlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	
	void OnTriggerEnter2D(Collider2D other)
	{	if(other.gameObject.tag=="Player"){
		thePlayer.isDead=true;
		//Debug.Log("esti mort");
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag=="Player"){
		thePlayer.isDead=true;	
	}
	}
}
