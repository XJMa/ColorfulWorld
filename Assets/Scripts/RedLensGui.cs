using UnityEngine;
using System.Collections;

public class RedLensGui : MonoBehaviour {

	public Texture redLensImage;

	// Use this for initialization
	void Start () {
		guiTexture.enabled = false;

				
	}
	
	// Update is called once per frame
	void Update () {
		GameObject gm = GameObject.Find("GameManager"); 
		GameManager g = gm.GetComponent<GameManager>(); 
		if(g.hasRedLens == true){
			showImage ();
		}
		
	}
	
	public void showImage(){
		guiTexture.enabled = true;
	}
}

