using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LVL5SecondcCrateController : MonoBehaviour {

	[SerializeField]
	private GameObject explosion;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter2D(Collision2D other) {
		if(other.gameObject.tag=="Bullet"){
			Destroy(other.gameObject);
			Instantiate(explosion,transform.position,Quaternion.identity);
			Destroy(gameObject);
		}
	}
}
