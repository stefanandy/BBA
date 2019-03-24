using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchInstantiate : MonoBehaviour {

	public bool isActived;
	private SpriteRenderer theSpriteRenderer;
	public Sprite swithOff;
	public Sprite switchOn;
	private bool stay;
	private int switchCounter;
	public LevelManager theLvlManager;
	public UraniumController theUranium;
	public GameObject rockPlatform;
	public Transform rockSpawn;
	public bool spawn;
	public GameObject rockWall;
	public PlayerController thePlayer;

	// Use this for initialization
	void Start () {
		stay=false;
		thePlayer=FindObjectOfType<PlayerController>();
		spawn=false;
		switchCounter=0;
		isActived=false;
		theSpriteRenderer=GetComponent<SpriteRenderer>();
		theLvlManager=FindObjectOfType<LevelManager>();

	}
	
	// Update is called once per frame
	void Update () {
			if (stay==true)
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
				spawn=false;
				rockPlatform.gameObject.SetActive(false);
				//Instantiate(rockPlatform,rockSpawn.position,rockSpawn.rotation);
				rockWall.gameObject.SetActive(true);
				
		}
		else if(switchCounter%4!=0){
			theSpriteRenderer.sprite=switchOn;
			isActived=true;
			spawn=true;
			rockPlatform.gameObject.SetActive(true);
			rockWall.gameObject.SetActive(false);
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

