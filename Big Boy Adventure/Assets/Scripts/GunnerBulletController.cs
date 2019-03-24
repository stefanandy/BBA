﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunnerBulletController : MonoBehaviour {

    public Rigidbody2D rb;
    public float moveSpeed;
    public PlayerController thePlayer;

    public RoboFlyController robo;
    
    public GameObject explosion;
    public int damage=20;

    // Use this for initialization
    void Start () {
        thePlayer = FindObjectOfType<PlayerController>();
        robo=FindObjectOfType<RoboFlyController>();

        rb = GetComponent<Rigidbody2D>();
        
        rb.velocity = new Vector2(moveSpeed, 0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            thePlayer.isDying = true;
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(other);

        }
        if (other.gameObject.tag == "Ground")
        {
            Instantiate(explosion,transform.position,Quaternion.identity);
            Handheld.Vibrate();
            Destroy(gameObject);
        }

        if(other.gameObject.tag=="Boss"){
            damage=1;
            robo.life=robo.life-damage;
            Instantiate(explosion,transform.position,Quaternion.identity);
            Handheld.Vibrate();
            Destroy(gameObject);
        }

    }


}
