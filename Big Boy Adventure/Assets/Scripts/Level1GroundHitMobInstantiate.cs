using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1GroundHitMobInstantiate : MonoBehaviour {

	public GameObject enemy;



	// Use this for initialization
	void Start () {
		enemy.gameObject.SetActive(false);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter2D(Collision2D other) {
		if(other.gameObject.tag=="Player"){
			enemy.gameObject.SetActive(true);
		}
	}
}
