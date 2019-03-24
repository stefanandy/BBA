using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;
using UnityEngine.UI;

public class GoodAdMobRewardedVideo : MonoBehaviour {


    public Text adsTimer;
	public float msToWait=300.0f;
    private ulong lastAd;
    public Button free_ur_button;
    
	private RewardBasedVideoAd rewardBasedVideo;
   // public SkinShopManager skinShopManager;
    
            

	// Use this for initialization
	void Start () {
	   
         //skinShopManager=FindObjectOfType<SkinShopManager>();       
		// Get singleton reward based video ad reference.

       
        this.rewardBasedVideo = RewardBasedVideoAd.Instance;

        this.RequestRewardBasedVideo();
        // Called when an ad request has successfully loaded.
        rewardBasedVideo.OnAdLoaded += HandleRewardBasedVideoLoaded;
        // Called when an ad request failed to load.
        rewardBasedVideo.OnAdFailedToLoad += HandleRewardBasedVideoFailedToLoad;
        // Called when an ad is shown.
        rewardBasedVideo.OnAdOpening += HandleRewardBasedVideoOpened;
        // Called when the ad starts to play.
        rewardBasedVideo.OnAdStarted += HandleRewardBasedVideoStarted;
        // Called when the user should be rewarded for watching a video.
        rewardBasedVideo.OnAdRewarded += HandleRewardBasedVideoRewarded;
        // Called when the ad is closed.
        rewardBasedVideo.OnAdClosed += HandleRewardBasedVideoClosed;
        // Called when the ad click caused the user to leave the application.
        rewardBasedVideo.OnAdLeavingApplication += HandleRewardBasedVideoLeftApplication;

        this.RequestRewardBasedVideo();
         if(IsAdsReady()==false){
            free_ur_button.interactable=false;
        }
         lastAd=ulong.Parse(PlayerPrefs.GetString("LastAd","0"));
	}

    private void Update()
    {

        //Debug.Log(lastAd);
       // Debug.Log(IsAdsReady());
        if(free_ur_button.IsInteractable()==false){
            if(IsAdsReady()==true){
                free_ur_button.interactable=true;
                //Debug.Log("Am intrat in bucla");
                return;
            }else{
        
            ulong diff=((ulong)DateTime.Now.Ticks - lastAd);
            ulong m=diff/TimeSpan.TicksPerMillisecond;
            float secondsLeft=(float)(msToWait - m)/1000;
            string r="";
            //hours
            r+=((int)secondsLeft/3600).ToString()+"h";
            secondsLeft-=((int)secondsLeft/3600)*3600;
            //minutes
            r+=((int)secondsLeft/60).ToString("00")+"m";
            //second
            r+=(secondsLeft%60).ToString("00")+"s";
            adsTimer.text=r;
            }
        }
    }
	
	private void RequestRewardBasedVideo()
    {
        #if UNITY_ANDROID
            string adUnitId = "ca-app-pub-7846390904610930/2146175011";
        #elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-7846390904610930/2766166318";
        #else
            string adUnitId = "unexpected_platform";
        #endif
        
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded video ad with the request.
        this.rewardBasedVideo.LoadAd(request, adUnitId);
    }



	 public void HandleRewardBasedVideoLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoLoaded event received");
        //this.rewardBasedVideo.Show();
    }

    public void HandleRewardBasedVideoFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardBasedVideoFailedToLoad event received with message: "+ args.Message);


    }

    public void HandleRewardBasedVideoOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoOpened event received");
    }

    public void HandleRewardBasedVideoStarted(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoStarted event received");
    }

    public void HandleRewardBasedVideoClosed(object sender, EventArgs args)
    {
       // MonoBehaviour.print("HandleRewardBasedVideoClosed event received");
	   this.RequestRewardBasedVideo();
    }

    public void HandleRewardBasedVideoRewarded(object sender, Reward args)
    {
        
        string type = args.Type;
        double amount = args.Amount;
        //SceneManager.LoadScene(arcadeMode);

       // MonoBehaviour.print(
         //   "HandleRewardBasedVideoRewarded event received for "+ amount.ToString() + " " + type);
           
           
           if(type=="skinD"){
                PlayerPrefs.SetInt("WatchDillon",PlayerPrefs.GetInt("WatchDillon")+1);
           } else if(type=="skinJ"){
               PlayerPrefs.SetInt("WatchJohnsson",PlayerPrefs.GetInt("WatchJohnsson")+1);
           }else if(type=="freeUR"){
               PlayerPrefs.SetInt("scoreUR",PlayerPrefs.GetInt("scoreUR")+100);}
    }

    public void HandleRewardBasedVideoLeftApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoLeftApplication event received");
    }

	/*public void PlayArcade(){
			if(rewardBasedVideo.IsLoaded()) {
					rewardBasedVideo.Show();
                    
			}
            //SceneManager.LoadScene(arcadeMode);
	}

    public void PlayAdventure(){
            /*if (rewardBasedVideo.IsLoaded()){
                    rewardBasedVideo.Show();
                    
            }
            SceneManager.LoadScene(adventureMode); 


} */
 Reward adsUR= new Reward()
	{
		Type="freeUR",
		Amount = 1
	};

    public void FreeUr(){
        
        free_ur_button.interactable=false;

        if(rewardBasedVideo.IsLoaded()){
                rewardBasedVideo.Show();
                lastAd=(ulong)DateTime.Now.Ticks;
                PlayerPrefs.SetString("LastAd",lastAd.ToString());
                HandleRewardBasedVideoRewarded(rewardBasedVideo,adsUR);
                
                
        }
        

    }

    private bool IsAdsReady(){
            ulong diff=((ulong)DateTime.Now.Ticks - lastAd);
            ulong m=diff/TimeSpan.TicksPerMillisecond;

            float secondsLeft=(float)(msToWait - m)/1000.0f;
            if(secondsLeft<0f){
                    free_ur_button.interactable=true;
                    adsTimer.text="";
                    return true;
            } else {    return false;   }
    } 

    
    
    	Reward recompensaDillon = new Reward
		{
			Type = "skinD",
			Amount = 1
		};

		Reward recompensaJohnsson = new Reward
		{
			Type = "skinJ",
			Amount = 1
		};
        public void DillonWatch(){
                 if(rewardBasedVideo.IsLoaded()){
                    rewardBasedVideo.Show();
                    HandleRewardBasedVideoRewarded(rewardBasedVideo,recompensaDillon);
                } 
         }
        public void JohnssonWatch(){
                 if(rewardBasedVideo.IsLoaded()){
                    rewardBasedVideo.Show(); 
                    HandleRewardBasedVideoRewarded(rewardBasedVideo,recompensaJohnsson);
                
            }
        }
	
	
}
