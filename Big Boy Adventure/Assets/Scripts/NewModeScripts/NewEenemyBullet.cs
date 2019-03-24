using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEenemyBullet : MonoBehaviour {

	public float speed;
	public Rigidbody2D bulletRB;
	public NewPlayerController thePlayer;

	// Use this for initialization
	void Start () {
		bulletRB=GetComponent<Rigidbody2D>();
		thePlayer=FindObjectOfType<NewPlayerController>();
		bulletRB.velocity=new Vector2(-speed,0f);
		transform.localScale=new Vector2(-0.0708974f,0.0708974f);
		
		Destroy(gameObject,1f);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{	
		if(other.gameObject.tag=="Player"){
			Destroy(gameObject);
			thePlayer.isDead=true;
		}
		
	}
}
