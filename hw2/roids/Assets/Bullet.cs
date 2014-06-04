using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public Vector3 thrust;
	public Quaternion heading;

	// Use this for initialization
	void Start () {
		// travel straight in the X-axis
		thrust.x = 400.0f;

		// do not passively decelerate
		gameObject.rigidbody.drag = 0;

		// set the direction it will travel in
		gameObject.rigidbody.MoveRotation(heading);

		// apply thrust once, no need to apply it again since
		// it will not decelerate
		gameObject.rigidbody.AddRelativeForce (thrust);
	}
	
	// Update is called once per frame
	void Update () {
		// Physics engine handles movement, empty for now
	}

	void OnCollisionEnter( Collision collision ) {
		// The Collision contains a lot of info, but we're most interested in
		// the colliding object

		Collider collider = collision.collider;

		if ( collider.CompareTag("Asteroids") ){
			Asteroid roid = collider.gameObject.GetComponent< Asteroid >();

			// let the other object handle its own death throes
			roid.Die ();

			// Destroy the Bulletwhich collided with the Asteroid
			Destroy (gameObject);
		}
		else {
			// if we collided with something else, print to console
			// what the other thing was

			Debug.Log("Collided with " + collider.tag);

		}

	}
}
