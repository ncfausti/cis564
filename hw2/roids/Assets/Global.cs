using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Global : MonoBehaviour {

	public GameObject objToSpawn;
	public GameObject smallAsteroid;
	public GameObject ship;
	public GameObject alienShip;
	public GameObject mainCamera;
	public GameObject bullet;
	public GameObject alienBullet;

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
	public float alienTimer;
	public bool prevGamePlayed;
	public  int topScore = 0;
	public string topPlayer = "";
	public int alienSpawnPeriod;
	public  int secondTopScore = 0;
	public string secondPlayer = "";

	public Camera cam1;
	public Camera cam2;

	public  int thirdTopScore = 0;
	public string thirdPlayer = "";

	public  Dictionary<string, int> scores = new Dictionary<string,int>();

	
	public void trackScores(string player, int score) {

		int dupPlayer = 0;

		// if player name already in scores dictionary, append number to end, eg. nick, nick1, nick2
		bool containsKey = scores.ContainsKey (player);

		while (containsKey) {
			dupPlayer += 1;
			player = player + dupPlayer.ToString();
			containsKey = scores.ContainsKey(player);
		}

		scores.Add(player, score);
		
	}



	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(gameObject);

		cam1.enabled = true;
		cam2.enabled = false;


		score = 0;
		timer = 0;
		spawnPeriod = 2.0f;
		numberSpawnedEachPeriod = 15;
		currentLevel = 0;
		livesLeft = 3	;
		respawnCountdown = 4.0f;
		width = Camera.main.GetScreenWidth ();
		height = Camera.main.GetScreenHeight ();
		spawnShip();
		justSpawned = true;
		spawnedAlien = false;
		alienSpawnPeriod = 15;
		alienTimer = 0.0f;
		totalAsteroids = 0;



		/*
              So here's a design point to consider:
			- is the gameplay constrained by the screen size in any particular way?
			That might sound like a weird question, but it's actually a significant one for asteroids if you want the game to play like Asteroids on arbitrary screen dimensions. It's mostly here for pedagogical reasons, though. The value that actually matters here is the depth value. Since the gameplay takes place on a XZ- plane, and we're looking down the Y-axis,
			we're mainly interested in what the Y value of 0 maps to in the camera's depth.
		*/
		originInScreenCoords =
			Camera.main.WorldToScreenPoint(new Vector3(0,0,0));

		startNewLevel(1);
		//spawnAlien();

	}
	// Update is called once per frame
	void Update () {
				timer += Time.deltaTime;
				if (timer > spawnPeriod) {
						timer = 0;
				}

		alienTimer += Time.deltaTime;
		if(alienTimer > alienSpawnPeriod){
			spawnAlien();
			alienTimer = 0;
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

		if(Input.GetButtonDown("C")) {
			cam1.enabled = !cam1.enabled;
			cam2.enabled = !cam2.enabled;
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
		Instantiate (ship, new Vector3 (-10, 0, -10), Quaternion.identity);
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

}






