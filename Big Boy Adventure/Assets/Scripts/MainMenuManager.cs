using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using UnityEngine.Purchasing;
using GoogleMobileAds.Api;

public class MainMenuManager : MonoBehaviour {


	

	public GoodAdMobRewardedVideo ads;

	public AudioClip musicClip;
	public AudioSource musicSource;

	public string adventureMode;
	public string arcadeMode;
	public GameObject modeSelectScreen;
	public GameObject freeURScreen;

	public GameObject shopScreen;
	public GameObject shopMoneyScreen;
	public Text urScore;
    public Text urScore2;
	public Text urScore3;

	public Text text10k;
	public Text text25k;
	public Text text60k;
	public Text text150k;

	

	//private static IStoreController m_StoreController; 

	// Use this for initialization
	void Start () {
		ads=FindObjectOfType<GoodAdMobRewardedVideo>();
		//Advertisement.Initialized("1717631");

		/*/if (m_StoreController==null)
		{
			IsInitialized();
		} */
		musicSource.clip=musicClip;
	}
	
	// Update is called once per frame
	void Update () {
        //int score = PlayerPrefs.GetInt("scoreUR");
        //Debug.Log("Scorul este: " + score);
      //  urScore.text= PlayerPrefs.GetInt("scoreUR").ToString();
	   if(PlayerPrefs.GetInt("scoreUR")==0)

                urScore.text = "0000";
        if (PlayerPrefs.GetInt("scoreUR")<10&&PlayerPrefs.GetInt("scoreUR")>0)
				urScore.text="000"+PlayerPrefs.GetInt("scoreUR").ToString();

		if(PlayerPrefs.GetInt("scoreUR")<100&&PlayerPrefs.GetInt("scoreUR")>9)
				urScore.text="00"+PlayerPrefs.GetInt("scoreUR").ToString();

		if(PlayerPrefs.GetInt("scoreUR")<1000&&PlayerPrefs.GetInt("scoreUR")>99)
				urScore.text="0"+PlayerPrefs.GetInt("scoreUR").ToString();

		if(PlayerPrefs.GetInt("scoreUR")<10000&&PlayerPrefs.GetInt("scoreUR")>999)
				urScore.text=PlayerPrefs.GetInt("scoreUR").ToString();
        else if (PlayerPrefs.GetInt("scoreUR") >= 10000)
        
            urScore.text = PlayerPrefs.GetInt("scoreUR").ToString();
        

        if (shopMoneyScreen.activeInHierarchy == true)
        {
			 if(PlayerPrefs.GetInt("scoreUR")==0)

                urScore2.text = "0000";

            if(PlayerPrefs.GetInt("scoreUR") < 10 && PlayerPrefs.GetInt("scoreUR") > 0)

                urScore2.text = "000" + PlayerPrefs.GetInt("scoreUR").ToString();

            if (PlayerPrefs.GetInt("scoreUR") < 100 && PlayerPrefs.GetInt("scoreUR") > 9)
                urScore2.text = "00" + PlayerPrefs.GetInt("scoreUR").ToString();

            if (PlayerPrefs.GetInt("scoreUR") < 1000 && PlayerPrefs.GetInt("scoreUR") > 99)
                urScore2.text = "0" + PlayerPrefs.GetInt("scoreUR").ToString();

            if (PlayerPrefs.GetInt("scoreUR") < 10000 && PlayerPrefs.GetInt("scoreUR") > 999)
                urScore2.text = PlayerPrefs.GetInt("scoreUR").ToString();
            else if (PlayerPrefs.GetInt("scoreUR") >= 10000)
                urScore2.text = PlayerPrefs.GetInt("scoreUR").ToString();
        }

		if(shopScreen.activeInHierarchy==true){
			 if(PlayerPrefs.GetInt("scoreUR")==0)

                urScore3.text = "0000";
			 if(PlayerPrefs.GetInt("scoreUR") < 10 && PlayerPrefs.GetInt("scoreUR") > 0)

                urScore3.text = "000" + PlayerPrefs.GetInt("scoreUR").ToString();

            if (PlayerPrefs.GetInt("scoreUR") < 100 && PlayerPrefs.GetInt("scoreUR") > 9)
                urScore3.text = "00" + PlayerPrefs.GetInt("scoreUR").ToString();

            if (PlayerPrefs.GetInt("scoreUR") < 1000 && PlayerPrefs.GetInt("scoreUR") > 99)
                urScore3.text = "0" + PlayerPrefs.GetInt("scoreUR").ToString();

            if (PlayerPrefs.GetInt("scoreUR") < 10000 && PlayerPrefs.GetInt("scoreUR") > 999)
                urScore3.text = PlayerPrefs.GetInt("scoreUR").ToString();
            else if (PlayerPrefs.GetInt("scoreUR") >= 10000)
                urScore3.text = PlayerPrefs.GetInt("scoreUR").ToString();
		}
		//urScore.text = PlayerPrefs.GetInt("scoreUR").ToString(); // UR updater in the left up corner
		
		/*if (m_StoreController != null)
		{
			text10k.text = m_StoreController.products.WithID("buy_10k_uranium").metadata.localizedPrice.ToString();
			text25k.text = m_StoreController.products.WithID("buy_25k_uranium").metadata.localizedPrice.ToString();
			text60k.text = m_StoreController.products.WithID("buy_60k_uranium").metadata.localizedPrice.ToString();
			text125k.text = m_StoreController.products.WithID("buy_125k_uranium").metadata.localizedPrice.ToString();
			Debug.Log("am fost aici");
		} */
		
	
	}
/*	private bool IsInitialized()
    {
            // Only say we are initialized if both the Purchasing references are set.
            return m_StoreController != null ;
    } */

	
	public void CloseShop(){
		shopScreen.gameObject.SetActive(false); // deactive the shop window
	}
	public void CloseShopMoney(){
		shopMoneyScreen.gameObject.SetActive(false);
	}
	public void OpenShop(){
		shopScreen.gameObject.SetActive(true);//active the  shop windows 
	}
	public void OpenShopMoney(){
		shopMoneyScreen.gameObject.SetActive(true);
	}

	public void CloseScreen(){
		modeSelectScreen.gameObject.SetActive(false);//deactive the mode select screen
	}

	public void ModeSelect(){
		modeSelectScreen.gameObject.SetActive(true); //active the modeselct screen 
	}

	public void AdventureMode(){
		
		if (Advertisement.IsReady()){
			Advertisement.Show();
		}
		SceneManager.LoadScene(adventureMode);// load adventre mode (scene1)
	}

	public void ArcadeMode(){
		if (Advertisement.IsReady()){
			Advertisement.Show();
		}
		SceneManager.LoadScene(arcadeMode);//load arcade mode (ArcadeModeScene)
	}

	public void CloseFreeUr(){
		freeURScreen.gameObject.SetActive(false);
	}

	public void FreeUR(){
		if (Advertisement.IsReady())
		{
			var options = new ShowOptions { resultCallback = HandleShowResult };
			Advertisement.Show("rewardedVideo",options);
		}
		Debug.Log(Advertisement.IsReady());
	}
	private void HandleShowResult(ShowResult result)
              {
                switch (result)
                {
                  case ShowResult.Finished:
                    Debug.Log("The ad was successfully shown.");
					freeURScreen.gameObject.SetActive(true);
					PlayerPrefs.SetInt("scoreUR",PlayerPrefs.GetInt("scoreUR")+20);
                    //
                    // YOUR CODE TO REWARD THE GAMER
                    // Give coins etc.
                    break;
                  case ShowResult.Skipped:
                    Debug.Log("The ad was skipped before reaching the end.");
					freeURScreen.gameObject.SetActive(false);
                    break;
                  case ShowResult.Failed:
                    Debug.LogError("The ad failed to be shown.");
					freeURScreen.gameObject.SetActive(false);
                    break;
                }
              }

}
