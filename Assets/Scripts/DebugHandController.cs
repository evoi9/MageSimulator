using UnityEngine;
using System.Collections;
using System;

public class DebugHandController : MonoBehaviour {



	private HandController controller;

	// Use this for initialization
	void Start () {

		controller = gameObject.GetComponent<HandController> ();
	
	}
	
	// Update is called once per frame
	void Update () {


		HandModel[] hands = controller.GetAllGraphicsHands ();

		HandModel leftHand = HandRecog.FindFirstLeftHand (hands);
		HandModel rightHand = HandRecog.FindFirstRightHand (hands);
	
		if (leftHand && rightHand ) {

			if (leftHand.GetLeapHand().Confidence > 0.5f && rightHand.GetLeapHand().Confidence > 0.5f){
				Debug.Log (transform.up.y);
				Debug.Log(HandRecog.AngleBetweenPalmsDirections(leftHand,rightHand,transform.up));
			}

		}



	}
}
