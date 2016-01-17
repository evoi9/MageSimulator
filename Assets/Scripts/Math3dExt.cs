using UnityEngine;
using System.Collections;
using System;



public class Math3dExt : MonoBehaviour {

	
	public static float SignedVectorAngle(Vector3 referenceVector, Vector3 otherVector, Vector3 normal){


		Vector3 perpVector;
		float angle;
		
		//Use the geometry object normal and one of the input vectors to calculate the perpendicular vector
		perpVector = Vector3.Cross(normal, referenceVector);
		
		//Now calculate the dot product between the perpendicular vector (perpVector) and the other input vector
		angle = Vector3.Angle(referenceVector, otherVector);
		angle *= Mathf.Sign(Vector3.Dot(perpVector.normalized, otherVector.normalized));
		
		return angle;


	}

	public static Vector3 MidPosition(Vector3 pos1, Vector3 pos2){

		Vector3 total = pos1 + pos2;

		Vector3 mid = new Vector3 (total.x / 2, total.y / 2, total.z/2);

		return mid;

	}


}
