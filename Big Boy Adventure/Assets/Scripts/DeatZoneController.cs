using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeatZoneController : MonoBehaviour {

	public PlayerController thePlayer;

	//public PlayerController thePlayer;

	// Use this for initialization
	void Start () {
		
		thePlayer=FindObjectOfType<PlayerController>();

	}
	
	// Update is called once per frame
	void Update () {
	}

	
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag=="Player"){ // killing the player
			thePlayer.isDying=true;
		}
	}
}

