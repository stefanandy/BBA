using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCameraController : MonoBehaviour {

	public GameObject maineMenu ,urShop, skinShop, modeSelector, levelSelector;
	public bool moveToMainMenu, moveToUrShop, moveToSkinShop, moveToModeSelector, moveToLevelSelector;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		MoveToSelectedScreen();

	}

	void MoveToSelectedScreen(){
		if(moveToLevelSelector==true){
			transform.position=Vector2.MoveTowards(transform.position,levelSelector.transform.position,2f*Time.deltaTime);
		}
		if(moveToModeSelector==true){
			transform.position=Vector2.MoveTowards(transform.position,modeSelector.transform.position,2f*Time.deltaTime);
		}
		if(moveToSkinShop==true){
			transform.position=Vector2.MoveTowards(transform.position,skinShop.transform.position,2f*Time.deltaTime);
		}
		if(moveToUrShop==true){
			transform.position=Vector2.MoveTowards(transform.position,urShop.transform.position,2f*Time.deltaTime);
		}
	}

	public void SelectUrShop(){
		moveToUrShop=true;
	}
	public void SelectSkinShop(){
		moveToSkinShop=true;
	}

	public void SelectLevelSelector(){
		moveToLevelSelector=true;
	}
	public void SelectModeSelector(){
		moveToModeSelector=true;
	}
	public void CloseScreen(){
		//transform.position=Vector2.MoveTowards(transform.position,maineMenu.transform.position,2f*Time.deltaTime);
		moveToMainMenu=true;
	}
}
