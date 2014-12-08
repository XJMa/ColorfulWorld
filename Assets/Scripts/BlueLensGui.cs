using UnityEngine;
using System.Collections;

public class BlueLensGui : MonoBehaviour {

	// Use this for initialization
	public Texture blueLensImage;
	
	// Use this for initialization
	void Start () {
		guiTexture.enabled = false;
		Vector2 pos = new Vector2 (Screen.width * 0.14f, Screen.height * 0.87f);
		gameObject.transform.position = Camera.main.ScreenToViewportPoint(pos);
			
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
