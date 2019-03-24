using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuController : MonoBehaviour {

		public Rigidbody2D rb;
		public NewPlayerController thePlayer;
		public float moveSpeed;
		public bool Jungdead;
		private Animator myAnim;

		public GameObject explosion;
		public GameObject uranium;
		public GameObject bullet;
		public Transform bulletSpawn;
		private float nextFire;
		public float fireRate;
		public bool dead;
		public bool aiSeePlayer;
		public float distance;
		
	
	// Use this for initialization

	void Start () {
		dead=false;
		aiSeePlayer=false;
		thePlayer=FindObjectOfType<NewPlayerController>();
		myAnim=GetComponent<Animator>();
		rb=GetComponent<Rigidbody2D>();
		myAnim.Play("JungHeadIdleAttack");
		Instantiate(bullet,bulletSpawn.position,bulletSpawn.rotation);
	

		
	}
	
	void Update(){
		//Dead();
		//Debug.Log("Dead din JU"+dead);
	}
	
	
	// Update is called once per frame
	
		void FixedUpdate () {
		Dead();
//		Debug.Log(dead);
		AI();
		if(transform.position.x<thePlayer.transform.position.x){
			rb.velocity=new Vector2(-5f,0f);
		}
		//Dead();
	}
	public void AI(){
		distance=Mathf.Abs(transform.position.x-thePlayer.transform.position.x);
		if (distance<7)
		{
			aiSeePlayer=true;
		}

		if(aiSeePlayer==true){
			
				if(distance>3){
				//	transform.position=Vector2.MoveTowards(new Vector2(-transform.position.x,transform.position.y), thePlayer.transform.position, 3f*Time.deltaTime);
					//myAnim.Play("JungHeadWalkingAttack");
				//}
					if(Time.time>nextFire){
							nextFire=Time.time+fireRate;
							myAnim.Play("JungHeadWalkingAttack");
							Instantiate(bullet,bulletSpawn.position,bulletSpawn.rotation);
							}
							//
				}
		
					else if(distance<1f){
						rb.velocity=new Vector2(0f,0f);
						myAnim.Play("JungHeadIdleAttack");
							if(Time.timeScale>nextFire){
								nextFire=Time.timeScale+fireRate;
								Instantiate(bullet,bulletSpawn.position,bulletSpawn.rotation);
							}

		}

	/*} else{
		//transform.position=Vector2.MoveTowards(new Vector2(transform.position.x,transform.position.y),thePlayer.transform.position,3f*Time.deltaTime);
		Debug.Log("se misca nebunu");

	}*/
	}
	}

	/*void OnTriggerEnter2D(Collider2D other)
	{	
		if(other.gameObject.tag=="Player"){
			aiSeePlayer=true;
		}
		
	}*/
	void Dead(){
		if(dead==true){ //|| gameObject.activeInHierarchy==false){
			gameObject.SetActive(false);
			Instantiate(explosion,transform.position,transform.rotation);
			Instantiate(uranium,transform.position,transform.rotation);
		}
	}

	
	void OnCollisionEnter2D(Collision2D other)
	{	
		if (other.gameObject.tag=="Player")
		{
			thePlayer.isDead=true;
		}
		
		
	}

	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag=="Bullet")
		{
			dead=true;
			Destroy(other.gameObject);
		}
		
	}
}
