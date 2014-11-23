using UnityEngine;
using System.Collections;

public class Lens : MonoBehaviour {

	//public LensColor lens;
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
				
			//Player p = collider.gameObject.GetComponent<Player> ();
			//p.animation.Play("REFLESH00");

			Destroy (gameObject);


			if(gameObject.tag == "redLens"){
				GUITexture l = GameObject.FindWithTag("GuiRedLens").GetComponent<GUITexture>() as GUITexture;
				RedLensGui rl = l.GetComponent<RedLensGui> ();
				rl.showImage();
				
				GameObject gm = GameObject.Find("GameManager"); 
				GameManager g = gm.GetComponent<GameManager>(); 
				g.hasRedLens = true;
				g.lens = LensColor.red;
			}

			if(gameObject.tag == "blueLens"){
				GUITexture l = GameObject.FindWithTag("GuiBlueLens").GetComponent<GUITexture>() as GUITexture;
				BlueLensGui rl = l.GetComponent<BlueLensGui> ();
				rl.showImage();
				
				GameObject gm = GameObject.Find("GameManager"); 
				GameManager g = gm.GetComponent<GameManager>(); 
				g.hasBlueLens = true;
				g.lens = LensColor.blue;
			}
		}
	}

}
