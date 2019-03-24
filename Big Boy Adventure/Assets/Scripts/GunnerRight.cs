using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GunnerRight : MonoBehaviour {

    public GameObject gunFire;
    public Transform fireHolder;
    public BulletGunControlRight bulletController;
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
        bulletController = FindObjectOfType<BulletGunControlRight>();
        myAnim = GetComponent<Animator>();
        /* if (sceneName == "scene5")
        {
            fire = true;
        }
        else {*/ fire = false; //}
         

    }

    // Update is called once per frame
    void Update()
    {
       if(sceneName=="scene5"){
            fire=FindObjectOfType<Lvl5ActivateGunner>().startFire;
        }
        if(sceneName=="scene6"){
            fire=FindObjectOfType<SwithController>().activeShooting;
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
