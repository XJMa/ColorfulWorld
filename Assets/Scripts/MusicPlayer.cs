using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	AudioSource theme;

	// Use this for initialization
	void Start () {
		AudioSource[] sources = GetComponents<AudioSource>();
		theme = sources[0];
		theme.Play();
	}
	
	// Update is called once per frame
	void Update () {

	}
}
