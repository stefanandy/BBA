using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoController : MonoBehaviour {

	public GameObject InfoScreen;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame


	public void InfoButton(){
		InfoScreen.gameObject.SetActive(true);
	}

	public void FbButton(){
		Application.OpenURL("https://www.facebook.com/2-Genius-GAMES-319822045538019/?modal=admin_todo_tour");
	}
	public void InstaButton(){
		Application.OpenURL("https://www.instagram.com/2geniusgames/");
	}
	public void PrivacyPolicies(){
		Application.OpenURL("http://privacypolicy.filipescu.ml/");
	}
	public void CloseScreen(){
		InfoScreen.gameObject.SetActive(false);
	}
}
