using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;
public class DoorController : MonoBehaviour {

	public Text doorText;
	public bool isReady;
	private int counter;
	public string firstLevel;
	public PlayerController thePlayer;

	// Use this for initialization
	void Start () {
		thePlayer=FindObjectOfType<PlayerController>();
		isReady=false;
	}
	
	// Update is called once per frame
	void Update () {
		
		/*if (thePlayer.action==true){
			isReady=true;
			counter++;
			Debug.Log(counter);
		} */

		/*if(thePlayer.action==true){
			isReady=true;
		}
		 if(thePlayer.action==false){
			isReady=false;
		} */

		if(isReady==true&&thePlayer.action==true){
		
		/*if (PlayerPrefs.GetInt("AdsNumber")!=1){
			if(Advertisement.IsReady()){
			Advertisement.Show("rewardedVideo");
			}
		} */	
			Debug.Log("Incarcam scena");
			SceneManager.LoadScene(firstLevel);
	}
	}

	
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag=="Player"){
		
		doorText.text="Press 'E' to start";
		isReady=true;
		

		}
	}


	
	void OnTriggerStay2D(Collider2D other)
	{
		if(other.gameObject.tag=="Player"){
			isReady=true;
		}

		//if (isReady==true&& counter==2){
		/*if(isReady==true){
			if(Advertisement.IsReady()){
			Advertisement.Show();
			}	
			Debug.Log("Incarcam scena");
			SceneManager.LoadScene(firstLevel);
		} /* */
		
	}

	
	void OnTriggerExit2D(Collider2D other)
	{	
		doorText.text="";
		
	}
}
