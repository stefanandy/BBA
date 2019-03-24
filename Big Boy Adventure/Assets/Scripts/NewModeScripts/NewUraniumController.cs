using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewUraniumController : MonoBehaviour {


	public NewLevelManager theLevelManager;
	public int uraniumValue;
	public Rigidbody2D uraniumRB;

	// Use this for initialization
	void Start () {
		theLevelManager=FindObjectOfType<NewLevelManager>();
		uraniumValue=1;
		uraniumRB=GetComponent<Rigidbody2D>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	
	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag=="Player"){
			theLevelManager.UraniumToAdd(uraniumValue);
			gameObject.SetActive(false);
		}
	}
}
