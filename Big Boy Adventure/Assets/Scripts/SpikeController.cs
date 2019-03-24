using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeController : MonoBehaviour {

	public Rigidbody2D rb;
	public SwitchSpikeController controller;
	public JungHeadController jungController;



	// Use this for initialization
	void Start () {
		jungController=FindObjectOfType<JungHeadController>();
		controller=FindObjectOfType<SwitchSpikeController>();
		rb=GetComponent<Rigidbody2D>();
		//rb.velocity=new Vector3(0f,0f,0f);

	}
	
	// Update is called once per frame
	void FixedUpdate () {
	if (controller.isActived==true)
		{
			//rb.AddForce( new Vector3(0f,-2f,0f));
			rb.velocity=new Vector3(0f,-5f,0f);
		} else{
			//rb.AddForce(Vector3.up);
			rb.velocity=new Vector3(0f,5f,0f);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag=="Enemy"){
			jungController.isDead=true;
		}
		
	}
}

