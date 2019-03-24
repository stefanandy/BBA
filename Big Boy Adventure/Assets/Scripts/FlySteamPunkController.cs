using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class FlySteamPunkController : MonoBehaviour {

	public Transform fireSpawn;
	public GameObject fatBoy;

	public PlayerController thePlayer;
	public bool inArea;

	private float nextFire;
	public float fireRate;

	public float Maxlife;
	public float currentLife;

	public bool defeated;

	public GameObject flydead;
	public Transform flyDeadPosition;
	public GameObject explosion;
	public GameObject WinScreen;
	public string sceneName;
	public Slider healthbar;
	//private bool reward;


	// Use this for initialization
	void Start () {
		Scene currentScene=SceneManager.GetActiveScene();//check scene name
		sceneName=currentScene.name;
		defeated=false;
		Maxlife=20;
		currentLife=Maxlife;
		thePlayer=FindObjectOfType<PlayerController>();
		inArea=false;
		//reward=false;
	}
	
	// Update is called once per frame
	void Update () {
		if(defeated==false&&sceneName!="scene6" && sceneName!="scene9"){
			Vector3 screenPosition=Camera.main.WorldToScreenPoint(new Vector3(gameObject.transform.position.x,gameObject.transform.position.y+2f,gameObject.transform.position.z));
			healthbar.transform.position=screenPosition;
		}
		if(inArea==true&&thePlayer.isDying==false){
			if(Time.time>nextFire){
			nextFire=Time.time+fireRate;
			Instantiate(fatBoy,fireSpawn.position, fireSpawn.rotation);
			}
		}
		if(sceneName!="scene6"||sceneName!="scene9"){
			if(gameObject.activeInHierarchy){
				healthbar.value=CalculateLife();
			}
		}
		//Debug.Log(damage);
		if(currentLife<=0){
			defeated=true;
			//reward=true;
		}
		if(defeated==true){
			healthbar.gameObject.SetActive(false);
			Instantiate(explosion,flyDeadPosition.position,flyDeadPosition.rotation);
			Instantiate(flydead,flyDeadPosition.position,flyDeadPosition.rotation);
			//Destroy(gameObject);
			
			PlayerPrefs.SetInt("scoreUR",PlayerPrefs.GetInt("scoreUR")+100);
			//reward=false;
			
			if(sceneName!="scene7")
				WinScreen.gameObject.SetActive(true);
			gameObject.SetActive(false);
			
		//	Time.timeScale=0f;
		}
		
	}
	 float CalculateLife(){
			return currentLife/Maxlife;
		}
}
