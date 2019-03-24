using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2TandemSpikeController : MonoBehaviour {

	// Use this for initialization

	public Level2SpikeSwitchControoler switchSpike;
	public PlayerController thePlayer;
	public Transform farEnd;
	private Vector3 frometh;
	private Vector3 firstPosition;
 	private Vector3 untoeth;
	 [SerializeField]
	 private float secondsForOneLength = 2f; 

	 private BoxCollider2D[] colliders;

	void Start () {
		thePlayer=FindObjectOfType<PlayerController>();
		switchSpike=FindObjectOfType<Level2SpikeSwitchControoler>();
		colliders=GetComponents<BoxCollider2D>();
		firstPosition=transform.position;
		frometh = transform.position;
 		 untoeth = farEnd.position;
	}
	
	// Update is called once per frame
	void Update () {
		if(switchSpike.isActived==false){
		transform.position = Vector3.Lerp(frometh, untoeth,Mathf.SmoothStep(0f,1f,Mathf.PingPong(Time.time/secondsForOneLength, 1f)));
		} else{
			transform.position=Vector3.MoveTowards(transform.position,farEnd.position,2f*Time.deltaTime);
			colliders[1].enabled=false;
		}
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag=="Player"){
			thePlayer.isDying=true;
		}	
	}
}
