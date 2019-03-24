using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatofrmController : MonoBehaviour {

	public SwithController sController;
	public Rigidbody2D mrb;
	public float fallSpeed;

	// Use this for initialization
	void Start () {
		fallSpeed=0f;
		mrb=GetComponent<Rigidbody2D>();
		sController=FindObjectOfType<SwithController>();
		mrb.velocity=new Vector3(0f,fallSpeed,0f);
	}
	
	// Update is called once per frame
	void Update () {
		PlatformFall();
	}

	void PlatformFall(){

		if (sController.isActived==true)
		{		
			fallSpeed=5f;
			mrb.velocity=new Vector3(0f,-fallSpeed,0f);
			
		}

	}
}
