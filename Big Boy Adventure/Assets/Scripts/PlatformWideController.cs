using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformWideController : MonoBehaviour {

	// Use this for initialization
	 public Transform farEnd;
 	private Vector3 frometh;
 	private Vector3 untoeth;
 	[SerializeField]
	 private float secondsForOneLength = 2f;  
	void Start () {
		 frometh = transform.position;
 		 untoeth = farEnd.position;
	}
	
	// Update is called once per frame
	void Update () {
		 transform.position = Vector3.Lerp(frometh, untoeth,Mathf.SmoothStep(0f,1f,Mathf.PingPong(Time.time/secondsForOneLength, 1f)));
		}
}
