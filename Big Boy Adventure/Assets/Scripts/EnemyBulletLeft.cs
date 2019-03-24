using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletLeft : MonoBehaviour {
	public float speed;

	public Rigidbody2D bulletRB;

	public PlayerController thePlayer;

	// Use this for initialization
	void Start () {
		bulletRB=GetComponent<Rigidbody2D>();
		thePlayer=FindObjectOfType<PlayerController>();
		bulletRB.velocity=new Vector2(-speed,0f);
		Destroy(gameObject,1f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag=="Player"){
			Destroy(gameObject);
			thePlayer.isDying=true;
		}
		if(other.gameObject.tag=="Lava"){
			Destroy(gameObject);
		}
		if(other.gameObject.tag=="Car"){
			Destroy(gameObject);
		}		
	}
}
