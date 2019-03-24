using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;
using UnityEngine.Analytics;


public class AmetistController : MonoBehaviour {

	public GroundController theGround;
	public string thirdLevel;
	public string fourthLevel,fifthLevel,sixthLevel,seventhLevel,eigthLevel,ninethLevel,tenthLevel;
	public string sceneName;
	public GameObject finalScreen;
	public GameObject pauseButton;

	
	// Use this for initialization
	void Start () {
		Scene currentScene= SceneManager.GetActiveScene();
		sceneName=currentScene.name;
		theGround=FindObjectOfType<GroundController>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	
	void OnTriggerEnter2D(Collider2D other)
	{	
		if(other.tag=="Player"){
			string level_index=sceneName;
			AnalyticsEvent.LevelComplete(level_index);
			//gameObject.SetActive(false);

			/* if (sceneName=="scene2")
			{
				theGround.contact=true;
			}*/
				
			
		/* if (PlayerPrefs.GetInt("AdsNumber")!=1)	{ //show an ad
			if(Advertisement.IsReady()){
			Advertisement.Show("rewardedVideo");
			}
		} */
			if(sceneName=="scene1"){
				if(PlayerPrefs.GetInt("lvlAvl")<2)
					PlayerPrefs.SetInt("lvlAvl",2);
				SceneManager.LoadScene("scene2");
			}

			if (sceneName=="scene2")
			{
				if(PlayerPrefs.GetInt("lvlAvl")<3)
					PlayerPrefs.SetInt("lvlAvl",3);
				SceneManager.LoadScene(thirdLevel); //load scene 3, on trigger with the player
			}
			else if (sceneName=="scene3")
			{
				if(PlayerPrefs.GetInt("lvlAvl")<4)
					PlayerPrefs.SetInt("lvlAvl",4);
				SceneManager.LoadScene(fourthLevel); //load scene 4, on trigger with the player
			}
            else if (sceneName == "scene4")
            {
				if(PlayerPrefs.GetInt("lvlAvl")<5)
					PlayerPrefs.SetInt("lvlAvl",5);
                SceneManager.LoadScene(fifthLevel);//load scene 5, on trigger with the player
            }
            else if (sceneName == "scene5")
            {
				if(PlayerPrefs.GetInt("lvlAvl")<6)
					PlayerPrefs.SetInt("lvlAvl",6);
                SceneManager.LoadScene(sixthLevel);//load scene 6
            }
            else if(sceneName== "scene6")
            {
				if(PlayerPrefs.GetInt("lvlAvl")<7)
					PlayerPrefs.SetInt("lvlAvl",7);
                SceneManager.LoadScene(seventhLevel);//load scene 7
            } 
            else if (sceneName == "scene7")
            {
				if(PlayerPrefs.GetInt("lvlAvl")<8)
					PlayerPrefs.SetInt("lvlAvl",8);
                SceneManager.LoadScene(eigthLevel);//load level 8
            }
            else if (sceneName == "scene8")
            {
				if(PlayerPrefs.GetInt("lvlAvl")<9)
					PlayerPrefs.SetInt("lvlAvl",9);
                SceneManager.LoadScene(ninethLevel);//load level 9
            } 
            else if (sceneName== "scene9" )
            {
				if(PlayerPrefs.GetInt("lvlAvl")<10)
					PlayerPrefs.SetInt("lvlAvl",10);
                SceneManager.LoadScene(tenthLevel);//load level 10
            }
			}
			 if(other.gameObject.tag=="Car"){
				finalScreen.gameObject.SetActive(true);
				pauseButton.gameObject.SetActive(false);
				
			}
		
		}
	}

