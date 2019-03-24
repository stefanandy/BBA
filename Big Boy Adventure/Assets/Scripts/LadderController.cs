using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LadderController : MonoBehaviour {

   
    public SwithController sController;
    public Animator myAnim;
    public string sceneName;
    public GameObject target;
	// Use this for initialization
	void Start () {

         Scene currentScene = SceneManager.GetActiveScene();
         sceneName = currentScene.name;

        myAnim = GetComponent<Animator>();
      //  ladderRb = GetComponent<Rigidbody2D>();
        sController = FindObjectOfType<SwithController>();
       // ladderRb.gravityScale = 0;
        //myAnim.Play();
	}
	
	// Update is called once per frame
	void Update () {
        if (sController.isActived == true) {
                if(sceneName!="scene7"){
                    myAnim.Play("LadderDown");
                    myAnim.SetBool("LadderGoingDown", true);
            } else{
                transform.position=Vector2.MoveTowards(transform.position,target.transform.position,3f*Time.deltaTime);
            }
        }
		
	}

    
    IEnumerator WaitForSeconds(float seconds) {
       
       yield  return new WaitForSeconds(seconds);

    }
}
