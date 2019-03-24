using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UraniumController : MonoBehaviour {

	public bool uranium;
	public int uraniumCounter;
	public LevelManager theLevelManager;
	public int uraniumValue;
	public Rigidbody2D uraniumRB;

	// Use this for initialization
	void Start () {
		uraniumValue=1;
		//uraniumCounter=0;
		uranium=false;
		theLevelManager=FindObjectOfType<LevelManager>();
		uraniumRB=GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	
	
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag=="Player")
		{
			uranium=true;
			theLevelManager.UraniumToAdd(uraniumValue);
			gameObject.SetActive(false);
		}

	} 
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag=="Player")
		{
			uranium=true;
			theLevelManager.UraniumToAdd(uraniumValue);
			gameObject.SetActive(false);
		}
		
	}
}
