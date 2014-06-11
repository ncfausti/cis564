using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class GameOverScript : MonoBehaviour {


	public GUIText highScores;

	public string name;
	private bool saveClicked = false;

	public GameObject globalObj;
	Global g;

	// Use this for initialization
	void Start () {

		/*
		first.text = g.topPlayer + "hi  " + g.topScore.ToString();
		second.text = g.secondPlayer + "  " + g.secondTopScore.ToString();
		third.text = g.thirdPlayer + "  " + g.thirdTopScore.ToString();
		*/

			displayScores ();
		

	}

	public void displayScores(){
		// list out top scores with player's names

		if (GameObject.Find ("GlobalObject") != null) {
						globalObj = GameObject.Find ("GlobalObject");
						g = globalObj.GetComponent<Global> ();

						List<KeyValuePair<string, int>> highScoresList = g.scores.ToList ();
		
						highScoresList.Sort (
			delegate(KeyValuePair<string, int> firstPair, KeyValuePair<string, int> nextPair) {
								return firstPair.Value.CompareTo (nextPair.Value);
						}
						);

						// for top three items in sorted dictionary create GUIText Objects and draw to screen with name + score
						// if there aren't three scores use _ _ _ _  -  0 as filler
		
						foreach (KeyValuePair<string, int> entry in highScoresList) {
								//GameObject go = new GameObject(entry.Key + entry.Value);
								//go.AddComponent(typeof(GUIText));
								//	Debug.Log (entry.Key + " | " + entry.Value.ToString());

								highScores.text += entry.Key + "   " + entry.Value.ToString () + "\n";

						}
		}
		
	}

	
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI() {
		GUILayout.BeginArea (new Rect(10, Screen.height / 2 + 100, Screen.width -10, 200));

		name = GUI.TextField(new Rect(400, 100, 200, 40), name, 25);


		// Load the main scene
		// The scene needs to be added into build setting to be loaded!


		if (GUILayout.Button("New Game")) {

			// reinitialize new score variables
			g.livesLeft = 3;
			g.score = 0;
			g.timer = 0;
			g.totalAsteroids = 1;
			g.currentLevel = 1;

			Application.LoadLevel("GameplayScene");		
		}

		/*
		if (GUILayout.Button ("")) {
			//Debug.Log ("You should implement a high score screen.");	
		}
		*/
		if (!saveClicked) {
						if (GUILayout.Button ("Save Score")) {
								saveClicked = true;
								Global g = globalObj.GetComponent<Global> ();
								g.trackScores (name, g.score);
								//	Debug.Log("PLAYER " + name + " scored " + g.scores[name]  + " points");
								//	Destroy(GUILayout.Button("Save Score"));

								displayScores ();
						}
				}



		if (GUILayout.Button ("Exit")) {
			Application.Quit();
			Debug.Log ("Application.Quit() only works in build, not in editor");
		}



		GUILayout.EndArea ();
		
	}
}
