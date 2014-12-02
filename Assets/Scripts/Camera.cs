using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

	// Use this for initialization
	private Vector3 playerPos;
	public float transitionDuration = 2.5f;
	//public float distance;
	void Start () {
		
		//distance = transform.position - playerPos;

	}
	
	// Update is called once per frame
	void Update () {
		playerPos = GameObject.Find("Player").transform.position;
		Vector3 pos = new Vector3(transform.position.x, playerPos.y+1, playerPos.z);//make camera follow player
		gameObject.transform.position = pos;
		
	}
}
