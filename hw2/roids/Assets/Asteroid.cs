using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour {

	public GameObject deathExplosion;
	public int pointValue;
	public AudioClip deathKnell;

	// Use this for initialization
	void Start () {
		pointValue = 10;
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
		
		Destroy (gameObject);

	}
}
