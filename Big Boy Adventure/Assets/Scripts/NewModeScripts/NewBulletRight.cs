using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBulletRight : MonoBehaviour {

	public float speed;
	public Rigidbody2D rb;
	public JuController junghead;
	//public NEWJUController enemy;


	// Use this for initialization
	void Start () {
	//	enemy=GetComponent<NEWJUController>();
		rb=GetComponent<Rigidbody2D>();
		junghead=FindObjectOfType<JuController>();
		rb.velocity=new Vector2(speed,0f);
		Destroy(gameObject,2f);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag=="Enemy"){
			 junghead.dead=true;
			 Debug.Log(junghead.dead);
			 Debug.Log("l-am lovit bagami-as pl in capu lui,trigger ");
			 Destroy(gameObject);
		}
		//Debug.Log("l-am lovit bagami-as pl in capu lui , trigger afara");

		//other.gameObject.SetActive(false);
		junghead.dead=true;
	//	enemy.dead=true;
	}

	
	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag=="Enemy"){
			 //jg.dead=true;
			 Debug.Log("l-am lovit bagami-as pl in capu lui, collision ");
		}
		Debug.Log("collision");
	}
}
