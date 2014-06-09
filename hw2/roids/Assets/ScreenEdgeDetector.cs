using UnityEngine;
using System.Collections;

public class ScreenEdgeDetector : MonoBehaviour {
	public Vector3 thrust;

	// Use this for initialization
	void Start () {
		
	}

	void OnTriggerEnter( Collider collider ) {

		float newX = collider.transform.position.x;
		float newZ = collider.transform.position.z;

		// move collider to other side of screen
		if(gameObject.CompareTag("RightWall")) {
			newX = newX * -1 + 1; // + 1 to put it slihtly inside the left wall to avoid calling LeftCollider.OnTriggerEnter/Exit 
		}
		if(gameObject.CompareTag("BottomWall")) {
			newZ = newZ * -1  - 1;
		}
		if(gameObject.CompareTag("LeftWall")) {
			newX = newX * -1 - 1;
		}
		if(gameObject.CompareTag("TopWall")) {
			newZ = newZ  * -1 + 1;
		}

		Debug.Log ("WALL COllision WITH " + collider.tag);

		Debug.Log (newX + " | " + newZ);

		collider.transform.position = new Vector3(newX, 0, newZ);

	}

	void OnTriggerExit( Collider collider ){
		Debug.Log (collider.tag + " is now exiting ");
		Debug.Log (collider.transform.position.x + " | " + collider.transform.position.z);
	}

	// Update is called once per frame
	void Update () {
	
	}
}
