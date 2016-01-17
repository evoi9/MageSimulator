using UnityEngine;
using System.Collections;

public class MageHandController : MonoBehaviour {


	private HandController handController;
	private bool isFireBallCasted;


	public FireBall fireBall;

	private FireBall currentFireBall = null;

	private float prevDist = Mathf.Infinity;
	//public float fireballCreateTime = 1.0f;

	// Use this for initialization
	void Start () {
		handController = gameObject.GetComponent<HandController> ();
	

	}




	protected bool IsReadyToCastFireBall(HandModel leftHand, HandModel rightHand,float minToleranceAngle, float maxToleranceAngle){

		if (leftHand && rightHand) {

				float angle = HandRecog.AngleBetweenPalmsNormals (leftHand, rightHand, transform.forward);

				//Debug.Log("PalmAngle:" +angle);
				if (angle >= minToleranceAngle && angle <= maxToleranceAngle)
					return true;
				
		}

		return false;
	}



	// Update is called once per frame
	void Update () {

		HandModel [] hands = handController.GetAllGraphicsHands ();

		HandModel leftHand = HandRecog.FindFirstLeftHand (hands);
		HandModel rightHand = HandRecog.FindFirstRightHand (hands);

		if (IsReadyToCastFireBall (leftHand, rightHand, -180.0f, -80.0f)) {

			Vector3 midPosition = Math3dExt.MidPosition (leftHand.GetPalmPosition (), rightHand.GetPalmPosition ());

			if (currentFireBall) {
		
				currentFireBall.transform.position = midPosition;

				float currentDist=	Math3dExt.Distance(leftHand.GetPalmPosition(), rightHand.GetPalmPosition());

				if (prevDist == Mathf.Infinity){

					prevDist = currentDist;
				}

				//Debug.Log ("CurrentDist: "+ currentDist  + ", PrevDist: " + prevDist);
				//Debug.Log (currentDist - prevDist);
				fireBall.Grow (10.0f);

				prevDist = currentDist;



//				if (leftHand.GetLeapHand().PinchStrength > 0.6 && rightHand.GetLeapHand().PinchStrength >0.6){
//					Rigidbody rigidBody = currentFireBall.GetComponent<Rigidbody>();
//
//					rigidBody.AddForce(currentFireBall.transform.forward * 100);
//					Debug.Log ("pinched");
//				}

				if (HandRecog.IsThumbBent(leftHand,3) || HandRecog.IsThumbBent(rightHand,3)){

					Vector3 leftPalmDir = leftHand.GetPalmDirection();

					Vector3 rightPalmDir = rightHand.GetPalmDirection ();

					Vector3 avgDir = (leftPalmDir + rightPalmDir );

					currentFireBall.Release(avgDir,10);

					//currentFireBall = null;




				}

			} else {
				currentFireBall = GameObject.Instantiate (fireBall, midPosition, transform.rotation) as FireBall;
			}

		} else {

			if(currentFireBall){

				Rigidbody rigidBody = currentFireBall.GetComponent<Rigidbody>();
				rigidBody.useGravity = true;
				currentFireBall.gameObject.AddComponent<TimedDestroy>();


			}

			prevDist = Mathf.Infinity;
			currentFireBall = null;
		}

	
	}

	
	
}