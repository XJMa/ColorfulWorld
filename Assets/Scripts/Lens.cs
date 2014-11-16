using UnityEngine;
using System.Collections;

public class Lens : MonoBehaviour {

 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnCollisionEnter(Collision collision)
	{
		Collider collider = collision.collider; 
		
		if (collider.CompareTag ("Player")) {
			
			Player p = collider.gameObject.GetComponent<Player> ();

			Destroy (gameObject);

			GUITexture l = GameObject.FindWithTag("GuiLens").GetComponent<GUITexture>() as GUITexture;
			Debug.Log (l);
			RedLensGui rl = l.GetComponent<RedLensGui> ();
			Debug.Log (rl);
			rl.showImage(); 


		} else {
			//if we collided with someting else, print to console
			//what the other thing was
			
			Debug.Log ("Collided with " + collider.tag); 
		}
	}

}
