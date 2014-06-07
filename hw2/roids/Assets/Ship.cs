﻿using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour {

	// some public variables that can be used to tune the Ship's movement

	public Vector3 forceVector;
	public float rotationSpeed;
	public float rotation;
	public GameObject bullet; // the GameObject to spawn

	// Use this for initialization
	void Start () {
		// Vector3 default initializes all components to 0.0f forceVector.x = 1.0f;
		forceVector.x = 5.0f;
		rotationSpeed = 4.0f;
	}

	// forced changes to rigid body physics parameters should be done through the FixedUpdate() method, not the Update() method
	void FixedUpdate()
	{
		// force thruster
		if( Input.GetAxisRaw("Vertical") > 0 )
		{
			gameObject.rigidbody.AddRelativeForce(forceVector);
		}
		if( Input.GetAxisRaw("Horizontal") > 0 )
		{
			rotation += rotationSpeed;
			Quaternion rot = Quaternion.Euler(new Vector3(0,rotation,0));
			gameObject.rigidbody.MoveRotation(rot); 
			//gameObject.transform.Rotate(0, 2.0f, 0.0f );
		}
		else if( Input.GetAxisRaw("Horizontal") < 0 ) {
			rotation -= rotationSpeed;
			Quaternion rot = Quaternion.Euler(new Vector3(0,rotation,0));
			gameObject.rigidbody.MoveRotation(rot); 
			//gameObject.transform.Rotate(0, -2.0f, 0.0f );
		}
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1"))
		{
			/* we don’t want to spawn a Bullet inside our ship, so some Simple trigonometry is done here to spawn the bullet at the tip of where the ship is pointed.
*/
			Vector3 spawnPos = gameObject.transform.position;

			spawnPos.x += 1.5f * Mathf.Cos(rotation * Mathf.PI/180);
			spawnPos.z -= 1.5f * Mathf.Sin(rotation * Mathf.PI/180);

			// instantiate the Bullet
			GameObject obj = Instantiate(bullet, spawnPos, Quaternion.identity) as GameObject;

			// get the Bullet Script Component of the new Bullet instance Bullet 
			Bullet b = obj.GetComponent<Bullet>();

			// set the direction the Bullet will travel in
			Quaternion rot = Quaternion.Euler(new Vector3(0,rotation,0));
			
			b.heading = rot;
			Debug.Log ("Fire! " + rotation);
			
		}
	}
}


