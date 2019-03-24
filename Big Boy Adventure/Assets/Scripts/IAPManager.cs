using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using UnityEngine.Purchasing;
//using UnityEngine.Monetization;
using UnityEngine.Purchasing;

// Placing the Purchaser class in the CompleteProject namespace allows it to interact with ScoreManager, 
// one of the existing Survival Shooter scripts.

    // Deriving the Purchaser class from IStoreListener enables it to receive messages from Unity Purchasing.
public class IAPManager : MonoBehaviour, IStoreListener
{

	

	public static IAPManager Instance {set;get;}
	private static IStoreController m_StoreController;          // The Unity Purchasing system.
	private static IExtensionProvider m_StoreExtensionProvider; // The store-specific Purchasing subsystems.
	
	// Product identifiers for all products capable of being purchased: 
	// "convenience" general identifiers for use with Purchasing, and their store-specific identifier 
	// counterparts for use with and outside of Unity Purchasing. Define store-specific identifiers 
	// also on each platform's publisher dashboard (iTunes Connect, Google Play Developer Console, etc.)

	// General product identifiers for the consumable, non-consumable, and subscription products.
	// Use these handles in the code to reference which product to purchase. Also use these values 
	// when defining the Product Identifiers on the store. Except, for illustration purposes, the 
	// kProductIDSubscription - it has custom Apple and Google identifiers. We declare their store-
	// specific mapping to Unity Purchasing's AddProduct, below.
	public MainMenuManager menuManager;
    public string sceneName;
	//public static Text text10k;
	//public static Text text25k;
	//public static Text text60k;
	//public static Text text125k;
	public static string uranium10k =    "buy_10k_uranium";   
	public static string uranium25k =  	 "buy_25k_uranium";
	public static string uranium60k = 	 "buy_60k_uranium";
	public static string uranium150k =	  "buy_150k_uranium";
	public static string RemoveAds = "remove_ads";
	#if UNITY_ANDROID
		public static string MoreLevels =  "buy_more_levels";
	#elif UNITY_IOS
		public static string MoreLevels = "unlock_levels";
	#endif
	//public static string MoreLevels;
	public static string subscirption="something something";
		
	// Apple App Store-specific product identifier for the subscription product.
	private static string kProductNameAppleSubscription =  "com.unity3d.subscription.new";
	
	// Google Play Store-specific product identifier subscription product.
	private static string kProductNameGooglePlaySubscription =  "com.unity3d.subscription.original"; 
	
	 private void Awake()
	{
		Instance=this;
		//MoreLevels=buy_more_levels;
	}
	private void Start()
	{
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        // If we haven't set up the Unity Purchasing reference
        if (m_StoreController == null)
		{
			// Begin to configure our connection to Purchasing
			InitializePurchasing();
		}
		menuManager=FindObjectOfType<MainMenuManager>();
	}

    void Update()
    {
        /*	if (m_StoreController != null)
            {
            text10k = GameObject.Find ("10kText").GetComponent<Text>();
            text25k = GameObject.Find ("25kText").GetComponent<Text>();
            text60k = GameObject.Find ("60kText").GetComponent<Text>();
            text125k = GameObject.Find ("125kText").GetComponent<Text>(); */

        if (sceneName == "MainMenuScene")
        {
            if (menuManager.text10k.gameObject.activeInHierarchy)
                menuManager.text10k.text = m_StoreController.products.WithID("buy_10k_uranium").metadata.localizedPrice.ToString();
            if (menuManager.text25k.gameObject.activeInHierarchy)
                menuManager.text25k.text = m_StoreController.products.WithID("buy_25k_uranium").metadata.localizedPrice.ToString();
            if (menuManager.text60k.gameObject.activeInHierarchy)
                menuManager.text60k.text = m_StoreController.products.WithID("buy_60k_uranium").metadata.localizedPrice.ToString();
            if (menuManager.text150k.gameObject.activeInHierarchy)
                menuManager.text150k.text = m_StoreController.products.WithID("buy_150k_uranium").metadata.localizedPrice.ToString();
            //}
        }
    }
	
	public void InitializePurchasing() 
	{
		// If we have already connected to Purchasing ...
		if (IsInitialized())
		{
			// ... we are done here.
			return;
		}
		
		// Create a builder, first passing in a suite of Unity provided stores.
		var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
		
		// Add a product to sell / restore by way of its identifier, associating the general identifier
		// with its store-specific identifiers.
		builder.AddProduct(uranium10k, ProductType.Consumable);
		builder.AddProduct(uranium25k, ProductType.Consumable);
		builder.AddProduct(uranium60k, ProductType.Consumable);
		builder.AddProduct(uranium150k, ProductType.Consumable);
		// Continue adding the non-consumable product.
		builder.AddProduct(RemoveAds, ProductType.NonConsumable);
		builder.AddProduct(MoreLevels, ProductType.NonConsumable);
		// And finish adding the subscription product. Notice this uses store-specific IDs, illustrating
		// if the Product ID was configured differently between Apple and Google stores. Also note that
		// one uses the general kProductIDSubscription handle inside the game - the store-specific IDs 
		// must only be referenced here. 
		builder.AddProduct(subscirption, ProductType.NonConsumable, new IDs(){
			{ kProductNameAppleSubscription, AppleAppStore.Name },
			{ kProductNameGooglePlaySubscription, GooglePlay.Name },
		});
		
		// Kick off the remainder of the set-up with an asynchrounous call, passing the configuration 
		// and this class' instance. Expect a response either in OnInitialized or OnInitializeFailed.
		UnityPurchasing.Initialize(this, builder);
	}
	
	
	private bool IsInitialized()
	{
		// Only say we are initialized if both the Purchasing references are set.
		return m_StoreController != null && m_StoreExtensionProvider != null;
	}
	
	
	public void BuyUranium()
	{
		// Buy the consumable product using its general identifier. Expect a response either 
		// through ProcessPurchase or OnPurchaseFailed asynchronously.
		BuyProductID(uranium10k);
	}

	public void BuyUranium25k()
	{
		BuyProductID(uranium25k);
	}

	public void BuyUranium60k()
	{
		BuyProductID(uranium60k);
	}

	public void BuyUranium150k()
	{
		BuyProductID(uranium150k);
	}
	
	
	public void BuyRemoveAds()
	{
		// Buy the non-consumable product using its general identifier. Expect a response either 
		// through ProcessPurchase or OnPurchaseFailed asynchronously.
		BuyProductID(RemoveAds);
	}
	
	
	public void BuyMoreLevels()
	{
		// Buy the subscription product using its the general identifier. Expect a response either 
		// through ProcessPurchase or OnPurchaseFailed asynchronously.
		// Notice how we use the general product identifier in spite of this ID being mapped to
		// custom store-specific identifiers above.
		BuyProductID(MoreLevels);
	}
	
	
	void BuyProductID(string productId)
	{
		// If Purchasing has been initialized ...
		if (IsInitialized())
		{
			// ... look up the Product reference with the general product identifier and the Purchasing 
			// system's products collection.
			Product product = m_StoreController.products.WithID(productId);
			
			// If the look up found a product for this device's store and that product is ready to be sold ... 
			if (product != null && product.availableToPurchase)
			{
				Debug.Log(string.Format("Purchasing product asychronously: '{0}'", product.definition.id));
				// ... buy the product. Expect a response either through ProcessPurchase or OnPurchaseFailed 
				// asynchronously.
				m_StoreController.InitiatePurchase(product);
			}
			// Otherwise ...
			else
			{
				// ... report the product look-up failure situation  
				Debug.Log("BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");
			}
		}
		// Otherwise ...
		else
		{
			// ... report the fact Purchasing has not succeeded initializing yet. Consider waiting longer or 
			// retrying initiailization.
			Debug.Log("BuyProductID FAIL. Not initialized.");
		}
	}
	
	
	// Restore purchases previously made by this customer. Some platforms automatically restore purchases, like Google. 
	// Apple currently requires explicit purchase restoration for IAP, conditionally displaying a password prompt.
	public void RestorePurchases()
	{
		// If Purchasing has not yet been set up ...
		if (!IsInitialized())
		{
			// ... report the situation and stop restoring. Consider either waiting longer, or retrying initialization.
			Debug.Log("RestorePurchases FAIL. Not initialized.");
			return;
		}
		
		// If we are running on an Apple device ... 
		if (Application.platform == RuntimePlatform.IPhonePlayer || 
			Application.platform == RuntimePlatform.OSXPlayer)
		{
			// ... begin restoring purchases
			Debug.Log("RestorePurchases started ...");
			
			// Fetch the Apple store-specific subsystem.
			var apple = m_StoreExtensionProvider.GetExtension<IAppleExtensions>();
			// Begin the asynchronous process of restoring purchases. Expect a confirmation response in 
			// the Action<bool> below, and ProcessPurchase if there are previously purchased products to restore.
			apple.RestoreTransactions((result) => {
				// The first phase of restoration. If no more responses are received on ProcessPurchase then 
				// no purchases are available to be restored.
				Debug.Log("RestorePurchases continuing: " + result + ". If no further messages, no purchases available to restore.");
			});
		}
		// Otherwise ...
		else
		{
			// We are not running on an Apple device. No work is necessary to restore purchases.
			Debug.Log("RestorePurchases FAIL. Not supported on this platform. Current = " + Application.platform);
		}
	}
	
	
	//  
	// --- IStoreListener
	//
	
	public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
	{
		// Purchasing has succeeded initializing. Collect our Purchasing references.
		Debug.Log("OnInitialized: PASS");

		/*text10k = GameObject.Find ("10kText").GetComponent<Text>();
		text25k = GameObject.Find ("25kText").GetComponent<Text>();
		text60k = GameObject.Find ("60kText").GetComponent<Text>();
		text125k = GameObject.Find ("125kText").GetComponent<Text>();
		
		text10k.text = m_StoreController.products.WithID("buy_10k_uranium").metadata.localizedPrice.ToString();
		text25k.text = m_StoreController.products.WithID("buy_25k_uranium").metadata.localizedPrice.ToString();
		text60k.text = m_StoreController.products.WithID("buy_60k_uranium").metadata.localizedPrice.ToString();
		text125k.text = m_StoreController.products.WithID("buy_125k_uranium").metadata.localizedPrice.ToString();*/


		// Overall Purchasing system, configured with products for this application.
		m_StoreController = controller;
		// Store specific subsystem, for accessing device-specific store features.
		m_StoreExtensionProvider = extensions;
	}
	
	
	public void OnInitializeFailed(InitializationFailureReason error)
	{
		// Purchasing set-up has not succeeded. Check error for reason. Consider sharing this reason with the user.
		Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
	}
	
	
	public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args) 
	{
		// A consumable product has been purchased by this user.
		if (String.Equals(args.purchasedProduct.definition.id, uranium10k, StringComparison.Ordinal))
		{
			Debug.Log("Buyed uranium");
			PlayerPrefs.SetInt("scoreUR",PlayerPrefs.GetInt("scoreUR")+10000);
			//PlayerPrefs.SetInt("scoreUR",0);
		}
		else if (String.Equals(args.purchasedProduct.definition.id, uranium25k, StringComparison.Ordinal))
		{
			PlayerPrefs.SetInt("scoreUR", PlayerPrefs.GetInt("scoreUR")+25000);
		}
		else if (String.Equals(args.purchasedProduct.definition.id, uranium60k, StringComparison.Ordinal))
		{
			PlayerPrefs.SetInt("scoreUR",PlayerPrefs.GetInt("scoreUR")+60000);
		}
		else if (String.Equals(args.purchasedProduct.definition.id, uranium150k, StringComparison.Ordinal))
		{
			PlayerPrefs.SetInt("scoreUR", PlayerPrefs.GetInt("scoreUR")+150000);
		}
		// Or ... a non-consumable product has been purchased by this user.
		else if (String.Equals(args.purchasedProduct.definition.id, RemoveAds, StringComparison.Ordinal))
		{
			Debug.Log("You removed the ads");
			PlayerPrefs.SetInt("AdsNumber",1);
		}
		// Or ... a subscription product has been purchased by this user.
		else if (String.Equals(args.purchasedProduct.definition.id, MoreLevels, StringComparison.Ordinal))
		{
			Debug.Log("You buyed more levels");
			PlayerPrefs.SetInt("lvlAvl",10);
		}
		// Or ... an unknown product has been purchased by this user. Fill in additional products here....
		else 
		{
			Debug.Log(string.Format("ProcessPurchase: FAIL. Unrecognized product: '{0}'", args.purchasedProduct.definition.id));
		}

		// Return a flag indicating whether this product has completely been received, or if the application needs 
		// to be reminded of this purchase at next app launch. Use PurchaseProcessingResult.Pending when still 
		// saving purchased products to the cloud, and when that save is delayed. 
		return PurchaseProcessingResult.Complete;
	}
	
	
	public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
	{
		// A product purchase attempt did not succeed. Check failureReason for more detail. Consider sharing 
		// this reason with the user to guide their troubleshooting actions.
		Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}", product.definition.storeSpecificId, failureReason));
	}
}
