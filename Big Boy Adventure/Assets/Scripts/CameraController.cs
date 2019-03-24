using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour {


		[SerializeField]
		public float xMax;
		[SerializeField]
		public float yMax;
		[SerializeField]
		public float xMin;
		[SerializeField]
		public float yMin;
	public GameObject target;
	public float followAhead;

	private Vector3 targetPosition;
	public float smoothing;

	public string sceneName;

	// Use this for initialization
	void Start () {

		Scene currentScene=SceneManager.GetActiveScene();
		sceneName=currentScene.name;
		
	}
	
	// Update is called once per frame
	void Update () {

		if(sceneName!="scene4" || sceneName!="scene5"){

				targetPosition=new Vector3(target.transform.position.x,transform.position.y,transform.position.z); //get the target position, in this case is the player

				if (target.transform.localScale.x>0f){ //update based on x 
					
					targetPosition=new Vector3(targetPosition.x+followAhead, targetPosition.y,
												targetPosition.z);
				} else if(target.transform.localScale.x<0f){
					targetPosition= new Vector3(targetPosition.x-followAhead, targetPosition.y,
												targetPosition.z);
				} else if(target.transform.localScale.y<0f){
					targetPosition= new Vector3(targetPosition.x,targetPosition.y-followAhead,
												targetPosition.z);
				} else if(target.transform.localScale.y>0f)
					targetPosition = new Vector3(targetPosition.x,targetPosition.y+followAhead,
												targetPosition.z);
				transform.position=Vector3.Lerp(transform.position, targetPosition,smoothing*Time.deltaTime);
				
		
		}

	}

	
	void LateUpdate()
	{
		if(sceneName=="scene4" || sceneName=="scene5" || sceneName=="scene7" || sceneName=="scene8" || sceneName=="scene9"  )

			transform.position = new Vector3(Mathf.Clamp(target.transform.position.x,xMin,xMax),Mathf.Clamp(target.transform.position.y,yMin,yMax), transform.position.z);

	}
	
	
}
