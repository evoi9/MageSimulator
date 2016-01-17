using UnityEngine;
using System.Collections;

public class MageHandController : MonoBehaviour {


	private HandController handController;
	private bool isFireBallReleased;


	public FireBall fireBallPrefab;

	private FireBall currentFireBall = null;

	//private float prevDist = Mathf.Infinity;

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


	protected void UpdateFireBall(HandModel leftHand, HandModel rightHand, FireBall fireBall){

		if (!fireBall.IsReleased) {

			Vector3 midPosition = Math3dExt.MidPosition (leftHand.GetPalmPosition (), rightHand.GetPalmPosition ());
			
			Vector3 leftPalmDir = leftHand.GetPalmDirection ();
			
			Vector3 rightPalmDir = rightHand.GetPalmDirection ();
			
			Vector3 avgDir = (leftPalmDir + rightPalmDir);
			
			currentFireBall.transform.position = midPosition;
			currentFireBall.transform.LookAt (avgDir);
			
			float currentDist = Math3dExt.Distance (leftHand.GetPalmPosition (), rightHand.GetPalmPosition ());

			Debug.Log (currentDist);
			currentFireBall.Grow (currentDist);

		
			if (!HandRecog.IsThumbBent (leftHand, 3) && HandRecog.IsThumbBent(rightHand,3) ){
				//Debug.Log ("A");
				currentFireBall.Release (avgDir, 50f, 0.0f);

			}

		}
	}


	// Update is called once per frame
	void Update () {

		HandModel [] hands = handController.GetAllGraphicsHands ();

		HandModel leftHand = HandRecog.FindFirstLeftHand (hands);
		HandModel rightHand = HandRecog.FindFirstRightHand (hands);

	

		if (IsReadyToCastFireBall (leftHand, rightHand, -180.0f, -80.0f)) {
			Vector3 midPosition = Math3dExt.MidPosition (leftHand.GetPalmPosition (), rightHand.GetPalmPosition ());

			if (currentFireBall) {

					UpdateFireBall(leftHand,rightHand,currentFireBall);

			} else {
				currentFireBall = Instantiate (fireBallPrefab, midPosition, transform.rotation) as FireBall;
			}

		} else {

			if(currentFireBall && ! currentFireBall.IsReleased){

				Rigidbody r =currentFireBall.GetComponent<Rigidbody>();
			
				r.useGravity = true;
			}


			currentFireBall = null;
		}

	
	}

	void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.tag == "Cylinder")
		{
			Debug.Log ("fireball hit");
			Destroy(other.gameObject);
			Destroy(gameObject);

		}
	}
	
	
}