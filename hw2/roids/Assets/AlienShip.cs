using UnityEngine;
using System.Collections;

public class AlienShip : MonoBehaviour {
	
	// some public variables that can be used to tune the Ship's movement
	
	public Vector3 forceVector;
	public float rotationSpeed;
	public float rotation;
	public GameObject bullet; // the GameObject to spawn

	public float timer;
	public float timeAtLastBulletFire;
	public float timeToWaitBetweenShots;
	public float timeInvincible;
	public bool isInvincible;
	public float timeAlive;
	public float vPos;
	public float vDirection;
	public float goDownLimit;
	public float goUpLimit;
	public float moveLimit;

	// Use this for initialization
	void Start () {
		// Vector3 default initializes all components to 0.0f forceVector.x = 1.0f;

		forceVector.x = gameObject.transform.position.x > 0 ? -3.0f : 3.0f;

		rotationSpeed = 4.0f;
		timeToWaitBetweenShots = .25f;  // 1/4 second
		timeInvincible = 3.0f;
		isInvincible = true;
		timeAlive = 5.0f;
		moveLimit = .5f;
		goDownLimit = moveLimit;
		goUpLimit = moveLimit;

	}
	
	// forced changes to rigid body physics parameters should be done through the FixedUpdate() method, not the Update() method
	void FixedUpdate()
	{
		transform.position = new Vector3(transform.position.x, 0, transform.position.z);
		
		timeAlive -= Time.deltaTime;

		if (timeAlive < 0) {
			Destroy(gameObject);		
		}

		// move back and forth and up and down and shoot bullets

		gameObject.rigidbody.AddRelativeForce(forceVector);

			if (goDownLimit > 0) {
					// move down and subtract time from goDownLimit
					gameObject.transform.position = new Vector3(transform.position.x, 0, transform.position.z -0.25f);
					goDownLimit -= Time.deltaTime;
			
			}
			if (goUpLimit > 0 && goDownLimit < 0) {
						//move up and subtract time from goUpLimit
					gameObject.transform.position = new Vector3(transform.position.x, 0, transform.position.z + 0.25f);
					goUpLimit -= Time.deltaTime;


			}
			// back at begining vertical position
			// so we want to reset goUpLimit and goDownLimit
			if (goUpLimit < 0 && goDownLimit < 0) {
			goUpLimit = moveLimit;
			goDownLimit = moveLimit;
			}	
	}
	
	void OnTriggerEnter(Collider collider) {
		if ( !collider.tag.Contains("Wall") && collider.tag != "Asteroids" ) {
			
			Debug.Log (collider.tag);
			Debug.Log ("ALIEN  **   *** *** Ship got hit by my bullet");
			

				//Die();
		}
	}
	
	public void Die(){
	//	GameObject obj = GameObject.Find("GlobalObject");
	//		Global g = obj.GetComponent<Global>();
		//g.livesLeft -= 1;
		
	//	if (--g.livesLeft < 0) {
			// gameover
			// bring up high score/game over menu
	//	} else {
	//		g.respawnCountdown = 3.0f;
	//		g.justSpawned = false;
			Destroy(gameObject);
			

	}
	
	//void OnCollisionEnter(Collision collision) {
	//	Debug.Log ("Collided with: " + collision.collider.tag);
	//	Destroy (gameObject);
	//}
	
	// Update is called once per frame
	void Update () {
		
		// Lock y plane to 0 for debugging until I implement ship.die()

	//	Vector3 spawnPos = gameObject.transform.position;
		
	//	spawnPos.x += .25f * Mathf.Cos(rotation * Mathf.PI/180);
	//	spawnPos.z -= .25f * Mathf.Sin(rotation * Mathf.PI/180);
		
		// instantiate the Bullet
	//	GameObject obj = Instantiate(bullet, spawnPos, Quaternion.identity) as GameObject;

		// get the Bullet Script Component of the new Bullet instance Bullet 
		//Bullet b = obj.GetComponent<Bullet>();
		
		// set the direction the Bullet will travel in
	//	Quaternion rot = Quaternion.Euler(new Vector3(0,rotation,0));
	//	b.heading = rot;
		
		timeAtLastBulletFire = Time.time;

		/*
		
		if(Input.GetButtonDown("Fire1") && ( (Time.time - timeAtLastBulletFire) > timeToWaitBetweenShots ) )
			
		{
			// we don’t want to spawn a Bullet inside our ship, so some Simple trigonometry is done here to spawn the bullet at the tip of where the ship is pointed.

			Vector3 spawnPos = gameObject.transform.position;
			
			spawnPos.x += .25f * Mathf.Cos(rotation * Mathf.PI/180);
			spawnPos.z -= .25f * Mathf.Sin(rotation * Mathf.PI/180);
			
			// instantiate the Bullet
			GameObject obj = Instantiate(bullet, spawnPos, Quaternion.identity) as GameObject;
			
			// get the Bullet Script Component of the new Bullet instance Bullet 
			Bullet b = obj.GetComponent<Bullet>();
			
			// set the direction the Bullet will travel in
			Quaternion rot = Quaternion.Euler(new Vector3(0,rotation,0));
			b.heading = rot;
			
			timeAtLastBulletFire = Time.time;
			//	Debug.Log (Time.time);
			//			Debug.Log ("Fire! " + rotation);
			
		}
		*/
	}
}


