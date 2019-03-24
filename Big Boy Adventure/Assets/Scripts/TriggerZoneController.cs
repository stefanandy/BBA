using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZoneController : MonoBehaviour {

	public FlySteamPunkController enemy;

	// Use this for initialization
	void Start () {

		enemy=FindObjectOfType<FlySteamPunkController>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag=="Player")
		{
			enemy.inArea=true;
		}

		
	}
}
