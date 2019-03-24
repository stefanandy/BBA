using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level5PlatformFalling : MonoBehaviour {


	private bool canMove;
	[SerializeField]
	 private float seconds;
//	public Rigidbody2D rigidbody;

	// Use this for initialization
	void Start () {
//		rigidbody=GetComponent<Rigidbody2D>();
//		rigidbody.velocity=new Vector2(0f,0f);
		canMove=false;
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log(canMove);
		if(canMove==true){
			//transform.position=Vector2.MoveTowards(transform.position,new Vector2(transform.position.x,transform.position.y+20f),10f+Time.deltaTime);
			StartCoroutine(WaitForS(seconds: seconds));
			//Debug.Log("CanMove are valoarea TRUE");
			
		}
	}

	private void OnCollisionEnter2D(Collision2D other) {
		if(other.gameObject.tag=="Player"){
			canMove=true;
			
		}
	}

	IEnumerator WaitForS(float seconds){
		yield return new WaitForSeconds(seconds);
		//Debug.Log("Am intrat in functia de asteptare");
		//rigidbody.velocity=new Vector2(0f,-2f);
		transform.position=Vector2.MoveTowards(transform.position,new Vector2(transform.position.x,transform.position.y-3f),3f*Time.deltaTime);
		//transform.position=Vector2.down;	
	}
}
