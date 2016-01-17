using UnityEngine;
using System.Collections;

public class CubeHit : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter(Collision other){

		GameObject.Find ("Score").GetComponent<Score> ().score += 1;

	}
}
