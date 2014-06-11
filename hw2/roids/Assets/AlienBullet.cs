using UnityEngine;
using System.Collections;

public class AlienBullet : MonoBehaviour {
	
	public Vector3 thrust;
	public Quaternion heading;
	public Vector3 origin = Camera.main.WorldToScreenPoint(new Vector3(0,0,0));
	Global globalObj;
	
	
	
	// Use this for initialization
	void Start () {
		// travel straight in the X-axis
		thrust.x = 700.0f;
		
		// do not passively decelerate
		gameObject.rigidbody.drag = 0;
		
		// set the direction it will travel in
		gameObject.rigidbody.MoveRotation(heading);
		
		// apply thrust once, no need to apply it again since
		// it will not decelerate
		gameObject.rigidbody.AddRelativeForce (thrust);
		
		// Remove bullet after 3 seconds
		Destroy (gameObject, 2.0f);
	}
	
	// Update is called once per frame
	void Update () {
		// Physics engine handles movement, empty for now
	}
	
	void OnCollisionEnter( Collision collision ) {
		// The Collision contains a lot of info, but we're most interested in
		// the colliding object
		
		Collider collider = collision.collider;

		// if hits asteroid break it
		if (collider.CompareTag ("Asteroids")) {
						Asteroid roid = collider.gameObject.GetComponent< Asteroid > ();

						if (GameObject.Find ("GlobalObject") != null) {
								GameObject g = GameObject.Find ("GlobalObject");
								globalObj = g.GetComponent< Global > ();
			
								// If small asteroid, just die() without creating new asteroids, else create 3 new small asteroids
								if (!roid.name.Contains ("SmallAsteroid"))
										globalObj.spawnAsteroidPiecesAtPosition (roid.transform.localPosition);
			
								Debug.Log ("ASTEROID IMPACT ****** " + roid.name.Contains ("SmallAsteroid"));
			
								// let the other object handle its own death throes
								roid.Die ();
			
								// Destroy the Bulletwhich collided with the Asteroid
								//	Destroy (gameObject);
						}
				}
		else {
			// if we collided with something else, print to console
			// what the other thing was
			
			Debug.Log("Collided with " + collider.tag);
			
		}
		
	}
	
	
	void OnTriggerEnter(Collider collider) {
		
		if (collider.name.Contains("ShipPrefab")) {
			Ship ship = collider.gameObject.GetComponent<Ship>();
			ship.Die();
			
		}
	//	Destroy (gameObject);
	}
	
}
