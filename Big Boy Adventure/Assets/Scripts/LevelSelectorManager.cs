using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class LevelSelectorManager : MonoBehaviour {

    public GameObject LevelSelectorHolder; 
	public GameObject currentScreen;
	public static int adsContor;
	public string levelSelected;
	public GameObject[] arnieHolder;

	// Use this for initialization
	void Start () {
		adsContor=1;
		LevelSelectorHolder.gameObject.SetActive(false);
		LevelFnnished();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void LevelFnnished(){
		for(int i=0;i<PlayerPrefs.GetInt("lvlAvl")-1;i++){
				arnieHolder[i].gameObject.SetActive(true);
		}
	}

	

	public void AdventureModeSelected(){
		
		if(PlayerPrefs.GetInt("AdsNumber")!=1){
			adsContor++;
		   if(Advertisement.IsReady("video")){
				if(adsContor==3){
					adsContor=0;
					Advertisement.Show("video");
				}
			}
		}
		LevelSelectorHolder.gameObject.SetActive(true);
		currentScreen.gameObject.SetActive(false);
	}

	public void CloseLevelSelector(){

		LevelSelectorHolder.gameObject.SetActive(false);
		currentScreen.gameObject.SetActive(true);
	}

	public void LevelOneSelected(){
		levelSelected="scene1";
		SceneManager.LoadScene(sceneName: levelSelected);
	}
	public void LevelTwoSelected(){
		if(PlayerPrefs.GetInt("lvlAvl")>=2){
			levelSelected="scene2";
			SceneManager.LoadScene(sceneName: levelSelected);
		}
	}
	public void LevelThirdSelected(){
		if(PlayerPrefs.GetInt("lvlAvl")>=3){
			levelSelected="scene3";
			SceneManager.LoadScene(sceneName: levelSelected);
		}
	}
	public void LevelForSelected(){
		if(PlayerPrefs.GetInt("lvlAvl")>=4){
			levelSelected="scene4";
			SceneManager.LoadScene(sceneName: levelSelected);
		}
	}public void LevelFiveSelected(){
		if(PlayerPrefs.GetInt("lvlAvl")>=5){
			levelSelected="scene5";
			SceneManager.LoadScene(sceneName: levelSelected);
		}
	}public void LevelSixSelected(){
		if(PlayerPrefs.GetInt("lvlAvl")>=6){
			levelSelected="scene6";
			SceneManager.LoadScene(sceneName: levelSelected);
		}
	}public void LevelSevenSelected(){
		if(PlayerPrefs.GetInt("lvlAvl")>=7){
		levelSelected="scene7";
		SceneManager.LoadScene(sceneName: levelSelected);
		}
	}public void LevelEightSelected(){
		if(PlayerPrefs.GetInt("lvlAvl")>=8){
			levelSelected="scene8";
			SceneManager.LoadScene(sceneName: levelSelected);
		}
	}public void LevelNineSelected(){
		if(PlayerPrefs.GetInt("lvlAvl")>=9){
			levelSelected="scene9";
			SceneManager.LoadScene(sceneName: levelSelected);
		}
	}public void LevelTenSelected(){
		if(PlayerPrefs.GetInt("lvlAvl")>=10){
			levelSelected="scene10";
			SceneManager.LoadScene(sceneName: levelSelected);
		}
	}
	
}
