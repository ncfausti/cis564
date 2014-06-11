using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour {

	public GameObject deathExplosion;
	public int pointValue;
	public AudioClip deathKnell;
	public Vector3 speed;
	public Quaternion heading;
	public bool isFragment;
	//float lockPosition = 0;



	// Use this for initialization
	void Start () {
		pointValue = 10;
		speed.x = 200.0f;

		heading.z = Random.Range (-180.0f, 180.0f);
		heading.x = Random.Range(0.0f, 360.0f);
	
		// Debugging, go right
	//	heading.z = 0.0f;
	//	heading.x = 0.0f;
		



		// set the direction it will travel in
		gameObject.rigidbody.MoveRotation(heading);
		gameObject.rigidbody.AddRelativeForce (speed);
		
	}
	
	// Update is called once per frame
	void Update () {
		// Lock asteroids to y = 0 plane
		transform.position = new Vector3(transform.position.x, 0, transform.position.z);
		transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
	}

	public void Die(){
		// Destroy removes the gameObject from the scene 
		// and marks it for garbage collection

		// Debug.Log("OH NO I AM DYING");

		/* all of Shuriken's particle effects by default use 
		 * the convention of Z being upwards, and XY being the 
		 * horizontal plane. as a result, since we are looking 
		 * down the Y axis, we rotate the particle system so 
		 * that it flys in the right way.
		 */
		//AudioSource.PlayClipAtPoint(deathKnell, gameObject.transform.position );

		Instantiate (deathExplosion, gameObject.transform.position, 
		             Quaternion.AngleAxis (-90, Vector3.right) );

		GameObject obj = GameObject.Find("GlobalObject");
		Global g = obj.GetComponent<Global>();
		g.score += pointValue;
		g.totalAsteroids -= 1;
		
		Destroy (gameObject);

	//	Debug.Log (g.totalAsteroids);

	}
}
