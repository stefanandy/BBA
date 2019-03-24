using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;
//using UnityEngine.Advertisements;
//using GooglePlayGames;
public class NewLevelManager : MonoBehaviour {


	public GameObject alphaImage;

	public Text scoreText;
	public Text uraniumText;
	
	public Text GameOverScore;
	public float scoreCount;
	public int scoreInt;

	public int uraniumCounter;

	public NewPlayerController thePlayer;

	public GameObject gameOverScreen;

	public GameObject freeLifeButton;

	public GameObject doublePointsButton;
	static bool freeLifeConsumed;
	public bool doublePointsConsumed;

	public string mainMenu;

	public GameObject pauseScreen;

	public AudioClip musicClip;
	public AudioSource musicSource;
	public static int urCounterOnRestart;
//	private Vector2 nextPos;

	public string placementId="rewardedVideo";

	#if UNITY_IOS
   private string gameId = "1747036";
 #elif UNITY_ANDROID
   private string gameId = "1717631";
#endif

	// Use this for initialization
	void Start () {
		//Time.timeScale=1.0f;
		Time.timeScale=0f;
		doublePointsConsumed=false;
		freeLifeConsumed=false;
		thePlayer=FindObjectOfType<NewPlayerController>();
		musicSource.clip=musicClip;
		musicSource.Play();
		if(Advertisement.isSupported){
			Advertisement.Initialize(gameId,false);
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
		/*if(Monetization.isSupported){
			Monetization.Initialize(gameId,false);
		}*/
		
		
		//nextPos=thePlayer.transform.position;
		ScoreManagement();
		GameOverScreen();
	

	}

	public void UraniumToAdd(int uraniumToAdd){
		uraniumCounter+=uraniumToAdd;
		/*if (uraniumCounter==10){
			UnlockedAchivement(BBAIds1.achievement_start_collecting);
		}*/
		urCounterOnRestart+=uraniumCounter;
	}
	void ScoreManagement(){
			if (thePlayer.isDead==false){

			scoreCount+=thePlayer.moveSpeed*Time.deltaTime;
			scoreInt=Mathf.RoundToInt(scoreCount); //transform the score from float to int
		}
		if (scoreInt<=9)
		
			scoreText.text="000"+scoreInt.ToString(); //the score from left up corner
		
		if(scoreInt>9&&scoreInt<=99)
			scoreText.text="00"+scoreInt.ToString();
		
		if (scoreInt>100&&scoreInt<=999)
		
			scoreText.text="0"+scoreInt.ToString();
		if(scoreInt>999)
			scoreText.text=scoreInt.ToString();
		
		if (uraniumCounter<=9)
		
			uraniumText.text="000"+uraniumCounter.ToString();
		
		if (uraniumCounter>9&&uraniumCounter<=99)
		
			uraniumText.text="00"+uraniumCounter.ToString();
		
		if (uraniumCounter>99&&uraniumCounter<=999)
		
			uraniumText.text="0"+uraniumCounter.ToString();
		
		//scoreText.text=scoreInt.ToString();
		
	
	}
	public void OkButton(){
		alphaImage.gameObject.SetActive(false);
		Time.timeScale=1.0f;
	}


	public void Pause(){

		Time.timeScale=0f; // pause the game time, if it is Time.timeScale=1f the time game come back to normal.
		pauseScreen.gameObject.SetActive(true);
		gameOverScreen.gameObject.SetActive(false);
	}
	public void NoPause(){
		Time.timeScale=1f;
		pauseScreen.gameObject.SetActive(false);
	}
	void GameOverScreen(){
		//pauseScreen.gameObject.SetActive(false);
		if(thePlayer.isDead==true&&thePlayer.invincible==false){
			//ReportScore(uraniumCounter);
			gameOverScreen.SetActive(true);
			pauseScreen.gameObject.SetActive(false);
			GameOverScore.text="Score: " + uraniumCounter.ToString();
			
		}
		if (thePlayer.isDead==false)
		{
			gameOverScreen.SetActive(false);
		}
	}

	public void RestartGame(){
        //ShowAd();
		Time.timeScale=1f;
		//urCounterOnRestart+=uraniumCounter;
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);//load current scene

	}

	public void MainMenu(){

		SceneManager.LoadScene(mainMenu);
		PlayerPrefs.SetInt("scoreUR",PlayerPrefs.GetInt("scoreUR")+urCounterOnRestart);
		urCounterOnRestart=0;
	}

	public void DoublePoints(){ //douuble points you already have if you watch an ad
		
		//Monetization.IsReady(placementId);
		if(Advertisement.IsReady(placementId)){

            //ShowAdCallbacks pointsOption= new ShowAdCallbacks();
            var pointsOptions = new ShowOptions { resultCallback = HandleShowResultDoublePoints };
            Advertisement.Show(placementId, pointsOptions);
            //pointsOption.finishCallback	= HandleShowResultDoublePoints;
            //ShowAdPlacementContent ad = Monetization.GetPlacementContent (placementId) as ShowAdPlacementContent;
            //ad.Show(pointsOption);
            if (doublePointsConsumed==true){
				doublePointsButton.SetActive(false);
			}

		}
	}
	public void PaidLife(){
		if (PlayerPrefs.GetInt("scoreUR")>=1000)
		{
			thePlayer.isDead=false;
			thePlayer.invincible=true;
			PlayerPrefs.SetInt("scoreUR",PlayerPrefs.GetInt("scoreUR")-1000);
			thePlayer.gameObject.SetActive(true);
			thePlayer.transform.position= new Vector2(thePlayer.transform.position.x+5f,thePlayer.transform.position.y);
			
		}
	}

	public void FreeLife(){ 
		
		if (Advertisement.IsReady(placementId))
		{
            //ShowAdCallbacks options = new ShowAdCallbacks();
            var options = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show(placementId, options);
            //ShowAdPlacementContent ad = Monetization.GetPlacementContent(placementId) as ShowAdPlacementContent;
            //ad.Show(options);
            if (freeLifeConsumed==true){
				freeLifeButton.SetActive(false);
			}


		}
	}

	public void ShowAd(){ //show ads function
		//Monetization.IsReady(placementId);
		if (UnityEngine.Advertisements.Advertisement.IsReady(placementId))
		{
            //ShowAdPlacementContent ad =Monetization.GetPlacementContent(placementId) as ShowAdPlacementContent;
            //ad.Show();
            UnityEngine.Advertisements.Advertisement.Show(placementId);
			
		}
	}
	 private void HandleShowResult(ShowResult result)
              {
                switch (result)
                {
                  case ShowResult.Finished:
                    Debug.Log("The ad was successfully shown.");
					thePlayer.isDead=false;
					thePlayer.invincible=true;
					freeLifeConsumed=true;
					thePlayer.gameObject.SetActive(true);
					thePlayer.transform.position= new Vector2(thePlayer.transform.position.x+5f,thePlayer.transform.position.y); //revie player and set him forward a few meters so he would not die again.
					
					//Instantiate(thePlayer,thePlayer.transform.position,thePlayer.transform.rotation);
                    //
                    // YOUR CODE TO REWARD THE GAMER
                    // Give coins etc.
                    break;
                  case ShowResult.Skipped:
                    Debug.Log("The ad was skipped before reaching the end.");
					thePlayer.isDead=true;
                    break;
                  case ShowResult.Failed:
                    Debug.LogError("The ad failed to be shown.");
					thePlayer.isDead=true;
                    break;
                }
              }
		IEnumerator InvincibleTime(float a){
			yield return new WaitForSeconds(a);
	}

	private void HandleShowResultDoublePoints(ShowResult result){

		switch (result)
		{
			case ShowResult.Finished:
				uraniumCounter=uraniumCounter*2;
				urCounterOnRestart+=uraniumCounter-(uraniumCounter/2)-1;
				//PlayerPrefs.SetInt("scoreUR",PlayerPrefs.GetInt("scoreUR")+uraniumCounter);
				doublePointsConsumed=true;
				doublePointsButton.SetActive(false);
			break;
			case ShowResult.Skipped:
				doublePointsConsumed=false;
//				uraniumCounter=uraniumCounter;
			break;
			case ShowResult.Failed:
//				uraniumCounter=uraniumCounter;
				doublePointsConsumed=false;
			break;
		}

	}


	/*public void OnAchivementClick(){
		if (Social.localUser.authenticated)
		{
			Social.ShowAchievementsUI(); //show the achivements UI
		}
	}


	public void UnlockedAchivement(string achievementID){

		Social.ReportProgress(achievementID,100.0f,(bool success)=> // put 100.0f to unclock the achivement , pt 10.0f for example to gain 10% closer to unlock the achivement, you need to put 100f when you have non progressive achivements.
		{
			Debug.Log("Achivement unclocked" + success.ToString()); // unlock achivement 
		});

		


	}*/
//report scorte
   /*	public void ReportScore(int score){
		Social.ReportScore(score,BBAIds1.leaderboard_score,(bool success)=>{ //report score to leaderbords
			Debug.Log("Reported score to leaderbord" + success.ToString());
		});
	}*/







}

	

