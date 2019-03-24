using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RingBlastController : MonoBehaviour {

	//public Animator animController;
	//public SpriteRenderer spriteRender;
	public GameObject uranium;
	public Transform uraniumSpawn;
	// Use this for initialization
	public string sceneName;
	void Start () {
		Scene currentScene=SceneManager.GetActiveScene();
		sceneName=currentScene.name;
		if(sceneName=="scene4"||sceneName=="scene6"){
			transform.localScale=new Vector3(2.5f,2.5f,2.5f);
		}	
		//animController=GetComponent<Animator>();
		//spriteRender=GetComponent<SpriteRensderer>();
		Destroy(gameObject,0.8f);
		//Instantiate(uranium,uraniumSpawn.position,uraniumSpawn.rotation);
		
	}
	
	// Update is called once per frame
	void Update () {

		//animController["RingBlastExplosion"].wrapMode=WrapMode.Once;
		//animController.Play("RingBlastExplosion");
		//animController.StopPlayback();
		//Destroy(gameObject,1f);
		/*AnimatorStateInfo asi = animController.GetCurrentAnimatorStateInfo(0);
 
         if (!asi.IsName("RingBlastController") || asi.normalizedTime >= 1)
         {
             Destroy(gameObject);
         }*/
	}
}
