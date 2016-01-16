using UnityEngine;
using System.Collections;


//Author Zhongshi Xi
//Github: https://github.com/xzs424
//Email: xizhongshiwise@gmail.com.
//If you have questions, please do not hesitate to ask.

public class Laser : MonoBehaviour {

	// Use this for initialization

	
	private LineRenderer beam;
	private Light hitDot;

	//public Transform laserEmitter;
	public Color color = Color.red;
	public float beamSize = 0.005f;
	public float range = 100f;
	

	

	void Start () {

		//if (laserEmitter == null)
			//laserEmitter = new GameObject ().transform;

		beam = gameObject.AddComponent<LineRenderer>() as LineRenderer;
		beam.material = new Material(Shader.Find("Particles/Additive"));
		beam.SetColors(color, color);
		beam.SetWidth(beamSize, beamSize);
		beam.useWorldSpace = true;
		beam.SetVertexCount (2);
		beam.enabled = true;
		
		hitDot = gameObject.AddComponent<Light>() as Light;
		hitDot.type = LightType.Spot;
		hitDot.enabled = true;
		hitDot.range = range;
		hitDot.spotAngle =1;
		hitDot.color = color;


	}

	void UpdateBeam(Vector3 origin, Vector3 direction, float range){

		Vector3 end = origin + Vector3.Scale (direction, new Vector3 (range, range, range));

		beam.SetPosition (0, origin);
		beam.SetPosition (1, end);

	}

	public void Enable(){

		beam.enabled = true;
		hitDot.enabled = true;

	}

	public void Disable(){

		beam.enabled = false;
		hitDot.enabled = false;
	}

	// Update is called once per frame
	void Update () {

		UpdateBeam (gameObject.transform.position, gameObject.transform.forward, range);
	
	}
}
