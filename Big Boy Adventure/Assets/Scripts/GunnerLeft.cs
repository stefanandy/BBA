using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GunnerLeft : MonoBehaviour {

    public GameObject gunFire;
    public Transform fireHolder;
    public GunnerBulletController bulletController;
    
    public SwithController switcher;
    public Animator myAnim;
    public bool fire;
    public float fireRate;
    public float nextFire;
    public string sceneName;


    // Use this for initialization
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        switcher=FindObjectOfType<SwithController>();
        bulletController = FindObjectOfType<GunnerBulletController>();
        myAnim = GetComponent<Animator>();

        /* if (sceneName == "scene5")
        {
            fire = true;
        }
        else {*/ fire = false; //}
        /* if (transform.localScale.x == -1)
         {
             bulletController.moveSpeed = -bulletController.moveSpeed;
         }*/

    }

    // Update is called once per frame
    void Update()
    {
        if(sceneName=="scene5"){
            fire=FindObjectOfType<Lvl5ActivateGunner>().startFire;
        }
        if(sceneName=="scene6"){
            fire=switcher.activeShooting; 
        }
        if (fire == true && Time.time > nextFire)
        {

            nextFire = Time.time + fireRate;
            myAnim.Play("GunnerFiring");
            Instantiate(gunFire, fireHolder.position, fireHolder.rotation);
        }
        else
        {
            myAnim.Play("GunnerIdle");
        }
    }

    
}
