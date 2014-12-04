using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	// Use this for initialization
	public GameObject door;
	private Vector3 playerPos;
	private float startTime;
	private float journeyLength;
	private float speed = 0.1f;
	//public float distance;
	void Start () {
		
		//distance = transform.position - playerPos;
		playerPos = GameObject.Find("Player").transform.position;
		transform.position = new Vector3(transform.position.x, door.transform.position.y, door.transform.position.z);
		startTime = Time.time;
		journeyLength = Vector3.Distance(playerPos, door.transform.position);

	}
	
	// Update is called once per frame
	void Update () {
		playerPos = GameObject.Find("Player").transform.position;
		Vector3 pos = new Vector3(transform.position.x, playerPos.y+1, playerPos.z);//make camera follow player
		float distCovered = (Time.time - startTime) * speed;
		float fracJourney = distCovered / journeyLength;
		transform.position = Vector3.Lerp(transform.position, pos, fracJourney);
		
	}
}
