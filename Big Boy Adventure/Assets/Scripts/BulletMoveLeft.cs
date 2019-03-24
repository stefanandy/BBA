using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BulletMoveLeft : MonoBehaviour {
	
	public float speed;
	public Rigidbody2D rb;
	public JungHeadController jgController;
    public CrateController crate;
    public GameObject amethist;
     [SerializeField] public int contor=1;

	// Use this for initialization
	void Start () {

		jgController=FindObjectOfType<JungHeadController>();
		rb=GetComponent<Rigidbody2D>();
        crate = FindObjectOfType<CrateController>();
		rb.velocity=new Vector2(-speed,0f); // go with speed in direcit -x
		Destroy(gameObject,2f); //gameobject will have a life spawn of 2 seconds.
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D other)
	{

        /* if (other.gameObject.tag == "Crate" && SceneManager.GetActiveScene().name=="scene5")
        {
            contor++;
            crate.explosion = true;
            if (contor % 2 == 0)
            {
                Instantiate(amethist,transform.position,Quaternion.identity);
            }
    
		}*/
		if (other.gameObject.tag=="Enemy"){ //destroy enemy
			jgController.deadFromBullet=true;
			}
		
	}

	private void OnTriggerExit2D(Collider2D other) {
		if(other.gameObject.tag=="MainCamera"){
			Destroy(gameObject);
		}
	}
}
