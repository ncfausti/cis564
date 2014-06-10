using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour {

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
	

	// Use this for initialization
	void Start () {
		// Vector3 default initializes all components to 0.0f forceVector.x = 1.0f;
		forceVector.x = 5.0f;
		rotationSpeed = 4.0f;
		timeToWaitBetweenShots = .25f;  // 1/4 second
		timeInvincible = 3.0f;
		isInvincible = true;

	}

	// forced changes to rigid body physics parameters should be done through the FixedUpdate() method, not the Update() method
	void FixedUpdate()
	{
		timeInvincible -= Time.deltaTime;

		if(timeInvincible <= 0.0f) {
			isInvincible = false;
		//	gameObject.collider.isTrigger = false;
		}

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

	void OnTriggerEnter(Collider collider) {
		if ( (collider.tag != "Bullet") && !collider.tag.Contains("Wall") ) {

				Debug.Log (collider.tag);
				Debug.Log ("Ship got hit");
				
				if(!isInvincible)
					Die();
				}
		}

	public void Die(){
		GameObject obj = GameObject.Find("GlobalObject");
		Global g = obj.GetComponent<Global>();
		g.livesLeft--;

		if (g.livesLeft < 0) {
			// gameover

			Debug.Log ("Bringing up high score/game over menu now");
				} else {
			g.respawnCountdown = 3.0f;
			g.justSpawned = false;
			Destroy(gameObject);
							
		}
	}

	//void OnCollisionEnter(Collision collision) {
	//	Debug.Log ("Collided with: " + collision.collider.tag);
	//	Destroy (gameObject);
	//}

	// Update is called once per frame
	void Update () {

		// Lock y plane to 0 for debugging until I implement ship.die()
		transform.position = new Vector3(transform.position.x, 0, transform.position.z);



		
		if(Input.GetButtonDown("Fire1") && ( (Time.time - timeAtLastBulletFire) > timeToWaitBetweenShots ) )
	
		{
			/* we don’t want to spawn a Bullet inside our ship, so some Simple trigonometry is done here to spawn the bullet at the tip of where the ship is pointed.
*/
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
	}
}


