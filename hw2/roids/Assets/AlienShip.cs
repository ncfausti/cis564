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
	public float bulletRate;
	public float bulletHeading;

	// Use this for initialization
	void Start () {
		// Vector3 default initializes all components to 0.0f forceVector.x = 1.0f;

		forceVector.x = gameObject.transform.position.x > 0 ? 3.0f : -3.0f;
		Quaternion rot = Quaternion.Euler(new Vector3(0,180,0));
		transform.rotation = rot;

		rotationSpeed = 4.0f;
		timeToWaitBetweenShots = .25f;  // 1/4 second
		timeInvincible = 3.0f;
		isInvincible = true;
		timeAlive = 5.0f;
		moveLimit = .5f;
		goDownLimit = moveLimit;
		goUpLimit = moveLimit;

		bulletRate = .5f;
		
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
		if ( !collider.tag.Contains("Wall") && collider.tag != "Asteroids" && collider.tag != "AlienBullet") {
			
			Debug.Log (collider.tag);
			Debug.Log ("ALIEN  **   *** *** Ship got hit by my bullet");
			Destroy(collider);
		}
	}
	
	public void Die(){
			Destroy(gameObject);
	}
	
	//void OnCollisionEnter(Collision collision) {
	//	Debug.Log ("Collided with: " + collision.collider.tag);
	//	Destroy (gameObject);
	//}
	
	// Update is called once per frame
	void Update () {

		timer += Time.deltaTime;
		if (timer > bulletRate) {
			timer = 0;

		// Lock y plane to 0 for debugging until I implement ship.die()
		
			Debug.Log("GameObject name: " + gameObject.name);
		Vector3 spawnPos = gameObject.transform.position;
		
		spawnPos.x += .25f * Mathf.Cos(rotation * Mathf.PI/180);
		spawnPos.z -= .25f * Mathf.Sin(rotation * Mathf.PI/180);
		
		// instantiate the Bullet
		GameObject obj = Instantiate(bullet, spawnPos, Quaternion.identity) as GameObject;

		// get the Bullet Script Component of the new Bullet instance Bullet 
		AlienBullet b = obj.GetComponent<AlienBullet>();
		
		// set the direction the Bullet will travel in
		
			bulletHeading = Random.Range(30, 150);
		Quaternion rot = Quaternion.Euler(new Vector3(0,bulletHeading,0));
		b.heading = rot;


		Debug.Log ("FIRE ALIEN BULLET");
		}
	}
}


