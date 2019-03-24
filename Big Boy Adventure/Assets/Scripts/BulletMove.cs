using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour {

	public float speed;
	public Rigidbody2D fireRgB;
	public JungHeadController jgController;

	//public CrateController crate;

	public FlySteamPunkController theBoss;
	public GameObject explosion;

	// Use this for initialization
	void Start () {
		
		theBoss=FindObjectOfType<FlySteamPunkController>();
		//crate=FindObjectOfType<CrateController>();
		//explosion=crate.deadExplosion;
		jgController=FindObjectOfType<JungHeadController>();
		fireRgB=GetComponent<Rigidbody2D>();
		fireRgB.velocity=new Vector2(speed,0f);
		Destroy(gameObject,2f);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnCollisionEnter2D(Collision2D other)
	{	
		//Debug.Log("contact");

		if (other.gameObject.tag=="Enemy"){

			//jgController.deadFromBullet=true;//destroy enmey
			Destroy(gameObject); 
		}
		/* if (other.gameObject.tag=="Crate"){
			Destroy(other.gameObject);
			Instantiate(explosion,other.transform.position,Quaternion.identity);
			Destroy(other.gameObject);//destroy crate 
			
		}*/
		

		if(other.gameObject.tag=="Boss"){
			Destroy(gameObject);
			//Debug.Log("Lovim Bossu");
			 theBoss.currentLife=theBoss.currentLife-1.0f;		
			}
		
		Destroy(gameObject);
		
	}
	private void OnTriggerExit2D(Collider2D other) {
		if(other.gameObject.tag=="MainCamera"){
			Destroy(gameObject);
		}
	}
}
