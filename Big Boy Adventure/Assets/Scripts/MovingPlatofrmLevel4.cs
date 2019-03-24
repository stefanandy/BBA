using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatofrmLevel4 : MonoBehaviour {

	public Transform rightPoint;
	public Transform leftPoint;

	public float speed;
	public GameObject platformToMove;

	public GameObject activeRobo;
	public GameObject activeJug;

	private Vector3 currentTarget;

	// Use this for initialization
	void Start () {

	//		activeJug.gameObject.SetActive(false);
	//	activeRobo.gameObject.SetActive(false);

		currentTarget=rightPoint.position;
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
		platformToMove.transform.position=Vector3.MoveTowards(platformToMove.transform.position, currentTarget,speed*Time.deltaTime);
		
		if(platformToMove.transform.position==leftPoint.position)
				currentTarget=rightPoint.position;
		if(platformToMove.transform.position==rightPoint.position)
				currentTarget=leftPoint.position;
	}

//	void OnCollisionEnter2D(Collision2D other){
       /*     if(other.gameObject.tag=="Player"){
               // transform.parent= other.transform;
	            
			
			}  

			activeJug.gameObject.SetActive(true);
			activeRobo.gameObject.SetActive(true);
    }

    
    /*void OnCollisionExit2D(Collision2D other){
        if(other.gameObject.tag=="Player"){
            transform.parent=null;
        }
    } 

		void OnCollisionExit2D(Collision2D other)
	{
			activeJug.gameObject.SetActive(true);
			activeRobo.gameObject.SetActive(true);
	}	*/
}
