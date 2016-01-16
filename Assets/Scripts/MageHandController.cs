using UnityEngine;
using System.Collections;

public class MageHandController : MonoBehaviour {


	private HandController handController;
	// Use this for initialization
	void Start () {

		handController = gameObject.GetComponent<HandController> ();

	}
	
	// Update is called once per frame
	void Update () {

		HandModel [] hands = handController.GetAllGraphicsHands ();

		HandModel leftHand;
		HandModel rightHand;

		if (hands.Length >= 2) {
		



		}
		
	}
}
