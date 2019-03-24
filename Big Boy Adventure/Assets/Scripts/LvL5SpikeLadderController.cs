using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvL5SpikeLadderController : MonoBehaviour {

	public GameObject ladder;
	public Transform targetPos;
	[SerializeField]
		private float moveSpeed;
		private bool canMove;

	// Use this for initialization
	void Start () {
		canMove=false;
	}
	
	// Update is called once per frame
	void Update () {
		if(canMove==true){
			ladder.gameObject.transform.position=Vector2.MoveTowards(ladder.transform.position,targetPos.position,moveSpeed*Time.deltaTime);
			
		
		}
		
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag=="Player" && FindObjectOfType<PlayerController>().action &&FindObjectOfType<LevelManager>().uraniumCount>0){
			canMove=true;
			FindObjectOfType<LevelManager>().uraniumCount=0;
			//FindObjectOfType<CameraController>().yMax=132f;
		}	
	}

	private void OnTriggerStay2D(Collider2D other) {
		if(other.gameObject.tag=="Player" && FindObjectOfType<PlayerController>().action&&FindObjectOfType<LevelManager>().uraniumCount>0 ){
			canMove=true;
			FindObjectOfType<LevelManager>().uraniumCount=0;
			//FindObjectOfType<CameraController>().yMax=132f;
		}
	}
}
