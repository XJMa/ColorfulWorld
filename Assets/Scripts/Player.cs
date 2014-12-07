using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private bool isFaceRight, inAir, jumped;
	private Vector3 runVelocity1, runVelocity2, jumpVelocity;
	public bool win = false;
	public Font font;
	public AudioClip lens_grab;
	public AudioClip spike_death;
	AudioSource lens_source;
	AudioSource spike_source;
	// Use this for initialization
	void Start () {
		jumpVelocity = new Vector3(0, 50, 0);
		runVelocity1 = new Vector3(0, 0, -0.5f);
		runVelocity2 = new Vector3(0, 0, 0.5f);
		jumped = false;
		inAir = false;
		animation.Play();
		AudioSource[] sources = GetComponents<AudioSource>();
		lens_source = sources[0];
		spike_source = sources[1];
		if(PlayerPrefs.GetInt("spiked") == 1){
			spike_source.Play ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		//Vector3 zeroVelocity = new Vector3(0, 0, 0);
		//rigidbody.AddForce(zeroVelocity, ForceMode.VelocityChange);
		//rigidbody.velocity = new Vector3(0, Mathf.Clamp(rigidbody.velocity.y, -2.0f, 2.0f), rigidbody.velocity.z);
		if(Mathf.Abs(rigidbody.velocity.y) < 0 && jumped) {inAir = true;}
		else {inAir = false;}
		//rigidbody.velocity = Vector3.ClampMagnitude(rigidbody.velocity, 2.0f);
		if(Input.GetButtonDown("Jump") && !inAir && !jumped){				
			rigidbody.AddForce(jumpVelocity, ForceMode.Impulse);
			animation.Play("JUMP01");
			jumped = true;
		}
		if(Input.GetAxisRaw("Horizontal") < 0){
			if(!isFaceRight) transform.Rotate(0,180,0);
			isFaceRight = true;
			animation.Play("RUN00_F");
			if(Mathf.Abs(rigidbody.velocity.z) < 3.0f) {
				rigidbody.AddForce(runVelocity1, ForceMode.VelocityChange);
			}
		}
		if(Input.GetAxisRaw("Horizontal") > 0){
			if(isFaceRight) transform.Rotate(0,180,0);
			isFaceRight = false;
			animation.Play("RUN00_F");
			if(Mathf.Abs(rigidbody.velocity.z) < 3.0f) {
				rigidbody.AddForce(runVelocity2, ForceMode.VelocityChange);
			}
		}

		if(Mathf.Abs(rigidbody.velocity.z) < 0.1 && Mathf.Abs(rigidbody.velocity.y) < 1.0){
			animation.CrossFade("WAIT02");	
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
			lens_source.Play();
		}

		if(collider.tag == "blueLens") {
			animation.Play("SLIDE00");
			Debug.Log("Blue Pickup");
			lens_source.Play();
		}

		if(collider.tag == "yellowLens") {
			animation.Play("SLIDE00");
			Debug.Log("Yellow Pickup");
			lens_source.Play();
		}

		if(collider.tag == "ground") {
			jumped = false;
		}
		if (collider.tag == "spikes") {
			//spike_source.Play();
			livesCounter();
		}
	}

	void livesCounter(){
		if (PlayerPrefs.GetInt ("currentLives") > 0) {
			PlayerPrefs.SetInt ("currentLives", PlayerPrefs.GetInt("currentLives") - 1);
			PlayerPrefs.SetInt ("spiked", 1);
			Application.LoadLevel(Application.loadedLevelName);
		}
		
		else {
			Application.LoadLevel("GameOver");
		}
	}


}
