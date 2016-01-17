using UnityEngine;
using System.Collections;
using Leap;


public class FireBall : MonoBehaviour {

	private ParticleSystem ps;
		
	// Use this for initialization
	void Start () {

		ps = gameObject.GetComponent<ParticleSystem> ();

	}


	public void Grow(float factor){
		//ps = gameObject.GetComponent<ParticleSystem>();
		//ps.emissionRate.Equals (50f);

		ps = gameObject.GetComponent<ParticleSystem> ();
			ps.maxParticles += 100;
			ps.startSize += 1.1f;

			gameObject.transform.localScale += new Vector3 (1*factor,1*factor,1*factor);
			Debug.Log ("ps");



		//gameObject.transform.localScale += new Vector3 (1*factor, 1*factor, 1*factor);
	}

	public void Release(Vector3 dir, float magnitude){
		Rigidbody rigidBody = gameObject.GetComponent<Rigidbody>();
		rigidBody.AddForce(dir * magnitude);
		//Debug.Log ("pinched");

	}
	
	// Update is called once per frame
	void Update () {



	}
}
