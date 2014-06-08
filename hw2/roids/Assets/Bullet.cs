using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public Vector3 thrust;
	public Quaternion heading;
	public Vector3 origin = Camera.main.WorldToScreenPoint(new Vector3(0,0,0));
	public Asteroid smallRoid;
	Global globalObj;
	


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

			GameObject g = GameObject.Find ("GlobalObject");
			globalObj = g.GetComponent< Global >();

			// If small asteroid, just die() without creating new asteroids, else create 3 new small asteroids
			if (roid.transform.localScale.x.ToString () != "0.5")
				globalObj.spawnAsteroidPiecesAtPosition(roid.transform.localPosition);

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
