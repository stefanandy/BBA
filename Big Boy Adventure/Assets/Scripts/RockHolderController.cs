using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockHolderController : MonoBehaviour {

	public SwitchInstantiate controller;

	// Use this for initialization
	void Start () {
		controller=FindObjectOfType<SwitchInstantiate>();
	}
	
	// Update is called once per frame
	void Update () {

		if(controller.isActived==true){
			gameObject.SetActive(true);
		}else{
			gameObject.SetActive(false);
		}
		
		
	}
}
