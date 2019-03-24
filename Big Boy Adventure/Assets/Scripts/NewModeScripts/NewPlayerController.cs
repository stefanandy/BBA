using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerController : MonoBehaviour {

	public Rigidbody2D myRigidBody;
	public float moveSpeed;
	public Animator myAnim;
	public Sprite arnie;
	public Sprite tArnie;
	private SpriteRenderer theSpriteRenderer;

	public bool isDead;
	public bool invincible;

	public SwipeManager swipeManager;
	public GameObject bullet;
	public Transform bulletSpawn;
	public float fireRate;
	
	public float jumpRate;
	private float nextJump;
	private float nextFire;
	public bool isFire;


	
	

	// Use this for initialization
	void Start () {
		invincible=false;
		isFire=false;
		swipeManager=FindObjectOfType<SwipeManager>();
		isDead=false;
		myAnim=GetComponent<Animator>();
		myRigidBody=GetComponent<Rigidbody2D>();
		theSpriteRenderer=GetComponent<SpriteRenderer>();
		
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		MoveOnSwipe();
		FIre();
		/*	if(Input.GetKeyDown(KeyCode.A)&&Time.time>nextFire){
				Debug.Log(nextFire);
				nextFire=Time.time+fireRate;
				Instantiate(bullet,bulletSpawn.position,bulletSpawn.rotation);
					myAnim.Play("WalkAndFire");
		}*/
		//FIre();
		myRigidBody.velocity=new Vector3(moveSpeed,myRigidBody.velocity.y,0f);
		if(Mathf.Abs(myRigidBody.transform.position.x)>0&&isFire==false){
			WalkingAnimationSelector();
		}
		/*if(Input.GetKeyDown(KeyCode.A)){
			myRigidBody.velocity=new Vector3(myRigidBody.velocity.x,5f,0f);
		}/* */
		StartCoroutine(InvincibleTime());
		Dead();
	}
		
	void SkinSelector(){
		if (PlayerPrefs.GetInt("selectSkin")==1){
			theSpriteRenderer.sprite=tArnie;
		}
		if (PlayerPrefs.GetInt("selectSkin")==0){
			theSpriteRenderer.sprite=arnie;
		}
	}

	void WalkingAnimationSelector(){
		switch(PlayerPrefs.GetInt("selectSkin"))
		{
			case 1:
					myAnim.Play("WalkingAnimation1");
					return;
			default:
					myAnim.Play("WalkingAnimation");
					return;
		}

	}

	void WalkAndFireAnimationSelector(){
		switch (PlayerPrefs.GetInt("selectSkin"))
		{
			case 1:
					myAnim.Play("WalkAndFire1");
					return;
			default: 
					myAnim.Play("WalkAndFire");
					return;

		}
	}


	void MoveOnSwipe(){
		if(SwipeManager.IsSwipingUp()){
			if(Time.time>nextJump){
				nextJump=Time.time+jumpRate;
				myRigidBody.velocity=new Vector3(myRigidBody.velocity.x,5f,0f);	
		}
			
		}
		if(SwipeManager.IsSwiping()){
			//shooting 
			//isFire=true;
			/*Debug.Log("tragem tragem tragem ");
			if(Time.time>nextFire){
				nextFire=Time.time+fireRate;
				myAnim.Play("WalkAndFire");
				Instantiate(bullet,bulletSpawn.position,bulletSpawn.rotation);
					
		}/* */
		}
		//}
		if(SwipeManager.IsSwipingLeft()){
			moveSpeed=moveSpeed-1;
			if(moveSpeed<=1){
				moveSpeed=1;
			}
		}
		if(SwipeManager.IsSwipingRight()){
			moveSpeed=moveSpeed+1;
			if(moveSpeed>=10){
				moveSpeed=10;
			}
		}
	}
	IEnumerator InvincibleTime(){
		if (invincible==true)
		{
			isDead=false;
			yield return new WaitForSeconds(5f);
			invincible=false;
		}
	}
	
	void FIre(){
		if(isFire==true&&Time.time>nextFire){
			nextFire=Time.time+fireRate;
				WalkAndFireAnimationSelector();
				Instantiate(bullet,bulletSpawn.position,bulletSpawn.rotation);
					
		}	
	}

	public void FireActive(){
		isFire=true;
	}
	public void FireNotActive(){
		isFire=false;
	}

	void Dead(){
		if (isDead==true&&invincible==false){

			gameObject.SetActive(false);
			
		}

		if(isDead==false){
			gameObject.SetActive(true);
		}
	}
}
