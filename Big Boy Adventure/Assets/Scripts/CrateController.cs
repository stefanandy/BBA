using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateController : MonoBehaviour {

	public GameObject deadExplosion;
	public Transform explosionSpawn;
	//public bool explosion;
	public GameObject amethist;
	public Transform ametistPos;

	// Use this for initialization
	void Start () {
		//explosion=false;
	}
	
	// Update is called once per frame
	void Update () {

		/* if(explosion==true){ //destroy the create and instantiate and explosion at the choosend cordinates;
			gameObject.SetActive(false);
			Instantiate(deadExplosion,explosionSpawn.position, explosionSpawn.rotation);
		}*/
		
		
	}
	private void OnCollisionEnter2D(Collision2D other) {
		if(other.gameObject.tag=="Bullet"){
			Instantiate(deadExplosion,explosionSpawn.position,explosionSpawn.rotation);
			if(amethist.activeInHierarchy==false){
				Instantiate(amethist,ametistPos.position,Quaternion.identity);
			}
			Destroy(other.gameObject);
			Destroy(gameObject);
		}	
	}
}
