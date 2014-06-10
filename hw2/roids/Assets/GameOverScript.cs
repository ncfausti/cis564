using UnityEngine;
using System.Collections;

public class GameOverScript : MonoBehaviour {


	public GUIText first;
	public GUIText second;
	public GUIText third;

	public GameObject globalObj;


	// Use this for initialization
	void Start () {

//		globalObj = GameObject.Find("GlobalObject");
//		Global g = globalObj.GetComponent<Global>();
//
//		first.text = g.topScore.ToString();
//		second.text = g.secondTopScore.ToString();
//		third.text = g.thirdTopScore.ToString();
//		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		GUILayout.BeginArea (new Rect(10, Screen.height / 2 + 100, Screen.width -10, 200));
		
		// Load the main scene
		// The scene needs to be added into build setting to be loaded!




		/*
		if (GUILayout.Button("New Game")) {
			Application.LoadLevel("GameplayScene");		
		}
		
		if (GUILayout.Button ("High score")) {
			Debug.Log ("You should implement a high score screen.");	
		}
		
		if (GUILayout.Button ("Exit")) {
			Application.Quit();
			Debug.Log ("Application.Quit() only works in build, not in editor");
		}
		*/
		GUILayout.EndArea ();
		
	}
}
