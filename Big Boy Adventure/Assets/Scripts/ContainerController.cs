using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerController : MonoBehaviour {

	public GameObject explosion;
	//public GameObject alien;
	public GameObject uranium;

	// Use this for initialization
	void Start () {

		
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter2D(Collision2D other) {
		if(other.gameObject.tag=="Bullet"){
			Destroy(other.gameObject);
			Destroy(gameObject);
			Instantiate(explosion,transform.position,Quaternion.identity);
			Instantiate(uranium,transform.position,Quaternion.identity);
		}
	}
}
