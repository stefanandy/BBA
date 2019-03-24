using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAPButtons : MonoBehaviour {

	
	public static bool buyTArnie;


	// Use this for initialization
	void Start () {
		buyTArnie=false;
	}
	
	// Update is called once per frame
	void Update () {
		VerifyPurchase();
//		Debug.Log(PlayerPrefs.GetInt("selectSkin"));
	}

	public void RemoveAds(){
		//IAP.BuyRemoveAds();
		//IAP.Instance.BuyRemoveAds();
		IAPManager.Instance.BuyRemoveAds();// IAP  buy remove ads
	}

	public void MoreLelves(){
		IAPManager.Instance.BuyMoreLevels(); // IAP buy more leves
	}
	public void Buy10kUranium(){
		IAPManager.Instance.BuyUranium(); //IAP buy more uranium
	}
	public void Buy25kUranium(){
		IAPManager.Instance.BuyUranium25k();
	}
	public void Buy60kUranium(){
		IAPManager.Instance.BuyUranium60k();
	}
	public void Buy150kUranium(){
		IAPManager.Instance.BuyUranium150k();
	}


	public void BuyTArnie(){
		if (PlayerPrefs.GetInt("TArnie")==1){
				PlayerPrefs.SetInt("selectSkin",1);
			}
				
		else if (PlayerPrefs.GetInt("scoreUR") >= 10000){
					PlayerPrefs.SetInt("scoreUR",PlayerPrefs.GetInt("scoreUR") - 10000);
					buyTArnie=true;
		}
	}
	public void Arnie(){
			PlayerPrefs.SetInt("selectSkin",0);
	}
	public void VerifyPurchase(){
		if (buyTArnie==true)
		{
			PlayerPrefs.SetInt("TArnie",1);
		}
	}
}
