using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class ScoreController : MonoBehaviour {

	public Text scoreText;
	public Text scoreFinalText;
	public GameObject finalScreen;
	public GameObject doubleScoreButton;
	public int score;
	public string placementId = "rewardedVideo";

	
#if UNITY_ANDROID
       private string gameID = "1717631";
#elif UNITY_IOS
    private string gameID="1747036";
#endif


	// Use this for initialization
	void Start () {
		score=0;
		if(Advertisement.isSupported){
            Advertisement.Initialize(gameID, false);
        }
	}
	
	// Update is called once per frame
	void Update () {
		if(score==0)
		scoreText.text="0000";
		else if(score<10)
		scoreText.text="000"+ score.ToString();
		else if(score<100&&score>=10)
		scoreText.text="00"+score.ToString();
		else if(score<1000&&score>=100)
		scoreText.text="0"+score.ToString();
	
		if(finalScreen.activeInHierarchy){
			scoreFinalText.text=score.ToString();
		}
	
	}
	public void closeScreen(){
		SceneManager.LoadScene("MainMenuScene");
	}

	public void DoubleScore(){
		if(Advertisement.IsReady(placementId)){
            
            var doublePointsOptions = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show(placementId, doublePointsOptions);
	}
	}

	  private void HandleShowResult(ShowResult result)
    {
        {
            switch (result)
            {
                case ShowResult.Finished:
                    score=score*2;
					doubleScoreButton.gameObject.SetActive(true);
					PlayerPrefs.SetInt("scoreUR",PlayerPrefs.GetInt("scoreUR")+score);
                    
                   

                    //
                    // YOUR CODE TO REWARD THE GAMER
                    // Give coins etc.
                    break;
                case ShowResult.Skipped:
                    Debug.Log("The ad was skipped before reaching the end.");
                   
                    break;
                case ShowResult.Failed:
                    Debug.LogError("The ad failed to be shown.");
                    
                    break;
            }
        }

    }
}
