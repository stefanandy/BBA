using System;
using UnityEngine;
using GoogleMobileAds.Api;
public class GoogleAdMobBanner : MonoBehaviour {

	// Use this for initialization
 private BannerView bannerView;
    
    public void Start()
    {
       
        RequestBanner();
        
        if(PlayerPrefs.GetInt("AdsNumber")!=1){
            bannerView.Destroy();
        }
        
    }

    private void RequestBanner()
    {
      
            string adUnitId = "ca-app-pub-7846390904610930/5205848311";

        //custom ad size
         AdSize adSize = new AdSize(250, 25);
        // Create a 320x50 banner at the top of the screen. AdSize.Banner for a 320x50 ad, i change that with my adSize;
        bannerView = new BannerView(adUnitId, adSize, AdPosition.Bottom);
        
		 //***For Testing in the Device***
       // AdRequest request = new AdRequest.Builder()
       //.AddTestDevice(AdRequest.TestDeviceSimulator)       // Simulator.
       //.AddTestDevice("2077ef9a63d2b398840261c8221a0c9b")  // My test device.
       //.Build();
        // Called when an ad request has successfully loaded.
        bannerView.OnAdLoaded += HandleOnAdLoaded;
        // Called when an ad request failed to load.
        bannerView.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        // Called when an ad is clicked.
        bannerView.OnAdOpening += HandleOnAdOpened;
        // Called when the user returned from the app after an ad click.
        bannerView.OnAdClosed += HandleOnAdClosed;
        // Called when the ad click caused the user to leave the application.
        bannerView.OnAdLeavingApplication += HandleOnAdLeavingApplication;
        //***For Production When Submit App***
        AdRequest request = new AdRequest.Builder().Build();

        
		

        // Load the banner with the request.
        bannerView.LoadAd(request);
    }
    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLoaded event received");
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print("HandleFailedToReceiveAd event received with message: "
                            + args.Message);
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received");
        PlayerPrefs.SetInt("scoreUR",PlayerPrefs.GetInt("scoreUR")+10);
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLeftApplication event received");
    }
}