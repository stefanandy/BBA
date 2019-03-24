using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RoboFlyController : MonoBehaviour {


	public Transform leftPoint;
	public Transform rightPoint;

	public float speed;

	public GameObject roboFly;

	public Transform bombHolder;

	public GameObject bomb;
	public GameObject explosion;

	public float fireRate;
	public float nextFire;

    public bool defetead;

	public int life=20;

	public PlayerController thePlayer;

	private Vector3 currentTarget;

	public Slider healthBar;
	public float MaxHealth;
	public float CurrentHealth;


	// Use this for initialization
	void Start () {
		
		MaxHealth=life;
		CurrentHealth=MaxHealth;
		defetead=false;
		thePlayer=FindObjectOfType<PlayerController>();
		currentTarget=rightPoint.position;
		
	}
	
	// Update is called once per frame
	void Update () {
		
		roboFly.transform.position=Vector3.MoveTowards(roboFly.transform.position, currentTarget,speed*Time.deltaTime);
		CurrentHealth=life;
		if(gameObject.activeInHierarchy==true && FindObjectOfType<LevelManager>().sceneName=="scene6"){
			healthBar.value=CalculateLife();
		} else if(FindObjectOfType<LevelManager>().sceneName=="scene6"&&gameObject.activeInHierarchy==false){
			healthBar.gameObject.SetActive(false);
		}

		MoveRoboFlyLeftToRught();
		RoboFire();
		//actionIsTriggerd();
		Dead();
		//Debug.Log(life);
	}


	void FixedUpdate()
	{

		
	}

	float CalculateLife(){
		return CurrentHealth/MaxHealth;
	}


	void MoveRoboFlyLeftToRught(){

		if(roboFly.transform.position==leftPoint.position)
				currentTarget=rightPoint.position;
		if(roboFly.transform.position==rightPoint.position)
				currentTarget=leftPoint.position;

	}

	void RoboFire(){
		if(Time.time>nextFire && actionIsTriggerd()==true ){
			//Debug.Log("CADE BOMBA CADE BOMBA CADE BOMBA CADE BOMBA");
			nextFire=Time.time+fireRate;
			Instantiate(bomb,bombHolder.position,bombHolder.rotation);
	
	
		}
	}


	public void Dead(){
		if(life<=0){
			defetead=true;
		}
		if(defetead==true){
			PlayerPrefs.SetInt("scoreUR",PlayerPrefs.GetInt("scoreUR"+100));
			Instantiate(explosion,transform.position,Quaternion.identity);
			gameObject.SetActive(false);
		}
	}


	public bool actionIsTriggerd(){
		if(Mathf.Abs(transform.position.x-thePlayer.transform.position.x)<5f)
			return true;
		else 
			return false;
	}


}

