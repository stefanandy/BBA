using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FatBoyController : MonoBehaviour {

	public PlayerController myPlayer;

	public Rigidbody2D fatboyRb; 
	public string sceneName;

	public GameObject explosion;
    public static int contorBomb;
    public GameObject uranium;

	//public int contorBomb=1;

	


	// Use this for initialization
	void Start () {

        //  urSpawned=false;
        
		Scene currentScene=SceneManager.GetActiveScene();
		sceneName=currentScene.name;
		myPlayer=FindObjectOfType<PlayerController>();
		fatboyRb=GetComponent<Rigidbody2D>();
		if(sceneName=="scene4" || sceneName=="scene6"){
			fatboyRb.constraints= RigidbodyConstraints2D.None;
			fatboyRb.velocity=Vector3.down;
			transform.localScale=new Vector3(0.15f,-0.15f,0.15f);
		} else {
			fatboyRb.velocity=new Vector3(-10f,0f,0f);
		}
		Destroy(gameObject,2f);

	}
	
	// Update is called once per frame
	void Update () {
		
		
			
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
			
			if(other.gameObject.tag=="Player"){
				myPlayer.isDying=true;
				Instantiate(explosion,transform.position,Quaternion.identity);
				gameObject.SetActive(false);

			}
			if(other.gameObject.tag=="Enemy"){
				other.gameObject.SetActive(false);
			}
            if (other.gameObject.tag == "Ground") {
                
                Instantiate(explosion, transform.position, Quaternion.identity);
                //contorBomb = contorBomb + 1;
                if (contorBomb % 5 == 0) {
                       Instantiate(uranium, transform.position, Quaternion.identity);
                   }
                gameObject.SetActive(false);
            }

			
				
				/*if(contorBomb%5==0 )
						Instantiate(uranium,transform.position,Quaternion.identity);*/
		
			if(other.gameObject.tag=="Crates"){
				Debug.Log("contact cutie");
				Instantiate(explosion,transform.position,Quaternion.identity);
				gameObject.SetActive(false);
				other.gameObject.SetActive(false);
			}
		
		
		}
		
	}

