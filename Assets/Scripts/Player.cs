using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private bool isFaceRight, inAir, jumped;
	private Vector3 runVelocity1, runVelocity2, jumpVelocity;
	bool win = false;
	// Use this for initialization
	void Start () {
		jumpVelocity = new Vector3(0, 50, 0);
		runVelocity1 = new Vector3(0, 0, -2);
		runVelocity2 = new Vector3(0, 0, 2);
		jumped = false;
		inAir = false;
		animation.Play();
	}
	
	// Update is called once per frame
	void Update () {
		if(Mathf.Abs(rigidbody.velocity.y) < 0 && jumped) {inAir = true;}
		else {inAir = false;}

		if(Input.GetButtonDown("Jump") && !inAir && !jumped){				
			rigidbody.AddForce(jumpVelocity, ForceMode.Impulse);
			animation.Play("JUMP01");
			jumped = true;
		}
		if(Input.GetAxisRaw("Horizontal") < 0){
			if(!isFaceRight) transform.Rotate(0,180,0);
			isFaceRight = true;
			animation.Play("RUN00_F");
			if(Mathf.Abs(rigidbody.velocity.y) < 50.0f) {
				rigidbody.AddForce(runVelocity1, ForceMode.Impulse);
			}
		}
		if(Input.GetAxisRaw("Horizontal") > 0){
			if(isFaceRight) transform.Rotate(0,180,0);
			isFaceRight = false;
			animation.Play("RUN00_F");
			if(Mathf.Abs(rigidbody.velocity.y) < 50.0f) {
				rigidbody.AddForce(runVelocity2, ForceMode.Impulse);
			}
		}

		if(rigidbody.velocity.z < 0.1 && rigidbody.velocity.z > -0.1 &&rigidbody.velocity.y == 0){
			animation.CrossFade("WAIT02");	
		}
		if (Input.GetKeyDown(KeyCode.Return) && win){
			Application.LoadLevel("Win");
		}

	}

	void OnCollisionEnter(Collision collision){
		Collider collider = collision.collider; 
		
		if (collider.tag == "Door") {
			Debug.Log("door");
			animation.Play ("WIN00");
			win = true; 
			
		}

		if(collider.tag == "redLens") {
			animation.Play("SLIDE00");
			Debug.Log("Red Pickup");
		}

		if(collider.tag == "blueLens") {
			animation.Play("SLIDE00");
			Debug.Log("Blue Pickup");
		}

		if(collider.tag == "yellowLens") {
			animation.Play("SLIDE00");
			Debug.Log("Yellow Pickup");
		}

		if(collider.tag == "ground") {
			jumped = false;
		}
		if (collider.tag == "spikes") {  
			livesCounter ();
		}
	}

	void livesCounter(){
		if (PlayerPrefs.GetInt ("currentLives") > 0)
			PlayerPrefs.SetInt ("currentLives", PlayerPrefs.GetInt("currentLives") - 1); 

		else 
			Application.LoadLevel("GameOver");

		}
}
