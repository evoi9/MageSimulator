using UnityEngine;
using System.Collections;

public class ObjectFinder : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	public static GameObject FindParentWithTag(GameObject childObject, string tag)
	{
		Transform t = childObject.transform;
		while (t.parent != null)
		{
			if (t.parent.tag == tag)
			{
				return t.parent.gameObject;
			}
			t = t.parent.transform;
		}
		return null; 
	}
}
