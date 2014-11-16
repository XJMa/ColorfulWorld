using UnityEngine;
using System.Collections;

public class BlueLensGui : MonoBehaviour {

	// Use this for initialization
	public Texture blueLensImage;
	
	// Use this for initialization
	void Start () {
		guiTexture.enabled = false;
			
	}
	
	// Update is called once per frame
	void Update () {
		GameObject gm = GameObject.Find("GameManager"); 
		GameManager g = gm.GetComponent<GameManager>(); 
		if(g.hasBlueLens == true){
			showImage ();
		}	
		
	}
	
	public void showImage(){
		guiTexture.enabled = true;
	}
}
