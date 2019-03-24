using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AlienController : MonoBehaviour {


	PlayerController thePlayer;
	[SerializeField]
	 float moveSpeed;
	 
	 string sceneName;
	[SerializeField]
	 float distance;
	[SerializeField]
	 float MinDis;
	 [SerializeField]
	 float MaxDis;

	 public bool dead;
	 public int counter=4;
	 public GameObject explosion;
	
	// Use this for initialization
		void Start () {
		
		Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
		dead=false;
		thePlayer=FindObjectOfType<PlayerController>();
		if(sceneName=="scene9"){
			 Rigidbody2D rb;
			 rb=GetComponent<Rigidbody2D>();
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		if(sceneName!="scene9"){
		transform.Translate(Vector2.up*moveSpeed*Time.deltaTime);
		}
		else{
			distance=Distance(transform.position.x,thePlayer.transform.position.x);
			if(distance<=MinDis){
					transform.position=Vector2.MoveTowards(transform.position, thePlayer.transform.position, 2.5f*Time.deltaTime);
		}
		Dead();

	}
	} 

	static float Distance(float a, float b){
		  return Mathf.Abs(a-b);
	}

	public void Dead(){
		if(counter==0){
			dead=true;
			//Instantiate(explosion,transform.position,Quaternion.identity);
		}
	}

	 private void OnCollisionEnter2D(Collision2D other) {
		if(other.gameObject.tag=="Player"){	
			thePlayer.isDying=true;
		}
		if(other.gameObject.tag=="Lava"){
			Destroy(gameObject);
		}
	}
}
