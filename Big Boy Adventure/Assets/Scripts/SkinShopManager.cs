using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoogleMobileAds.Api;

public class SkinShopManager : MonoBehaviour {
    private GoodAdMobRewardedVideo ads;
    public static bool buyTArnie;
	public static bool buyDillon;
	public static bool buyDiezel;
	public static bool buyHitman;
	public static bool buyJohsson;

	public int watchDillon;
	public int watchJohnsson;
	public GameObject skinScreen;
	public GameObject shopScreen;
	public Button arnieSelectButton;
	public Button arnieSelectedButton;
	public Button TArnieSelectButton;
	public Button TArnieSelectedButton;
	public Button TArnieBuyButton;
	public Button DillonSelectButton;
	public Button DillonSelectedButton;
	public Button DillonWatchButton;
	public Button HitmanSelectButton;
	public Button HitmanSelectedButton;
	public Button HitmanBuyButton;
	public Button DiezelSelectButton;
	public Button DiezelSelectedButton;
	public Button DiezelBuyButton;
	public Button JohnssonSelectButton;
	public Button JohnssonSelectedtButton;
	public Button JohnssonWatchButton;

	public Text dillonText;

	public Text johnssonText;

	//public Reward recompensaDillon, recompensaJohnsson;
	

	

    // Use this for initialization
    void Start () {

		
		
		
		/*Reward recompensaDillon = new Reward
		{
			Type = "skinD",
			Amount = 1
		};
		
	

		//Reward recompensaJohnsson = new Reward("skinJ",1);


		


		/*recompensaDillon.Type="skinD";
		recompensaDillon.Amount=1;
		recompensaJohnsson.Amount=1;
		recompensaJohnsson.Type="skinJ";*/

		//PlayerPrefs.SetInt("WatchDillon",0);
		//PlayerPrefs.SetInt("WatchJohnsson",0);
		
		ads=FindObjectOfType<GoodAdMobRewardedVideo>();
		buyTArnie=false;
		buyDiezel=false;
		buyHitman=false;
		buyJohsson=false;
		buyDillon=false;
		//ResetAll();
		AlreadyBuyed();
		AlreadyWatched();    
	}

	
	// Update is called once per frame
	void Update () {
		AlreadyBuyed();
		AlreadyWatched(); 
		VerifyPurchase();
		CurrentSelection();
		watchDillon=PlayerPrefs.GetInt("WatchDillon");
		watchJohnsson=PlayerPrefs.GetInt("WatchJohnsson");
		AfisareText();
	}
	public void ResetAll(){

		PlayerPrefs.SetInt("Dillon",0);
		PlayerPrefs.SetInt("Johnsson",0);
		PlayerPrefs.SetInt("Hitman",0);
		PlayerPrefs.SetInt("Diezel",0);
		PlayerPrefs.SetInt("TArnie",0);
		
	}

	public void AlreadyBuyed(){
		if(PlayerPrefs.GetInt("TArnie")==1){
				TArnieBuyButton.gameObject.SetActive(false);
				TArnieSelectButton.gameObject.SetActive(true);
		}
		if(PlayerPrefs.GetInt("Diezel")==1){
				DiezelBuyButton.gameObject.SetActive(false);
				DiezelSelectButton.gameObject.SetActive(true);
		}
		if(PlayerPrefs.GetInt("Hitman")==1){
				HitmanBuyButton.gameObject.SetActive(false);
				HitmanSelectButton.gameObject.SetActive(true);
		}
	}
	public void AlreadyWatched(){
		if(PlayerPrefs.GetInt("Dillon")==1){
			DillonWatchButton.gameObject.SetActive(false);
			DillonSelectButton.gameObject.SetActive(true);
		}
		if(PlayerPrefs.GetInt("Johnsson")==1){
			JohnssonWatchButton.gameObject.SetActive(false);
			JohnssonSelectButton.gameObject.SetActive(true);
		}
	}

	public void AfisareText(){
		dillonText.text=watchDillon.ToString() + " / 24";
		johnssonText.text=watchJohnsson.ToString()  + " / 48";
	}

	public void BuyDiezel(){
		if(PlayerPrefs.GetInt("Diezel")==1){
			DiezelBuyButton.gameObject.SetActive(false);
			DiezelSelectButton.gameObject.SetActive(true);
		} else if(PlayerPrefs.GetInt("scoreUR")>=64000){
			PlayerPrefs.SetInt("scoreUR",PlayerPrefs.GetInt("scoreUR")-64000);
			buyDiezel=true;
			DiezelBuyButton.gameObject.SetActive(false);
			DiezelSelectButton.gameObject.SetActive(true);

		} else if(PlayerPrefs.GetInt("scoreUR")<64000){
			shopScreen.gameObject.SetActive(true);
		}
	}

	public void BuyHitman(){
		if(PlayerPrefs.GetInt("Hitman")==1){
			HitmanBuyButton.gameObject.SetActive(false);
			HitmanSelectButton.gameObject.SetActive(true);
		} else if(PlayerPrefs.GetInt("scoreUR")>=27000){
			PlayerPrefs.SetInt("scoreUR",PlayerPrefs.GetInt("scoreUR")-27000);
			buyHitman=true;
			HitmanBuyButton.gameObject.SetActive(false);
			HitmanSelectButton.gameObject.SetActive(true);

		}else if(PlayerPrefs.GetInt("scoreUR")<27000){
			shopScreen.gameObject.SetActive(true);
		}
	}

	public void BuyTArnie(){
		if (PlayerPrefs.GetInt("TArnie")==1){
				//PlayerPrefs.SetInt("selectSkin",1);
				TArnieBuyButton.gameObject.SetActive(false);
				TArnieSelectButton.gameObject.SetActive(true);
			}
				
			else if (PlayerPrefs.GetInt("scoreUR") >= 11000){
					PlayerPrefs.SetInt("scoreUR",PlayerPrefs.GetInt("scoreUR") - 10000);
					buyTArnie=true;
					TArnieBuyButton.gameObject.SetActive(false);
					TArnieSelectButton.gameObject.SetActive(true);
		} else if(PlayerPrefs.GetInt("scoreUR")<11000){
			shopScreen.gameObject.SetActive(true);
		}
	}
	public void WatchDillion(){
		//Debug.Log(recompensaDillon.Type);
		ads.DillonWatch();
		                //PlayerPrefs.SetInt("WatchDillon",PlayerPrefs.GetInt("WatchDillon")+1);
		if(watchDillon==23){
			buyDillon=true;
			DillonWatchButton.gameObject.SetActive(false);
			DillonSelectButton.gameObject.SetActive(true);
		}
	}

	public void WatchJohnsson(){
		ads.JohnssonWatch();
           //    PlayerPrefs.SetInt("WatchJohnsson",PlayerPrefs.GetInt("WatchJohnsson")+1);
		if(watchJohnsson==47){
			buyJohsson=true;
			JohnssonWatchButton.gameObject.SetActive(false);
			JohnssonSelectButton.gameObject.SetActive(true);
		}
	}
	
	public void SelectTArnie(){
		TArnieSelectButton.gameObject.SetActive(false);
		TArnieSelectedButton.gameObject.SetActive(true); 
		PlayerPrefs.SetInt("selectSkin",1);
		//DisableRest(1);
	}
	public void ArnieSelect(){
			arnieSelectButton.gameObject.SetActive(false);
			arnieSelectedButton.gameObject.SetActive(true);
			PlayerPrefs.SetInt("selectSkin",0);
		//	DisableRest(0);
			
	}
	public void SelectDiezel(){
		DiezelSelectButton.gameObject.SetActive(false);
		DiezelSelectedButton.gameObject.SetActive(true);
		PlayerPrefs.SetInt("selectSkin",5);
		//DisableRest(5);

	}
	public void SelectHitman(){
		HitmanSelectButton.gameObject.SetActive(false);
		HitmanSelectedButton.gameObject.SetActive(true);
		PlayerPrefs.SetInt("selectSkin",3);
		//DisableRest(3);

	}
	public void SelectJohnsson(){
		JohnssonSelectButton.gameObject.SetActive(false);
		JohnssonSelectedtButton.gameObject.SetActive(true);
		PlayerPrefs.SetInt("selectSkin",4);
		//DisableRest(4);

	}
	public void SelectDillon(){
		DillonSelectButton.gameObject.SetActive(false);
		DillonSelectedButton.gameObject.SetActive(true);
		PlayerPrefs.SetInt("selectSkin",2);
		//DisableRest(2);
	}
	
	public void VerifyPurchase(){
		if (buyTArnie==true)
		{
			PlayerPrefs.SetInt("TArnie",1);
			TArnieBuyButton.gameObject.SetActive(false);
		} 
		if(buyDillon==true){
			PlayerPrefs.SetInt("Dillon",1);
			DillonWatchButton.gameObject.SetActive(false);
		}
		if(buyDiezel==true){
			PlayerPrefs.SetInt("Diezel",1);
			DiezelBuyButton.gameObject.SetActive(false);
		}
		if(buyHitman==true){
			HitmanBuyButton.gameObject.SetActive(false);
			PlayerPrefs.SetInt("Hitman",1);
		}
		if(buyJohsson==true){
			JohnssonWatchButton.gameObject.SetActive(false);
			PlayerPrefs.SetInt("Johnsson",1);
		}

	}

	public void CloseSkinShop(){
		skinScreen.gameObject.SetActive(false);
	}

	public void CurrentSelection(){
		switch(PlayerPrefs.GetInt("selectSkin")){
			case 5: DisableRest(5);
					DiezelSelectButton.gameObject.SetActive(false);
					DiezelSelectedButton.gameObject.SetActive(true);
					return;
			case 4: DisableRest(4);
					JohnssonSelectButton.gameObject.SetActive(false);
					JohnssonSelectedtButton.gameObject.SetActive(true);
					return;
			case 3: DisableRest(3);
					HitmanSelectButton.gameObject.SetActive(false);
					HitmanSelectedButton.gameObject.SetActive(true);
					return;
			case 2: DisableRest(2);
					DillonSelectButton.gameObject.SetActive(false);
					DillonSelectedButton.gameObject.SetActive(true);
					return;
			case 1: DisableRest(1);
					TArnieSelectButton.gameObject.SetActive(false);
					TArnieSelectedButton.gameObject.SetActive(true);
					return;
			default: DisableRest(0);
					arnieSelectButton.gameObject.SetActive(false);
					arnieSelectedButton.gameObject.SetActive(true);
					 return;

		}
	}

	public void DisableRest(int i){
		
		
		
		if(i==0){
			if(PlayerPrefs.GetInt("TArnie")==1){
				TArnieSelectedButton.gameObject.SetActive(false);
				TArnieSelectButton.gameObject.SetActive(true);
			}
			if(PlayerPrefs.GetInt("Dillon")==1){
				DillonSelectButton.gameObject.SetActive(true);
				DillonSelectedButton.gameObject.SetActive(false);
			}
			if(PlayerPrefs.GetInt("Diezel")==1){
				DiezelSelectButton.gameObject.SetActive(true);
				DiezelSelectedButton.gameObject.SetActive(false);
			}
			if(PlayerPrefs.GetInt("Hitman")==1){
				HitmanSelectButton.gameObject.SetActive(true);
				HitmanSelectedButton.gameObject.SetActive(false);
			}
			if(PlayerPrefs.GetInt("Johnsson")==1){
				JohnssonSelectButton.gameObject.SetActive(true);
				JohnssonSelectedtButton.gameObject.SetActive(false);
			}
		}
		
		
		if(i==1){
			
			arnieSelectedButton.gameObject.SetActive(false);
			arnieSelectButton.gameObject.SetActive(true);
			if(PlayerPrefs.GetInt("Dillon")==1){
				DillonSelectButton.gameObject.SetActive(true);
				DillonSelectedButton.gameObject.SetActive(false);
			}
			if(PlayerPrefs.GetInt("Diezel")==1){
				DiezelSelectButton.gameObject.SetActive(true);
				DiezelSelectedButton.gameObject.SetActive(false);
			}
			if(PlayerPrefs.GetInt("Hitman")==1){
				HitmanSelectButton.gameObject.SetActive(true);
				HitmanSelectedButton.gameObject.SetActive(false);
			}
			if(PlayerPrefs.GetInt("Johnsson")==1){
				JohnssonSelectButton.gameObject.SetActive(true);
				JohnssonSelectedtButton.gameObject.SetActive(false);
			}
		}

		if(i==2){
			if(PlayerPrefs.GetInt("TArnie")==1){
				TArnieBuyButton.gameObject.SetActive(false);
				TArnieSelectedButton.gameObject.SetActive(false);
				TArnieSelectButton.gameObject.SetActive(true);
			}
			
				arnieSelectButton.gameObject.SetActive(true);
				arnieSelectedButton.gameObject.SetActive(false);
			
			if(PlayerPrefs.GetInt("Diezel")==1){
				DiezelSelectButton.gameObject.SetActive(true);
				DiezelSelectedButton.gameObject.SetActive(false);
			}
			if(PlayerPrefs.GetInt("Hitman")==1){
				HitmanBuyButton.gameObject.SetActive(false);
				HitmanSelectButton.gameObject.SetActive(true);
				HitmanSelectedButton.gameObject.SetActive(false);
			}
			if(PlayerPrefs.GetInt("Johnsson")==1){
				JohnssonSelectButton.gameObject.SetActive(true);
				JohnssonSelectedtButton.gameObject.SetActive(false);
			}

		}
		if(i==3){
			if(PlayerPrefs.GetInt("TArnie")==1){
				TArnieSelectedButton.gameObject.SetActive(false);
				TArnieSelectButton.gameObject.SetActive(true);
			}
			if(PlayerPrefs.GetInt("Dillon")==1){
				DillonSelectButton.gameObject.SetActive(true);
				DillonSelectedButton.gameObject.SetActive(false);
			}
			if(PlayerPrefs.GetInt("Diezel")==1){
				DiezelSelectButton.gameObject.SetActive(true);
				DiezelSelectedButton.gameObject.SetActive(false);
			}
			
				arnieSelectButton.gameObject.SetActive(true);
				arnieSelectedButton.gameObject.SetActive(false);
			
			if(PlayerPrefs.GetInt("Johnsson")==1){
				JohnssonSelectButton.gameObject.SetActive(true);
				JohnssonSelectedtButton.gameObject.SetActive(false);
			}
		}
		if(i==4){
			if(PlayerPrefs.GetInt("TArnie")==1){
				TArnieSelectedButton.gameObject.SetActive(false);
				TArnieSelectButton.gameObject.SetActive(true);
			}
			if(PlayerPrefs.GetInt("Dillon")==1){
				DillonSelectButton.gameObject.SetActive(true);
				DillonSelectedButton.gameObject.SetActive(false);
			}
			if(PlayerPrefs.GetInt("Diezel")==1){
				DiezelSelectButton.gameObject.SetActive(true);
				DiezelSelectedButton.gameObject.SetActive(false);
			}
			if(PlayerPrefs.GetInt("Hitman")==1){
				HitmanSelectButton.gameObject.SetActive(true);
				HitmanSelectedButton.gameObject.SetActive(false);
			}
			
				arnieSelectButton.gameObject.SetActive(true);
				arnieSelectedButton.gameObject.SetActive(false);
			
		}
		if(i==5){
			arnieSelectedButton.gameObject.SetActive(false);
			arnieSelectButton.gameObject.SetActive(true);
			if(PlayerPrefs.GetInt("Dillon")==1){
				DillonSelectButton.gameObject.SetActive(true);
				DillonSelectedButton.gameObject.SetActive(false);
			}
			if(PlayerPrefs.GetInt("TArnie")==1){
				TArnieSelectButton.gameObject.SetActive(true);
				TArnieSelectedButton.gameObject.SetActive(false);
			}
			if(PlayerPrefs.GetInt("Hitman")==1){
				HitmanSelectButton.gameObject.SetActive(true);
				HitmanSelectedButton.gameObject.SetActive(false);
			}
			if(PlayerPrefs.GetInt("Johnsson")==1){
				JohnssonSelectButton.gameObject.SetActive(true);
				JohnssonSelectedtButton.gameObject.SetActive(false);
			}
		}
	}
}
