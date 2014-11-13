using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {
	public LensColor color;//need to be assigned in unity
	public Material myMat;//need to be assigned in unity
	private GameManager gameManager;
	// Use this for initialization
	void Start () {
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		collider.enabled = false;
		//set start transparency
		Color c = renderer.material.color;
		c.a = 0.8f;
		renderer.material.color = c;
		
	}
	
	// Update is called once per frame
	void Update () {
		if(gameManager.lens != LensColor.none){
			renderer.material = myMat;
			collider.enabled = true;
		}	
	
	}
}
