using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;



public class LevelManager : MonoBehaviour {

	//public Reward adsUR;
	

	public UraniumController uraniumOn;
	public Image uranium1;
	public Image uranium2;
	public Image uranium3;
	public Sprite uranium;
	public Sprite uraniumEmpty;
	public int uraniumCount;
	public AudioClip musicClip;
	public AudioSource musicSource;
	public PlayerController thePlayer;
	public bool gameOver;
	public GameObject gameOverScreen;
	public bool pause;
	public GameObject pauseScreen;
	static int adsCounter=0;
	public FlySteamPunkController theBoss;
    public RoboFlyController theBoss1;
	public string sceneName;
	public Text tutorText;
	public string mainMenuScenu;
	public string placementId="rewardedVideo";


#if UNITY_IOS
    private string gameId = "1747036";
#elif UNITY_ANDROID
       private string gameId = "1717631";
#endif

    // Use this for initialization
    void Start () {
		Scene currentScene=SceneManager.GetActiveScene();//check scene name
		sceneName=currentScene.name;
      //  if ( sceneName == "scene3" || sceneName=="scene2" )
      // {
            theBoss = FindObjectOfType<FlySteamPunkController>();
    //   }
        //else if ( sceneName == "scene6" ) {
            theBoss1 = FindObjectOfType<RoboFlyController>();
        //   }
        //adsCounter = 0;
		thePlayer=FindObjectOfType<PlayerController>();
		pause=false;
		gameOver=false;
		musicSource.clip=musicClip;
		uraniumOn=FindObjectOfType<UraniumController>();
		musicSource.Play();
		string level_index=sceneName;
		AnalyticsEvent.LevelStart(level_index);
		if(Advertisement.isSupported){
			Advertisement.Initialize(gameId,false);
		}
		
	}
	
	// Update is called once per frame
	void Update () {

		/*if(Monetization.isSupported){
			Monetization.Initialize(gameId,false);
		}*/
	/*	 if(uraniumCount==3){
			Debug.Log("Maicata");
			tutorText.text="Now you can pass safely";
			//tutorText.gameObject.SetActive(true);
			tutorText.fontSize=30;
			tutorText.color=Color.white;
			
			StartCoroutine(Example());
			tutorText.text="";
			Debug.Log("	Maicata dupa");
		}
		if(uraniumCount>3){
			tutorText.text="Don't be greedy";
			 uraniumCount=0;
			 StartCoroutine(Example());
			 tutorText.text="";

		} */

		if (gameOver==true)
		{
			pause=false;
		}


		if(pause==true){
			Time.timeScale=0f;
			pauseScreen.gameObject.SetActive(true);
		}
		if(pause==false){
			Time.timeScale=1f;
			pauseScreen.gameObject.SetActive(false);
		}
		

		GameOver();
		
		
			UraniumUpdater();
		
		
		
		
	}

	IEnumerator ShowMessage (string message, float delay) {
     tutorText.text = message;
     tutorText.enabled = true;
     yield return new WaitForSeconds(delay);
     tutorText.enabled = false;
 }

	public void UraniumToAdd(int uraniumToAdd){ //function to add the uranium
		uraniumCount+=uraniumToAdd;
		/*if (uraniumCount==3&&sceneName=="scene2"){

			StartCoroutine(ShowMessage("Now you can pass safely",2f));
		}*/
		if(uraniumCount>3){
			uraniumCount=0;
			/*if (sceneName=="scene2")
			{
				StartCoroutine(ShowMessage("Don't be greedy",2f));
			}*/
			
		
	}
	}


	void UraniumUpdater(){ //update the uranium pictures up in the left corner

		switch (uraniumCount)
		{
			case 1:
					uranium1.sprite=uranium;
					uranium2.sprite=uraniumEmpty;
					uranium3.sprite=uraniumEmpty;
					return;
			case 2: 
					uranium1.sprite=uranium;
					uranium2.sprite=uranium;
					uranium3.sprite=uraniumEmpty;
					return;
			case 3:
					uranium1.sprite=uranium;
					uranium2.sprite=uranium;
					uranium3.sprite=uranium;
					return;

			default:
				uranium1.sprite=uraniumEmpty;
				uranium2.sprite=uraniumEmpty;
				uranium3.sprite=uraniumEmpty;
				return;
		}


	}
	void GameOver(){

		if (gameOver==true){

			gameOverScreen.gameObject.SetActive(true);			
		}
		
		if (sceneName!="scene1"&&sceneName!="scene6")
		{
		
			if(sceneName=="scene3" || sceneName=="scene9"){
				if(theBoss.defeated==true){
					gameOverScreen.gameObject.SetActive(false);
				}
			}
		}
        if (sceneName == "scene6" && theBoss1.defetead==true)
        {
            
                gameOverScreen.gameObject.SetActive(false);
				
            
        }
		
		

	}

	public void RestartGame(){
		
		if(adsCounter%5==0){  //show ads when dying , every 6 deads
			ShowAd();
			thePlayer.moveLeft=false;
			thePlayer.moveRight=false;
			thePlayer.action=false;
			thePlayer.jump=false;
			thePlayer.startFire=false;
		}
		adsCounter++;
			SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
	}
	public void PauseActived(){
		pause=true; //active pause
	}
	public void PuaseNotActived(){
		pause=false; //deactive pause
	}
	public void Restart(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().name); // reload the current scene
	}
	public void MainMenu(){
		SceneManager.LoadScene(mainMenuScenu);
	}

	
	 public void ShowAd() // function to show unity ads
    {

		if (PlayerPrefs.GetInt("AdsNumber")!=1){
			
			if (Advertisement.IsReady(placementId)){ //check if ads ready
                                                     //ShowAdPlacementContent ad = Monetization.GetPlacementContent(placementId) as  ShowAdPlacementContent; // show rewared video that can't be skipabble 
                                                     //ad.Show();
                Advertisement.Show(placementId);
				}
    }
	}
}
