using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2SpikeSwitchControoler : MonoBehaviour {

	public LevelManager tehLevelManager;
	public Sprite switchOn,switchOf;
	public PlayerController thePlayer;
	public bool isActived;
	private bool isStaying;
	private SpriteRenderer theSprite;
	

	// Use this for initialization
	void Start () {
		thePlayer=FindObjectOfType<PlayerController>();
		tehLevelManager=FindObjectOfType<LevelManager>();
		theSprite=GetComponent<SpriteRenderer>();
		isActived=false;
		isStaying=false;

	}
	
	// Update is called once per frame
	void Update () {
		if(isStaying==true&&tehLevelManager.uraniumCount>0&&thePlayer.action==true){
			tehLevelManager.uraniumCount-=1;
			theSprite.sprite=switchOn;
			isActived=true;

		}
	}

	private void OnTriggerStay2D(Collider2D other) {
		if(other.gameObject.tag=="Player"&&thePlayer.action==true){
			isStaying=true;
		}
	}
}
