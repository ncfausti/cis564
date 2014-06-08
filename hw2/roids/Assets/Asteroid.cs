using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour {

	public GameObject deathExplosion;
	public int pointValue;
	public AudioClip deathKnell;
	public Vector3 speed;
	public Quaternion heading;
	public bool isFragment;

	// Use this for initialization
	void Start () {
		pointValue = 10;
		speed.x = 50.0f;

		heading.z = Random.Range (-180.0f, 180.0f);
		heading.x = Random.Range(0.0f, 360.0f);

		// set the direction it will travel in
		gameObject.rigidbody.MoveRotation(heading);
		gameObject.rigidbody.AddRelativeForce (speed);
		
	}
	
	// Update is called once per frame
	void Update () {
		
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

		// If larger than some size instantiate AsteroidCluster/3 smaller asteroids
		Asteroid roid = gameObject.GetComponent< Asteroid >();
		Vector3 cp = gameObject.transform.position;


		//Debug.Log ("xyz " + cp[0] +"|"+cp[1]+"|"+ cp[2]);

		for(int i = 0; i < 3; i++){
			Debug.Log ("COORDS: " + cp.x + " | " + cp.y + " | " + cp.z);
			Instantiate (roid, 
			             new Vector3(cp.x + (2.0f * i),cp.y, cp.z  + (2.0f * i))
				, Quaternion.identity);
				
		//	roid.transform.localScale.x = .25f;
		//	roid.transform.localScale.z = .25f;
				
			//Debug.Log (roid.ToString());
		}


		// end three asteroid instantiation


		Destroy (gameObject);

	}
}
