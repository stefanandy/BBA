using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

	public GameObject thePlatform;
	public Transform generationPoint;
	public float distanceBetween;

	private float platformWidth;
	public float distanceBetweenMin;
	public float distanceBetweenMax;

	public ObjectPOOLER theObjectPool;

	private int platformSelector;
	private float[] platofrmWidths;

	public ObjectPOOLER[] theObjectPools;

	// Use this for initialization
	void Start () {

		platofrmWidths=new float[theObjectPools.Length];
		for(int i=0; i<theObjectPools.Length; i++){

			platofrmWidths[i]=theObjectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;

		}
		//theObjectPool=FindObjectOfType<ObjectPOOLER>();
		//platformWidth=thePlatform.GetComponent<BoxCollider2D>().size.x;
		
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.x<generationPoint.position.x){

			distanceBetween=Random.Range(distanceBetweenMin,distanceBetweenMax);
			platformSelector=Random.Range(0,theObjectPools.Length);
			transform.position=new Vector3(transform.position.x+platofrmWidths[platformSelector]+distanceBetween,transform.position.y,0f);
			//Instantiate(thePlatform,transform.position,transform.rotation);

			GameObject newPlatform = theObjectPools[platformSelector].GetPooledObject();

			newPlatform.transform.position=transform.position;
			newPlatform.transform.rotation=transform.rotation;
			newPlatform.SetActive(true);
			if (newPlatform.transform.childCount==8)
			{
				if (transform.Find("JungHead"))
				{
					//newPlatform.transform.GetChild(8).gameObject.SetActive(true); 
					transform.Find("JungHead").gameObject.SetActive(true);
				}
				//newPlatform.transform.GetChild(8).gameObject.SetActive(true); 
				
			}
			if (newPlatform.transform.childCount==4)
			{
				if (transform.Find("JungHead"))
				{
					//newPlatform.transform.GetChild(8).gameObject.SetActive(true); 
					transform.Find("JungHead").gameObject.SetActive(true);
				}
				//newPlatform.transform.GetChild(4).gameObject.SetActive(true);
				
			}
			if (newPlatform.transform.childCount==6)
			{
				if (transform.Find("JungHead"))
				{
					//newPlatform.transform.GetChild(8).gameObject.SetActive(true); 
					transform.Find("JungHead").gameObject.SetActive(true);
				}
				//newPlatform.transform.GetChild(6).gameObject.SetActive(true); 
				
			}
			if (newPlatform.transform.childCount==10)
			{
				if (transform.Find("JungHead"))
				{
					//newPlatform.transform.GetChild(8).gameObject.SetActive(true); 
					transform.Find("JungHead").gameObject.SetActive(true);
				}
				//newPlatform.transform.GetChild(10).gameObject.SetActive(true); 
				
			}
			//newPlatform.transform.GetChild(8).gameObject.SetActive(true); 
			transform.position=new Vector3(transform.position.x+platofrmWidths[platformSelector],transform.position.y,0f);

		}
	}
}
