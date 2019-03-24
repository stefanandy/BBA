using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaController : MonoBehaviour {

	public PlayerController thePlayer;

	// Use this for initialization
	void Start () {
		thePlayer=FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag=="Player"){

				thePlayer.isDying=true;
		}
		if(other.gameObject.tag=="Enemy"){
			other.gameObject.SetActive(false);
		}
	}
}
