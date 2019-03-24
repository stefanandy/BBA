using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour {


	public Rigidbody2D myRigidbody;
	public float moveSpeed;
	public float jumpSpeed;
	private Animator myAnim;
	public bool isGrounded;
	public LayerMask whatIsGround;
	public float groundCheckRadius;
	public Transform groundCheck;
	public float fireRate;
	private float nextFire;
    private float nextFire1;

	public GameObject shotRight;
	public GameObject shotLeft;
	public Transform shotSpawn;
	public bool isShooting;
	public bool isRight;
	public bool isJumping;
	public bool isMoving;
	public bool isDying;
	public LevelManager theLevelManager;
	public bool jump;
	public bool startFire;
	public bool action;
	public bool moveRight;
	public bool moveLeft;
    public bool climbLadder;
    public JungHeadController theJung;
    public Text tutorText;
    public Image arrowImage;
    public string sceneName;
	private SpriteRenderer theSpriteRenderer;
	public Sprite arnie;
	public Sprite tArnie;
    public Sprite Dillon;
    public Sprite Hitman;
    public Sprite Johnson;
    public Sprite Diesel;
    public GameObject rightButtons;


    void Awake(){
        rightButtons=GameObject.Find("Canvas/RightButtonHolder");
    }

    // Use this for initialization
    void Start () {
        
	    Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        theJung = FindObjectOfType<JungHeadController>();
		theSpriteRenderer=GetComponent<SpriteRenderer>();
		moveLeft=false;
		moveRight=false;
		action=false;
		startFire=false;
		isDying=false;
		isMoving=false;
		isJumping=false;
		isShooting=false;
        climbLadder = false;
		myRigidbody=GetComponent<Rigidbody2D>();
		myAnim=GetComponent<Animator>();
		theLevelManager=FindObjectOfType<LevelManager>();
		SkinSelector();
        
	
	
	}
		
	
	// Update is called once per frame

	
	void Update()
	{
        if(sceneName=="scene9"){
            startFire=false;
        }
	/* 	if(sceneName=="scene1"){
                 SeeJung();
		}*/
           
           
           /*  if (startFire==true && sceneName == "scene1")
            {
                arrowImage.gameObject.SetActive(false);
                tutorText.text = "";
            }*/

        /*if(Mathf.Abs(myRigidbody.velocity.x)==0&isGrounded==true){
			myAnim.Play("IdleAnimation");
		}

		if(Mathf.Abs(myRigidbody.velocity.x)==0&&startFire==true){
			myAnim.Play("IdleFireAnimation");
		} */

        if (myRigidbody.velocity.x == 0 && climbLadder == false && myRigidbody.velocity.y == 0 && isShooting==false &&isMoving==false)
        {
            IdleAnimationSelector();
        }
		
        if (climbLadder == true && action == true)
        {
            // transform.Translate(new Vector2(0, 0.5f) * Time.deltaTime * (moveSpeed + 3f));
            //myRigidbody.gravityScale = 0;
            transform.Translate(new Vector2(0, 0.5f) * Time.deltaTime * (moveSpeed+10f));
            myRigidbody.gravityScale = 0;
            //myAnim.SetBool("isClimbing", true);
            ClimbingLadderSelector();
        }
        else {
            myRigidbody.gravityScale = 1;
        }

    }
	void FixedUpdate () {

		isGrounded=Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
		
		MovingController();
		JumpingController();
		//FireBullets();
		Fire();
        if (Mathf.Abs(myRigidbody.velocity.x) > 0f && startFire == true)
        {
            WalkAndFireAnimationSelector();
            FireBulletsRight();
        }
        if (Mathf.Abs(myRigidbody.velocity.x) > 0f && startFire == false && isMoving == true)
        {
            WalkingAnimationSelector();
            FireBulletsLeft();
        }
        JumpAndFireController();
                    
      /*  if (climbLadder == true && action==true)
        {
            transform.Translate(new Vector2(0, 0.5f) * Time.deltaTime * (moveSpeed+3f));
            myRigidbody.gravityScale = 0;
            myAnim.SetBool("isClimbing", true);
            ClimbingLadderSelector();
        }
        else {
            myRigidbody.gravityScale = 1;
        } */ 
		 

		//myAnim.SetFloat("Speed", Mathf.Abs(myRigidbody.velocity.x));
		//myAnim.SetBool("isGrounded", isGrounded);
		//myAnim.SetBool("Shooting", isShooting);

		Dead();
		
	}

	void SkinSelector(){
        if (PlayerPrefs.GetInt("selectSkin") == 0){
            theSpriteRenderer.sprite = arnie;
            }
        else if (PlayerPrefs.GetInt("selectSkin") == 1){
            theSpriteRenderer.sprite = tArnie;
            }
        else if (PlayerPrefs.GetInt("selectSkin") == 2){
            theSpriteRenderer.sprite = Dillon;
            }
        else if (PlayerPrefs.GetInt("selectSkin") == 3){
            theSpriteRenderer.sprite = Hitman;
            }
        else if (PlayerPrefs.GetInt("selectSkin") == 4){
            theSpriteRenderer.sprite = Johnson;
            }
        else if (PlayerPrefs.GetInt("selectSkin") == 5){
            theSpriteRenderer.sprite = Diesel;
            }
        }
    void ClimbingLadderSelector() {

        switch (PlayerPrefs.GetInt("selectSkin")) {

            case 5:
                myAnim.Play("ClimbingLadder5");
                return;
            case 4:
                myAnim.Play("ClimbingLadder4");
                return;
            case 3:
                myAnim.Play("ClimbingLadder3");
                return;
            case 2:
                myAnim.Play("ClimbingLadder2");
                return;

            case 1:
                myAnim.Play("ClimbingLadder1");
                return;

            default:
                myAnim.Play("ClimbingLadder");
                //myAnim.Update(deltaTime:10);

                return;

        }
    }

	void WalkAndFireAnimationSelector(){
		switch (PlayerPrefs.GetInt("selectSkin"))
		{
            case 5:
                    myAnim.Play("WalkAndFire5");
                    return;
            case 4:
                    myAnim.Play("WalkAndFire4");
                    return;
            case 3:
                    myAnim.Play("WalkAndFire3");
                    return;
            case 2:
                   myAnim.Play("WalkAndFire2");
                   return;
            case 1:
					myAnim.Play("WalkAndFire1");
					return;
			default: 
					myAnim.Play("WalkAndFire");
					return;

		}
	}

	void WalkingAnimationSelector(){
		switch(PlayerPrefs.GetInt("selectSkin"))
		{
            case 5:
                    myAnim.Play("WalkingAnimation5");
                    return;
            case 4:
                    myAnim.Play("WalkingAnimation4");
                    return;
            case 3:
                    myAnim.Play("WalkingAnimation3");
                    return;
            case 2:
                    myAnim.Play("WalkingAnimation2");
                    return;
            case 1:
					myAnim.Play("WalkingAnimation1");
					return;
			default:
					myAnim.Play("WalkingAnimation");
					return;
		}

	}

	void JumpFireSelector(){
		switch (PlayerPrefs.GetInt("selectSkin"))
		{
            case 5:
                    myAnim.Play("JumpFire5");
                    return;
            case 4:
                    myAnim.Play("JumpFire4");
                    return;
            case 3:
                    myAnim.Play("JumpFire3");
                    return;
            case 2:
                    myAnim.Play("JumpFire2");
                    return;
            case 1:
					myAnim.Play("JumpFire1");
					return;
			default:
					myAnim.Play("JumpFire");
					return;
		}
	}

	void IdleFireAnimationSelector(){
		switch (PlayerPrefs.GetInt("selectSkin"))
		{
            case 5: myAnim.Play("IdleFireAnimation5");
                    return;
            case 4: myAnim.Play("IdleFireAnimation4");
                    return;
            case 3: myAnim.Play("IdleFireAnimation3");
                    return;
            case 2: myAnim.Play("IdleFireAnimation2");
                    return;
            case 1:
					myAnim.Play("IdleFireAnimation1");
					return;
			default:
					myAnim.Play("IdleFireAnimation");
					return;
		}
	}

	void IdleAnimationSelector(){
		switch (PlayerPrefs.GetInt("selectSkin"))
		{
            case 5: myAnim.Play("IdleAnimation5");
                    return;
            case 4: myAnim.Play("IdleAnimation4");
                    return;
            case 3: myAnim.Play("IdleAnimation3");
                    return;
            case 2: myAnim.Play("IdleAnimation2");
                    return;
			case 1:
					myAnim.Play("IdleAnimation1");
					return;
			default:
					myAnim.Play("IdleAnimation");
					return;
		}
	}

    void JumpingAnimationSelector()
    {
        switch(PlayerPrefs.GetInt("selectSkin"))

        {
            case 5: myAnim.Play("JumpingAnimation5");
                    return;
            case 4: myAnim.Play("JumpingAnimation4");
                    return;
            case 3: myAnim.Play("JumpingAnimation3");
                    return;
            case 2: myAnim.Play("JumpingAnimation2");
                    return;
			case 1: myAnim.Play("JumpingAnimation1");
                    return;
            default:
					myAnim.Play("JumpingAnimation");
                    return;
        }
    }

	

	void MovingController(){

		
		
		//if(CrossPlatformInputManager.GetAxisRaw("Horizontal")>0f){
		if(moveRight==true){
		myRigidbody.velocity=new Vector3(moveSpeed,myRigidbody.velocity.y,0f);
		transform.localScale = new Vector3(1f, 1f, 1f);
		//myAnim.Play(WalkingAnimation,0,-1);
		//myAnim.Play("WalkingAnimation");

		isMoving=true;
		isRight=true;
		FireBulletsRight();
		}
		//if(CrossPlatformInputManager.GetAxisRaw("Horizontal")<0f){
			if(moveLeft==true){
			myRigidbody.velocity=new Vector3(-moveSpeed,myRigidbody.velocity.y,0f);
			transform.localScale = new Vector3(-1f, 1f, 1f);
			//myAnim.Play("WalkingAnimation");
			isMoving=true;
			isRight=false;
			FireBulletsLeft();
		}

		//if(CrossPlatformInputManager.GetAxisRaw("Horizontal")==0f){
			if(moveRight==false&&moveLeft==false){
			myRigidbody.velocity=new Vector3(0f,myRigidbody.velocity.y,0f);
			isMoving=false;
			//if(!Input.GetButtonDown("Jump") || !Input.GetButtonDown("Fire1")){
			//myAnim.Play("IdleAnimation");
			//}
		}
		
	}

	void JumpingController(){
		if (jump==true&& isGrounded){

            myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, jumpSpeed, 0f);     
			//myAnim.Play("JumpingAnimation");
			isJumping=true;
            JumpingAnimationSelector();



        } else{
			isJumping=false;
			
		}
	
	}
    void JumpAndFireController(){
        if (/*isJumping==true*/ isGrounded == false && startFire == true) {
            
         if (startFire == true && Time.time > nextFire1){
                nextFire1 = Time.time + fireRate;
                //Debug.Log("AM INTRAT IN BUCLA");
            if (isRight == true)
            {       
               // if (isGrounded == false)
                     //{
                        Instantiate(shotRight, shotSpawn.position, shotSpawn.rotation);
                        JumpFireSelector();                   
                    //}
            }else {
                //if (isGrounded == false){                
                    Instantiate(shotLeft, shotSpawn.position, shotSpawn.rotation);}
                    JumpFireSelector();
                    //}
            }
        }
    }

	void Fire(){
		if(startFire==true && Time.time>nextFire){
			nextFire=Time.time+fireRate;
				if(isRight){
                   if (isGrounded == true) { 
                        Instantiate(shotRight,shotSpawn.position,shotSpawn.rotation);
                        IdleFireAnimationSelector(); }
					
				}
				else{
                    if (isGrounded == true){
                        Instantiate(shotLeft, shotSpawn.position, shotSpawn.rotation);
                        IdleFireAnimationSelector();}
					}
				isShooting=true;
			
		}
			if(startFire==false){
					isShooting=false;
					//myAnim.StopPlayback("IdleFireAnimation");
					//myAnim.enabled=false;
		} 
		//if(isJumping==false&&isShooting==false&&isMoving==false) {
		//	IdleAnimationSelector();
		//}
	}

	void FireBulletsRight(){
		if(startFire==true && Time.time>nextFire){
		nextFire=Time.time+fireRate;
		Instantiate(shotRight,shotSpawn.position,shotSpawn.rotation);
		isShooting=true;
		
		}
		if(startFire==false){
			isShooting=false;
		}


	}

	void FireBulletsLeft(){

		if(startFire==true && Time.time>nextFire){
		nextFire=Time.time+fireRate;
		Instantiate(shotLeft,shotSpawn.position,shotSpawn.rotation);
		isShooting=true;
		
		}
		if(startFire==false){
			isShooting=false;
		}

	}

   /*  void SeeJung() {
        float distance = 0f;
        if (theJung != null)
        {
            distance = Mathf.Abs(transform.position.x - theJung.transform.position.x);
           /*  if (distance < 10)
            {
                // tutorText.transform.position = new Vector2();
                arrowImage.gameObject.SetActive(true);
                tutorText.text = "Press to fire";
                tutorText.fontSize = 55;

            }
        }
   }*/


	public void JumpActive(){
		jump=true;
	}

	public void JumpNotActive(){
		jump=false;
	}

	public void FireActive(){
		startFire=true;
        /* if (sceneName == "scene1")
        {
            arrowImage.gameObject.SetActive(false);
            tutorText.text = "";
        }*/
   
        
	}

	public void FireNotActive(){
		startFire=false;
	}

	public void ActionActived(){
		action=true;
	}
	public void ActionNotActived(){
		action=false;
	}
	public void MoveRightActive(){
		moveRight=true;
	}
	public void MoveRightNotActive(){
		moveRight=false;
	}
	public void MoveLeftActived(){
		moveLeft=true;
	}
	public void MoveLeftNotActive(){
		moveLeft=false;
	}

	void Dead(){
		if(isDying==true){
			gameObject.SetActive(false);
			theLevelManager.gameOver=true;
		}
	}
	
	 void OnCollisionEnter2D(Collision2D other){
            if(other.gameObject.tag=="MovingPlatform"){
                transform.parent= other.transform;
            }
            if(other.gameObject.tag=="Platform"){
                transform.parent=other.transform;
            }
            if(other.gameObject.tag=="Spike"){
                isDying=true;
            }
            if(other.gameObject.tag=="Car"){
               // other.transform.parent=gameObject.transform;
                gameObject.transform.parent=other.transform;
                gameObject.transform.position=other.transform.position;
               // other.transform.position=gameObject.transform.position;
                FindObjectOfType<CameraController>().target=other.gameObject;
                FindObjectOfType<CameraController>().followAhead=-8;
                
                rightButtons.gameObject.SetActive(false);
            }
    }

    
    
    void OnCollisionExit2D(Collision2D other){
        if(other.gameObject.tag=="MovingPlatform"){
            transform.parent=null;
        }
        if(transform.parent!=null)
            transform.parent=null;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ladder") {

            climbLadder = true;    

        }

        if(other.gameObject.tag=="Spikes_lvl7"){
            isDying=true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ladder") {
            climbLadder = false;
        }
    }

  
   
   /* private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ladder" && action == true)
        {

            myRigidbody.velocity = new Vector2(0f, moveSpeed);

        }
        else if (other.gameObject.tag == "Ladder" && action == false) {
            myRigidbody.velocity = new Vector2(0f, -moveSpeed);
        }
    } */
}

