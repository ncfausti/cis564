using UnityEngine;
using System.Collections;

public class ScoreUI : MonoBehaviour {

	Global globalObj;
	GUIText scoreText;

	// Use this for initialization
	void Start () {
		GameObject g = GameObject.Find ("GlobalObject");
		globalObj = g.GetComponent< Global >(); 
		int lastScore = 0;
		scoreText = gameObject.GetComponent<GUIText>();

		
	}
	
	// Update is called once per frame
	void Update () {

		scoreText.text = globalObj.score.ToString();
	}
}
