using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController1 : MonoBehaviour {

	public Animator myAnim;
	public LevelManager theLevelManager;
	// Use this for initialization
	void Start () {
		//myAnim.enabled=false;	
		myAnim=GetComponent<Animator>();
		theLevelManager=FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		//myAnim.enabled=false;		
	}

	
	void OnTriggerStay2D(Collider2D other)
	{
		if(other.tag=="Player"){	

			if(theLevelManager.uraniumCount%4==3){
				myAnim.Play("DoorOpening");
			}

		}

	}
}
