using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl5ActivateGunner : MonoBehaviour {

	// Use this for initialization
	public bool startFire;
	void Start () {
		startFire=false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag=="Player"){
			startFire=true;
		}
	}
}
