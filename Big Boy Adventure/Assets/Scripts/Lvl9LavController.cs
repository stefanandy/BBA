using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl9LavController : MonoBehaviour {

	public GameObject lava;
	public bool active;
	//public Transform firstPos, secondPos;
	[SerializeField]
	 private bool actionIsTrue;

	public PlayerController thePlayer;

	// Use this for initialization
	void Start () {
		thePlayer=FindObjectOfType<PlayerController>();
		active=false;
		actionIsTrue=false;
	}
	
	// Update is called once per frame
	void Update () {
		if(active==true&&actionIsTrue==true){

			StartCoroutine(LavaController(7.5f));
			//active=false;
			//lava.gameObject.SetActive(false);
			
		}
		if(thePlayer.action==true){
			 StartCoroutine(ActionWasTrue(0.5f));
		}
	}
	private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag=="Player"){
			active=true;
			
			//StartCoroutine(LavaController(7.5f));
		}
	}
	private void OnTriggerStay2D(Collider2D other)
	{
		if(other.gameObject.tag=="Player"){
			active=true;
			
			//StartCoroutine(LavaController(7.5f));
		}

		
	}

	IEnumerator LavaController(float s){
		lava.gameObject.SetActive(true);
		yield return new WaitForSeconds(s);
		lava.gameObject.SetActive(false);
		active=false;
		
		
		

	}

	IEnumerator ActionWasTrue(float seconds){
		actionIsTrue=true;
		yield return new WaitForSeconds(seconds);
		actionIsTrue=false;
	}
}
