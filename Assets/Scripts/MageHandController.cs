using UnityEngine;
using System.Collections;

public class MageHandController : MonoBehaviour {


	private HandController handController;
	private bool isFireBallCasted;


	public GameObject fireBall;

	private GameObject currentFireBall = null;

	//public float fireballCreateTime = 1.0f;

	// Use this for initialization
	void Start () {
		handController = gameObject.GetComponent<HandController> ();

	}




	protected bool IsReadyToCastFireBall(HandModel leftHand, HandModel rightHand,float minToleranceAngle, float maxToleranceAngle){

		if (leftHand && rightHand) {

				float angle = HandRecog.AngleBetweenPalmsNormals (leftHand, rightHand, transform.forward);

				Debug.Log("PalmAngle:" +angle);
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

		if (IsReadyToCastFireBall (leftHand, rightHand, -180.0f, -100.0f)) {

			Vector3 midPosition = Math3dExt.MidPosition (leftHand.GetPalmPosition (), rightHand.GetPalmPosition ());

			if (isFireBallCasted) {

				currentFireBall.transform.position = midPosition;




			} else {
				currentFireBall = GameObject.Instantiate (fireBall, midPosition, transform.rotation) as GameObject;
				//currentFireBall.transform.position = midPosition;
				isFireBallCasted = true;
			}

		} else {

			if(currentFireBall){

				currentFireBall.AddComponent<Rigidbody>();
			}
			isFireBallCasted = false;
		}

	
	}

	
	
}