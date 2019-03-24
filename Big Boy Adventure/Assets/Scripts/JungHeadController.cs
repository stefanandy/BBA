using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JungHeadController : MonoBehaviour {

	public Rigidbody2D jh;
	public Transform leftPoint;
	public Transform rightPoint;
	public float moveSpeed;
	public bool movingRight;
	public bool isMoving;
	public bool isDead;
	private Animator myAnim;
	public SpriteRenderer theSpriteRenderer;
	public Sprite deadSprite;
	public Transform startCast;
	public Transform endCast;
	public bool deadFromBullet;
	public GameObject deadExplosion;
	public Transform explosionSpawn;
	public GameObject uranium;
	public bool isCreated;
	public JungAI AI;
	public PlayerController thePlayer;
	public float distance;

	public GameObject bullet;
	public Transform bulletSpawn;
	private float nextFire;
	public float fireRate;

	//private Vector2 dir=new Vector2(1,0);
	public float range;
	public float speed;

	public bool hitByCar;

	// Use this for initialization
	void Start () {

		thePlayer=FindObjectOfType<PlayerController>();
		AI=FindObjectOfType<JungAI>();
		deadFromBullet=false;
		isMoving=true;
		isDead=false;
		hitByCar=false;
		myAnim=GetComponent<Animator>();
		jh=GetComponent<Rigidbody2D>();
		theSpriteRenderer=GetComponent<SpriteRenderer>();
		
	}
	
	// Update is called once per frame
	void Update () {
				
				//RaycastHit2D hit2D=Physics2D.Raycast(transform.position, dir, range);
		
		//Moving();

		//Dead();

	}

	
	void FixedUpdate()
	{	
		//Debug.DrawRay(transform.position, thePlayer.transform.position - transform.position, Color.green); //debug
	/*	RaycastHit2D hit2D=Physics2D.Raycast(transform.position, thePlayer.transform.position-transform.position,3f);
		if(hit2D.collider.tag=="Player"){
			//Debug.Log("GASIT PE RAYCAST");
		}*/

		if (jh.IsSleeping() ) {
    			jh.WakeUp();
			}
		if(hitByCar==false){
			Moving();
		}
		Dead();
		
	}

	void Moving(){
			if(AI.seePlayer==false){

				//Debug.Log("Ai see player=" + AI.seePlayer);
					if(isMoving&&movingRight && transform.position.x>rightPoint.position.x){
						movingRight=false;
					}
					if(isMoving&&!movingRight&& transform.position.x<leftPoint.position.x){
						movingRight=true;
					}

					if(movingRight&&isMoving){
						jh.velocity=new Vector3(moveSpeed,jh.velocity.y,0f);
						transform.localScale=new Vector3(1f,1f,1f);
					}else if(isMoving&&!movingRight){
						jh.velocity=new Vector3(-moveSpeed,jh.velocity.y,0f);
						transform.localScale=new Vector3(-1f,1f,1f);
				}
			} else if(AI.seePlayer==true&& thePlayer.isDying==false) {
				//Debug.Log("mata=" + AI.seePlayer);
				distance=Mathf.Abs(transform.position.x-thePlayer.transform.position.x);
					if(distance>3){
							transform.position=Vector2.MoveTowards(transform.position, thePlayer.transform.position, 3f*Time.deltaTime);
							myAnim.Play("JungHeadWalkingAttack");
						if(Time.time>nextFire){
							nextFire=Time.time+fireRate;
							Instantiate(bullet,bulletSpawn.position,bulletSpawn.rotation);
							}
				
						}
					else if(distance<1f){
					jh.velocity=new Vector2(0f,0f);
					myAnim.Play("JungHeadIdleAttack");
						if(Time.time>nextFire){
							nextFire=Time.time+fireRate;
							Instantiate(bullet,bulletSpawn.position,bulletSpawn.rotation);
						}
				/*} else if(distance>4f){
					if(gameObject.tag=="Enemy2")
							AI.see=false;
				} */
			}
	}
	}

	void Dead(){

		if (isDead==true)
		{	
			myAnim.Play("JungHeadDead");
			//gameObject.SetActive(false);
			GetComponent<BoxCollider2D> ().enabled = false;
			isMoving=false;
			//myAnim.enabled=false;
			theSpriteRenderer.sprite=deadSprite;
			//Destroy(jh);
			//jh.isKinematic=true;
			//myAnim.Stop();


			
		}

		if(deadFromBullet==true){
			Instantiate(deadExplosion,explosionSpawn.position, explosionSpawn.rotation);
			
			//myAnim.Play("JungHeadExplosion");
			//Destroy(gameObject);
			gameObject.SetActive(false);
			if(!isCreated){
				Instantiate(uranium,explosionSpawn.position,explosionSpawn.rotation);
				isCreated=true;			
			}
		}
	}

	private void OnCollisionEnter2D(Collision2D other) {
			if(other.gameObject.tag=="Car"){
				isDead=true;
				hitByCar=true;
				FindObjectOfType<ScoreController>().score++;
				Dead();
			}
			if(other.gameObject.tag=="Bullet"){
				Destroy(gameObject);
				deadExplosion.transform.localScale=new Vector3(3,3,3);
				Instantiate(deadExplosion,transform.position,Quaternion.identity);
				Instantiate(uranium,transform.position,Quaternion.identity);
			}
			if(other.gameObject.tag=="Spikes_lvl5"){
				isDead=true;
			}
	}

	
	void OnTriggerEnter2D(Collider2D other)
	{	if(other.gameObject.tag=="Player"){
			AI.seePlayer=true;
		}
	}
}
