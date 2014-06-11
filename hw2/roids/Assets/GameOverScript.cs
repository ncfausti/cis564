using UnityEngine;
using System.Collections;

public class GameOverScript : MonoBehaviour {


	public GUIText first;
	public GUIText second;
	public GUIText third;

	public string name;

	public GameObject globalObj;
	Global g;

	// Use this for initialization
	void Start () {

		globalObj = GameObject.Find("GlobalObject");
		g = globalObj.GetComponent<Global>();

		/*
		first.text = g.topPlayer + "hi  " + g.topScore.ToString();
		second.text = g.secondPlayer + "  " + g.secondTopScore.ToString();
		third.text = g.thirdPlayer + "  " + g.thirdTopScore.ToString();
		*/

		for (int i = 0; i < 10; i++) {
					
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI() {
		GUILayout.BeginArea (new Rect(10, Screen.height / 2 + 100, Screen.width -10, 200));

		name = GUI.TextField(new Rect(100, 100, 200, 20), name, 25);


		// Load the main scene
		// The scene needs to be added into build setting to be loaded!


		if (GUILayout.Button("New Game")) {

			// reinitialize new score variables
			g.livesLeft = 3;
			g.score = 0;
			g.timer = 0;

			Application.LoadLevel("GameplayScene");		
		}

		/*
		if (GUILayout.Button ("")) {
			//Debug.Log ("You should implement a high score screen.");	
		}
		*/
		if(GUILayout.Button("Save Score")){
			Global g = globalObj.GetComponent<Global>();
			g.scores.Add(name, g.score);
			Debug.Log("PLAYER " + name + " scored " + g.scores[name]  + " points");
		}



		if (GUILayout.Button ("Exit")) {
			Application.Quit();
			Debug.Log ("Application.Quit() only works in build, not in editor");
		}

		GUILayout.EndArea ();
		
	}
}
