using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {

	public PlayerController thePlayer;
	public Rigidbody2D rb;
	[SerializeField]
	float moveSpeed;
	// Use this for initialization
	void Start () {
		thePlayer=FindObjectOfType<PlayerController>();
		rb=GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
	/*	if(thePlayer.transform.localScale.x==1){
			
			transform.localScale=new Vector3(-1,1,1);
		}else if(thePlayer.transform.localScale.x==-1){
			moveSpeed=-moveSpeed;
			transform.localScale=new Vector3(-1,1,1);
		}
		*/
	}

	 private void FixedUpdate() {
		if(thePlayer.transform.parent!=null){ 
			 if(thePlayer.moveLeft==true){
			 	rb.velocity= new Vector2(-moveSpeed,transform.position.y);
		 		//Translate.transform=Vector2.left;
			 
			 }
			if(thePlayer.moveRight==true){
				rb.velocity=new Vector2(moveSpeed,transform.position.y);
			}
			if(thePlayer.jump==true&&thePlayer.isGrounded){
				rb.velocity=new Vector2(transform.position.x,thePlayer.jumpSpeed);
			}
		}
	}

	IEnumerator WaitS(float s){
			yield return new WaitForSeconds(s);
	}

	private void OnCollisionEnter2D(Collision2D other) {
		/* *if(other.gameObject.tag=="Enemy"){
			//Debug.Log("Masina face contact");
			FindObjectOfType<JungHeadController>().isDead=true;
			//StartCoroutine(WaitS(2));
			//other.gameObject.SetActive(false);
		}*/
		
	}

}
