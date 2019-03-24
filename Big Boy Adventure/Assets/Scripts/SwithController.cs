using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SwithController : MonoBehaviour {

	public Sprite switchOff;
	public Sprite switchOn;
	public Text switchText;
	public GameObject platform;
	public Transform startPoint;
	public Transform endPoint;
	public float platformSpeed;
	private Vector3 currentTarget;
	private SpriteRenderer theSprieRenderer;
	public bool isActived;
	private bool takeAction;
	public PlayerController thePlayer;
    public string sceneName;
    public bool ladderNow;
    public bool activeShooting;
    public LevelManager theLevelManager;
    public GameObject lavaHolder;

	// Use this for initialization
	void Start () {
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        theLevelManager = FindObjectOfType<LevelManager>();
        thePlayer =FindObjectOfType<PlayerController>();
        if(sceneName=="scene9"){
            lavaHolder.gameObject.SetActive(false);
        }
       // lavaHolder.gameObject.SetActive(false);
        activeShooting = false;
		takeAction=false;
		isActived=false;
        ladderNow = false;
		theSprieRenderer=GetComponent<SpriteRenderer>();
		
	}
	
	// Update is called once per frame
	void Update () {
		if(thePlayer.action==true){
				takeAction=true;
	    }


        if (ladderNow == true && takeAction == true) {
                theSprieRenderer.sprite = switchOn;
                isActived = true;

        }

        if(theLevelManager.uraniumCount<3){
            activeShooting=false;
        }

        if(activeShooting == true && takeAction == true)
        {
            theLevelManager.uraniumCount = 0;
            theSprieRenderer.sprite = switchOn;
            StartCoroutine(WaitForS(3000));
            theSprieRenderer.sprite = switchOff;

        }

        if(sceneName=="scene9"&&isActived==true){
          //  StartCoroutine(WaitForS(500000));
           // lavaHolder.gameObject.SetActive(true);
            //theSprieRenderer.sprite = switchOn;
            StartCoroutine(WaitForS(5));
            isActived=false;
            takeAction=false;
            //theSprieRenderer.sprite = switchOff;
            //lavaHolder.gameObject.SetActive(false);
        }


	}

    IEnumerator WaitForS(float seconds)
    {
        if(sceneName=="scene9")
            lavaHolder.gameObject.SetActive(true);
        theSprieRenderer.sprite = switchOn;
        yield return new WaitForSecondsRealtime(seconds);
        theSprieRenderer.sprite = switchOff;
        if(sceneName=="scene9")
            lavaHolder.gameObject.SetActive(false);
    }

	
	
	

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.tag=="Player"&& (sceneName=="scene1"||sceneName=="scene9")){
			
			//switchText.text="Press 'E' to lower the platform ";

			if (takeAction==true){		
		/*		if (Input.GetButton("Action")){	
				theSprieRenderer.sprite=switchOn;
				//switchOff=switchOn;
				//switchAnim.Play("SwithOnOff");
				MovePlatform();
				platform.transform.position=Vector3.MoveTowards(platform.transform.position, currentTarget, 
																platformSpeed*Time.deltaTime);
				
				Debug.Log("E is preeseed");
			//} * */
				theSprieRenderer.sprite=switchOn;
				 isActived=true;
		} else{
			isActived=false;
		}
	  }else {isActived=false;}

      if(other.gameObject.tag=="Player"&&sceneName=="scene6"&&thePlayer.action==true&&theLevelManager.uraniumCount==3){
          activeShooting=true;
      }

	}
	

	void OnTriggerExit2D(Collider2D other){
        if (sceneName == "scene1")
        {
            switchText.text = "";
        }
        if (other.gameObject.tag == "Player" && sceneName == "scene6")
        {
            activeShooting = false;

        }
        if(other.gameObject.tag=="Player"&&sceneName=="scene9"){
            activeShooting=false;
        }
	}
     void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && (sceneName == "scene5"||sceneName=="scene7")) {

            ladderNow = true;

        }
        if(other.gameObject.tag=="Player" && sceneName=="scene6" && theLevelManager.uraniumCount==3&&thePlayer.action==true)
        {
            theLevelManager.uraniumCount=0;
            activeShooting = true;

        }
        if(other.gameObject.tag=="Player"&&sceneName=="scene9"&&thePlayer.action==true){
            activeShooting=true;
        }
    }

    // void MovePlatform(){
    //	if (platform.transform.position==endPoint.position){
    //		currentTarget=startPoint.position;
    //	}
    //	if (platform.transform.position==startPoint.position){
    //		currentTarget=endPoint.position;			
    //	}
    //}
}
