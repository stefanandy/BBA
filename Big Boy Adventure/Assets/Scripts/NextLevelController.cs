using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log("LOADING NEXT SCENE");
	}
}
