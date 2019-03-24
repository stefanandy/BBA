using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class mover : MonoBehaviour {
    public float speed = 0.05f;
    public float damp = 0.15f;
    public Toggle Automove;
    public float maxDistanceX = 160;
    private float minDistanceX = -8;
    private float minDistanceY = -20;
    private float maxDistanceY = 1.6f;

    public Transform Player;
    public bool canMoveY = false;

    void Start () {
        Automove.isOn = false;
    }
    void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("UnderwaterY"))
        {
            canMoveY = true;
        }

    }

    void LateUpdate () {
        //Move Left (if you are using different OS you can change KeyCode acording to your system
        if (Input.GetKey (KeyCode.LeftArrow) && Player.position.x >= minDistanceX) {
            transform.position += Vector3.left * speed * damp;
            Automove.isOn = false;
        }
        //Move Right (if you are using different OS you can change KeyCode acording to your system
        if (Input.GetKey (KeyCode.RightArrow) && Player.position.x <= maxDistanceX) {
            transform.position += Vector3.right * speed * damp;
            Automove.isOn = false;
        }
        //Move Down works only in Underwater Level (if you are using different OS you can change KeyCode acording to your system
        if (Input.GetKey (KeyCode.DownArrow) && Player.position.y >= minDistanceY && canMoveY) {
            transform.position += Vector3.down * speed * damp;
            Automove.isOn = false;
        }
        //Move Up works only in Underwater Level (if you are using different OS you can change KeyCode acording to your system
        if (Input.GetKey (KeyCode.UpArrow) && Player.position.y <= maxDistanceY && canMoveY) {
            transform.position += Vector3.up * speed * damp;
            Automove.isOn = false;
        }
        if (Automove.isOn && Player.position.x <= maxDistanceX) {
            transform.position += Vector3.right * speed * damp;
        }
        if (Automove.isOn == false) {
            transform.position += Vector3.right * 0 * damp;
        }
        if (Automove.isOn && Player.position.y >= minDistanceY && canMoveY) {
            transform.position += Vector3.down * speed * damp;
        }
    }
    public void AutomoverCheck () {
        if (Automove.isOn == false) {
            Automove.isOn = true;
        } else {
            Automove.isOn = false;
        }
    }

}