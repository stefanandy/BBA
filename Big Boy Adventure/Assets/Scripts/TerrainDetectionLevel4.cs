using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainDetectionLevel4 : MonoBehaviour {

	public GameObject robo, jug;
	public int contorBomb;


	//public GameObject explosion;
	

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


		
	}


	void OnCollisionEnter2D(Collision2D other)
	{
        if (other.gameObject.tag == "Player")
        {
            robo.gameObject.SetActive(true);
            jug.gameObject.SetActive(true);
        }
			
		
	}
}
