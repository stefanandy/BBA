using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProtectorController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	
	void OnTriggerEnter2D(Collider2D other)
	{	
		if(other.gameObject.tag=="Bullet"){
			Destroy(other.gameObject); //destroy the boss if the trigger meet with a gameobject with tag bullet
		}
		
	}
}
