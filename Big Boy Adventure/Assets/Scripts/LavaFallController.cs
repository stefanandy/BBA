using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaFallController : MonoBehaviour {

	public LevelManager theLevelManager;
	private bool goindToDie;
	public PlayerController thePlayer;

	public GameObject explosion;

	public int contor=1;

	

	// Use this for initialization
	void Start () {
		thePlayer=FindObjectOfType<PlayerController>();
		goindToDie=true;
		theLevelManager=FindObjectOfType<LevelManager>();

	}
	
	// Update is called once per frame
	void Update () {

		if(theLevelManager.uraniumCount==3){
			goindToDie=false;
		} else if(theLevelManager.uraniumCount!=3){
			goindToDie=true;
		}
		
	}


	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag=="Bullet"){
			Destroy(other.gameObject);
		}

		if(other.tag=="Player"){
			if (goindToDie)
			{
				thePlayer.isDying=true;
			} else{
				theLevelManager.uraniumCount=0;
			}
		}
		if(other.gameObject.tag=="Boss"){
			//Destroy(other.gameObject);
			other.gameObject.SetActive(false);
			FindObjectOfType<WinScreenScontroler>().contor++;
			Instantiate(explosion,other.transform.position,Quaternion.identity);
			Handheld.Vibrate();
		}
		
	}

	/* private void OnTriggerStay2D(Collider2D other) {
		if(other.gameObject.tag=="Boss"){
			Destroy(other.gameObject);
		}
	}

	/*private void OnTriggerExit2D(Collider2D other) {
		if(other.gameObject.tag=="Boss"){
			Destroy(other.gameObject);
		}
	}*/

}
