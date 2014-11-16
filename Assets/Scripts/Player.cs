using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private bool isFaceRight;
	private Vector3 jumpVelocity;
	private Vector3 runVelocity1, runVelocity2;
	bool win = false; 
	// Use this for initialization
	void Start () {
		jumpVelocity = new Vector3(0, 5, 0);
		runVelocity1 = new Vector3(0, 0, -2);
		runVelocity2 = new Vector3(0, 0, 2);
		animation.Play();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Jump") && rigidbody.velocity.y < 0.5){				
			rigidbody.AddForce(jumpVelocity, ForceMode.VelocityChange);
			animation.Play("JUMP01");
			
		}
		if(Input.GetAxisRaw("Horizontal") < 0){
			if(!isFaceRight) transform.Rotate(0,180,0);
			isFaceRight = true;
			rigidbody.AddForce(runVelocity1, ForceMode.Impulse);
			animation.Play("RUN00_F");
		}
		if(Input.GetAxisRaw("Horizontal") > 0){
			if(isFaceRight) transform.Rotate(0,180,0);
			isFaceRight = false;
			rigidbody.AddForce(runVelocity2, ForceMode.Impulse);
			animation.Play("RUN00_F");
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
			animation.Play ("WIN00");
			win = true; 
		}
	}
}
