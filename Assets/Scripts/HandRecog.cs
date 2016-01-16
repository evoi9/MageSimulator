using UnityEngine;
using System.Collections;
using System;
using Leap;

//Author Zhongshi Xi
//Github: https://github.com/xzs424
//Email: xizhongshiwise@gmail.com.
//If you have questions, please do not hesitate to ask.



public class HandRecog : MonoBehaviour {


	//Detect if index finger, middle finger, ring finger and little finger are straight (not bent).
	public static bool FourFingersStraight(HandModel hand){

		return !IsIndexFingerBent (hand, 3) && !IsMiddleFingerBent (hand, 3) && !IsRingFingerBent (hand, 3)
			&& !IsLittleFingerBent (hand, 3);

	}

	public static bool IsFingerBentWithinAngle(HandModel hand, int fingerIndex, int boneIndex, float minAngle, float maxAngle){

		FingerModel finger = hand.fingers [fingerIndex];
		
		Vector3 fingerDir = finger.GetBoneDirection (boneIndex);
		
		Vector3 palmNormal = hand.GetPalmNormal ();
		
		Vector3 palmDir = hand.GetPalmDirection ();
		
		if (fingerIndex == 0) {
			
			float angle = Math3dExt.SignedVectorAngle (palmDir, fingerDir, palmNormal);
			
			//Debug.Log ("Finger: " + finger.fingerType + ", bone: " + boneIndex + ", angle to palm direction: " + angle);
			
			if (angle >= minAngle && angle <= maxAngle)
				return true;
				
			
		} else if (fingerIndex > 0) {
			
			Vector3 projPlane = Vector3.Cross(palmNormal, palmDir).normalized;
			Vector3 projVector = Math3d.ProjectVectorOnPlane(projPlane,fingerDir).normalized;
			
			
			float angle = Math3d.SignedVectorAngle(palmNormal,projVector,projPlane);
			
			//Debug.Log ("Finger: " + finger.fingerType + ", bone: " + boneIndex + ", angle to palm direction: " + angle);
			
			if (angle >= minAngle && angle <= maxAngle)
				return true;
		}
		
		
		return false;

	}

	public static float AngleBetweenPalms(HandModel leftHand, HandModel rightHand, Vector3 projectPlane){

		Vector3 leftPalmNorm = leftHand.GetPalmNormal ();

	}


	public static bool IsFingerBent(HandModel hand, int fingerIndex, int boneIndex){

		FingerModel finger = hand.fingers [fingerIndex];
		
		Vector3 fingerDir = finger.GetBoneDirection (boneIndex);
		
		Vector3 palmNormal = hand.GetPalmNormal ();
		
		Vector3 palmDir = hand.GetPalmDirection ();

		if (fingerIndex == 0) {

			 float angle = Math3dExt.SignedVectorAngle (palmDir, fingerDir, palmNormal);
			
			//Debug.Log ("Finger: " + finger.fingerType + ", bone: " + boneIndex + ", angle to palm direction: " + angle);
			
			if (angle < 0)
				return true;

		} else if (fingerIndex > 0) {

			Vector3 projPlane = Vector3.Cross(palmNormal, palmDir).normalized;
			Vector3 projVector = Math3d.ProjectVectorOnPlane(projPlane,fingerDir).normalized;
			
			
			 float angle = Math3d.SignedVectorAngle(palmNormal,projVector,projPlane);

			//Debug.Log ("Finger: " + finger.fingerType + ", bone: " + boneIndex + ", angle to palm direction: " + angle);

			if (angle < 0)
				return true;
		}


		return false;



	}
	
	public static bool IsThumbBent(HandModel hand, int boneIndex){

		return IsFingerBent (hand,0, boneIndex);
	
	}
	
	public static bool IsIndexFingerBent(HandModel hand, int boneIndex){

		return IsFingerBent (hand, 1, boneIndex);
	}

	public static bool IsMiddleFingerBent(HandModel hand, int boneIndex){

		return IsFingerBent (hand, 2, boneIndex);

	}

	public static bool IsRingFingerBent(HandModel hand, int boneIndex){

		return IsFingerBent (hand, 3, boneIndex);

	}

	public static bool IsLittleFingerBent(HandModel hand, int boneIndex){

		return IsFingerBent (hand, 4, boneIndex);

	}

	
	public static bool IsGestureFist(HandModel hand){

		return IsThumbBent (hand, 3) &&  IsIndexFingerBent (hand, 3) && IsMiddleFingerBent (hand, 3) && IsRingFingerBent (hand, 3)
			&& IsLittleFingerBent (hand, 3);

	}

	public static bool IsGestureHighFive(HandModel hand){

		return !IsThumbBent (hand, 3) && FourFingersStraight (hand);

	}


}

//
//	protected virtual void HandleGesture(Gesture gesture, HandModel handModel){
//
//		if (gesture.Type == Gesture.GestureType.TYPE_CIRCLE) {
//			
//			if (gesture.State == Gesture.GestureState.STATESTART) {
//
//				
//			} else if (gesture.State == Gesture.GestureState.STATEUPDATE) {
//				
//		
//			} else if (gesture.State == Gesture.GestureState.STATE_STOP) {
//				
//		
//			}
//			
//		} else if (gesture.Type == Gesture.GestureType.TYPESWIPE) {
//			
//			if( gesture.State ==  Gesture.GestureState.STATESTART){
//				
//				
//			}else if (gesture.State == Gesture.GestureState.STATEUPDATE){
//				
//		
//			}else if (gesture.State == Gesture.GestureState.STATESTOP){
//				
//				
//			}
//			
//		} else if (gesture.Type == Gesture.GestureType.TYPEKEYTAP) {
//			
//			//Debug.Log ("Tap");
//			
//		}
//		
//	}
//	
//	// Update is called once per frame
//	void Update () {
//	
//	}
//}
