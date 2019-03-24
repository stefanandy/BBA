using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level5SpikeSwitcher : MonoBehaviour {

	public bool active;
	public GameObject  firstsSpike, secondSpike,thirdSpike, fourthSpike;
	public Transform targetPosition;
	public float firstSpikeSeconds, secondSpikeSeconds, thirdSpikeSeconds, fourthSpikeSeconds;

	// Use this for initialization
	void Start () {
		active=false;
	}
	
	// Update is called once per frame
	void Update () {
		if(active==true){
			StartCoroutine(MoveSpike(firstSpikeSeconds,firstsSpike));
			StartCoroutine(MoveSpike(secondSpikeSeconds,secondSpike));
			StartCoroutine(MoveSpike(thirdSpikeSeconds,thirdSpike));
			StartCoroutine(MoveSpike(fourthSpikeSeconds,fourthSpike));
			//FindObjectOfType<LevelManager>().uraniumCount=0;	
		}
		
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag=="Player"&&FindObjectOfType<PlayerController>().action==true&&FindObjectOfType<LevelManager>().uraniumCount==3){
			active=true;
			FindObjectOfType<LevelManager>().uraniumCount=0;
		}
	}
	private void OnTriggerStay2D(Collider2D other) {
		if(other.gameObject.tag=="Player"&&FindObjectOfType<PlayerController>().action==true&&FindObjectOfType<LevelManager>().uraniumCount==3){
			active=true;
			FindObjectOfType<LevelManager>().uraniumCount=0;
		}
	}

	IEnumerator MoveSpike(float seconds, GameObject spike){
		yield return new WaitForSeconds(seconds);
		spike.gameObject.transform.position=Vector2.MoveTowards(spike.gameObject.transform.position,new Vector2(spike.gameObject.transform.position.x,targetPosition.position.y-5f),3f*Time.deltaTime);
	}
	private void OnTriggerExit2D(Collider2D other) {
		
	}
}
