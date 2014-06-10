using UnityEngine;
using System.Collections;

public class Global : MonoBehaviour {

	public GameObject objToSpawn;
	public GameObject smallAsteroid;
	public GameObject ship;
	public GameObject alienShip;
	public GameObject mainCamera;

	public float timer;
	public float spawnPeriod;
	public int numberSpawnedEachPeriod;
	public Vector3 originInScreenCoords;
	public int score;
	public int currentLevel;
	public int totalAsteroids;
	public int livesLeft;
	public bool hasDied;
	public float width;
	public float height;
	public float respawnCountdown;
	public bool justSpawned;
	public bool spawnedAlien;
	public float alienTime;


	public  int topScore = 34500;
	public  int secondTopScore = 26130;
	public  int thirdTopScore = 14700;
	
	public void trackScores(int score) {
		if (score > topScore) 
			topScore = score;		
		
		if (score < topScore && score > secondTopScore)
			secondTopScore = score;		
		
		if (score < secondTopScore && score > thirdTopScore)
			thirdTopScore = score;
		
	}


	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(gameObject);

		score = 0;
		timer = 0;
		spawnPeriod = 2.0f;
		numberSpawnedEachPeriod = 15;
		currentLevel = 1;
		livesLeft = 3;
		respawnCountdown = 4.0f;
		width = Camera.main.GetScreenWidth ();
		height = Camera.main.GetScreenHeight ();
		spawnShip();
		justSpawned = true;
		spawnedAlien = false;
		alienTime = 4.0f;
		topScore = 38620;


		/*
              So here's a design point to consider:
			- is the gameplay constrained by the screen size in any particular way?
			That might sound like a weird question, but it's actually a significant one for asteroids if you want the game to play like Asteroids on arbitrary screen dimensions. It's mostly here for pedagogical reasons, though. The value that actually matters here is the depth value. Since the gameplay takes place on a XZ- plane, and we're looking down the Y-axis,
			we're mainly interested in what the Y value of 0 maps to in the camera's depth.
		*/
		originInScreenCoords =
			Camera.main.WorldToScreenPoint(new Vector3(0,0,0));

		startNewLevel(1);
		spawnAlien();

	}
	// Update is called once per frame
	void Update () {
				timer += Time.deltaTime;
				if (timer > spawnPeriod) {
						timer = 0;
				}
		// Respawn

		if (respawnCountdown < 4.0f)
				if (((respawnCountdown -= Time.deltaTime) < 0.0f) && !justSpawned) {
						spawnShip ();
						justSpawned = true;
				}

		// if all asteroids are gone, increment level and spawn "level" many asteroids
		if (totalAsteroids == 0) {

			startNewLevel (++currentLevel);
			}

		if(Input.GetButtonDown("Jump")) {
			Debug.Log ("Going to 3d view");

		}
	}

	void startNewLevel(int level) {

		// TODO: make ship invincible while spawning new asteroids



		for (int i = 0; i < level; i++) {

				float horizontalPos = Random.Range (0.0f, width);
				float verticalPos = Random.Range (0.0f, height);
	
				Instantiate (objToSpawn, Camera.main.ScreenToWorldPoint (
					new Vector3 (horizontalPos, verticalPos, originInScreenCoords.z)), Quaternion.identity);
				
				totalAsteroids += 1;
		}

	}

	void spawnAlien() {
		int direction = Random.Range (-10, 10) < 0 ? -1 : 1;

		float x = 15.0f * direction;

		// move left to right
		if (x < 0) {
				
		} 
		// move right to left
		else {
				
		
		}

		float y = 0;
		float z = 10.0f;
		Instantiate (alienShip, new Vector3 (x, y, z), Quaternion.identity);
		spawnedAlien = true;
	}

	 void spawnShip() {

		Debug.Log ("SPAWNING SHIPPPP!!!!!");
		Instantiate (ship, new Vector3 (0, 0, 0), Quaternion.identity);
	}

	public void spawnAsteroidPiecesAtPosition(Vector3 position) {
		Debug.Log ("SPAWNING ASTEROID PIECES");
		Debug.Log ("Position: " + position.ToString ());

		// Spawn three small asteroids
		for (int i = 0; i < 3; i++) {
			Vector3 newPos = new Vector3(position.x + (i*1), position.y + (i*1), position.z + (i*1) );
						Instantiate (smallAsteroid, newPos, Quaternion.identity);
			totalAsteroids += 1;
		}
	}

	public void trackTopScores(){
		// keep track of all top scores here


	}

}






