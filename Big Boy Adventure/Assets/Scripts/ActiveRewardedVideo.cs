using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveRewardedVideo : MonoBehaviour {

	// Use this for initialization

	public GameObject rewardedVideoObj;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void VideoRewards(){
		rewardedVideoObj.gameObject.SetActive(true);
		StartCoroutine(WaitForSeconds(33f));
		rewardedVideoObj.gameObject.SetActive(true);
	}
	IEnumerator WaitForSeconds(float wait){
		yield return new WaitForSeconds(wait);
		
	}
}
