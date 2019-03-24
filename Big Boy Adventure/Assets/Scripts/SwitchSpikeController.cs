using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchSpikeController : MonoBehaviour {

	public bool isActived;
	private SpriteRenderer theSpriteRenderer;
	public Sprite swithOff;
	public Sprite switchOn;
	private bool stay;
	private int switchCounter;
	public LevelManager theLvlManager;
	public UraniumController theUranium;
	public PlayerController thePlayer;



	// Use this for initialization
	void Start () {
		thePlayer=FindObjectOfType<PlayerController>();
		switchCounter=0;
		isActived=false;
		theSpriteRenderer=GetComponent<SpriteRenderer>();
		theLvlManager=FindObjectOfType<LevelManager>();
		
	}
	
	// Update is called once per frame
	void Update () {

		if (stay)
		{	
			if (thePlayer.action==true&&theLvlManager.uraniumCount>0)
			{
				theSpriteRenderer.sprite=switchOn;
				isActived=true;
				theLvlManager.uraniumCount-=1;
				switchCounter++;
			}

			
		}
		if (switchCounter%4==0)
		{
				theSpriteRenderer.sprite=swithOff;
				isActived=false;
				
		}
		else{
			theSpriteRenderer.sprite=switchOn;
			isActived=true;
		}
		
	}


	void OnTriggerStay2D(Collider2D other)
	{
		if (other.tag=="Player")
		{
			stay=true;
			
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if(other.tag=="Player"){
			stay=false;
		}		
	}
}


