using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
//using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinScreenScontroler : MonoBehaviour {

	public LevelManager theLevelManager;
	public GameObject WinScreen;

    public Text textReward;

    public Button DoubleScoreButton;

    public GameObject targetPos;

	public GameObject amethist;
	public GameObject boss;
   
	//public FlySteamPunkController theBoss;

    public int contor=0;
   // public Animator myAnim;
    public string firstLevel;
    public string sceneName;
		public string nextLevel;
		public bool  seeAd;
        public string placementId = "rewardedVideo";



#if UNITY_ANDROID
       private string gameID = "1717631";
#elif UNITY_IOS
    private string gameID="1747036";
#endif

    // Use this for initialization
    void Start () {
     //   myAnim = GetComponent<Animator>();
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        if(sceneName=="scene3")
            boss= GameObject.Find("FlySteampunk");
        if(sceneName=="scene6")
            boss=GameObject.Find("RoboFlyHolder");
		seeAd=false;
		theLevelManager=FindObjectOfType<LevelManager>();
        WinScreen.gameObject.SetActive(false);
       // theBoss=FindObjectOfType<FlySteamPunkController>();
		if(Advertisement.isSupported){
            Advertisement.Initialize(gameID, false);
        }
	}
	
	// Update is called once per frame
	void Update () {
        /* if(sceneName=="scene3"){
            if(boss.activeInHierarchy){
                if(FindObjectOfType<FlySteamPunkController>().defeated==true){
                    WinScreen.gameObject.SetActive(true);
                    //s myAnim.Play("WinScreenGoingDown");
                    //	WinScreen.gameObject.SetActive(true);
                    theLevelManager.gameOverScreen.gameObject.SetActive(false);
                }
                if (FindObjectOfType<FlySteamPunkController>().defeated==false){
                    WinScreen.gameObject.SetActive(false);
              }
            //}
            }*/
        if(sceneName=="scene9"){
            if(contor==4){
                WinScreen.gameObject.SetActive(true);
                theLevelManager.gameOverScreen.gameObject.SetActive(false);
            }
        }
        if(sceneName=="scene6"&&seeAd==false){
            if(boss.activeInHierarchy==false){
                 WinScreen.gameObject.SetActive(true);
                theLevelManager.gameOverScreen.gameObject.SetActive(false);
            }
        }
       // Debug.Log("Contorul este: " + contor);
	
        if(WinScreen.activeInHierarchy){
            
            theLevelManager.gameOverScreen.gameObject.SetActive(false);
            WinScreen.transform.position=Vector2.MoveTowards(WinScreen.transform.position,targetPos.transform.position,500f*Time.deltaTime);
        }
    
    }
    

	public	void RestartWholeGame(){
       
		if(Advertisement.IsReady(placementId)){
            //Monetization.Show("rewardedVideo");
            //ShowAdPlacementContent ad = Monetization.GetPlacementContent(placementId) as ShowAdPlacementContent;
            //ad.Show();
            Advertisement.Show("rewardedVideo");
        }
		SceneManager.LoadScene(firstLevel);
	}
	public void DoublePoints(){
        
		if(Advertisement.IsReady(placementId)){
            //ShowAdCallbacks options = new ShowAdCallbacks();
            //options.finishCallback =  HandleShowResult;
            //Monetization.Show("rewardedVideo", options);
            //ShowAdPlacementContent ad = Monetization.GetPlacementContent (placementId) as ShowAdPlacementContent;
            //ad.Show(options);
            var doublePointsOptions = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show(placementId, doublePointsOptions);

		
		}
	}

    public void NextLevel()
    {
        
        if (Advertisement.IsReady(placementId))
        {
            //ShowAdCallbacks options = new ShowAdCallbacks();
            // options.finishCallback =  NextLevelHandleShowResult;
            //Monetization.Show("rewardedVideo", options);
            // ShowAdPlacementContent ad = Monetization.GetPlacementContent (placementId) as ShowAdPlacementContent;
            // ad.Show(options);
            var options = new ShowOptions { resultCallback = NextLevelHandleShowResult};
            Advertisement.Show(placementId, options);
        }
    }

	 private void HandleShowResult(ShowResult result)
              {
                switch (result)
                {
                  case ShowResult.Finished:
                    Debug.Log("The ad was successfully shown.");
											//amethist.gameObject.SetActive(true);
											//SceneManager.LoadScene(nextLevel);
											//FindObjectOfType<FlySteamPunkController>().defeated=false;
                                            textReward.text="You Got 200 UR for defeating the boss";
                                            DoubleScoreButton.interactable=false;
                                            PlayerPrefs.SetInt("scoreUR",PlayerPrefs.GetInt("scoreUR")+100);

                    //
                    // YOUR CODE TO REWARD THE GAMER
                    // Give coins etc.
                    break;
                  case ShowResult.Skipped:
                    Debug.Log("The ad was skipped before reaching the end.");
										//amethist.gameObject.SetActive(false);
                    break;
                  case ShowResult.Failed:
                    Debug.LogError("The ad failed to be shown.");
										//amethist.gameObject.SetActive(false);
                    break;
                }
              }

    private void NextLevelHandleShowResult(ShowResult result)
    {
        {
            switch (result)
            {
                case ShowResult.Finished:
                    Debug.Log("The ad was successfully shown.");
                    amethist.gameObject.SetActive(true);
                    if(sceneName=="scene6"){
                        seeAd=true;
                    }
                    //SceneManager.LoadScene(nextLevel);
                    WinScreen.gameObject.SetActive(false);
                    FindObjectOfType<FlySteamPunkController>().defeated = false;
                    contor++;
                    
                   

                    //
                    // YOUR CODE TO REWARD THE GAMER
                    // Give coins etc.
                    break;
                case ShowResult.Skipped:
                    Debug.Log("The ad was skipped before reaching the end.");
                    amethist.gameObject.SetActive(false);
                    break;
                case ShowResult.Failed:
                    Debug.LogError("The ad failed to be shown.");
                    amethist.gameObject.SetActive(false);
                    break;
            }
        }

    }
}
