using UnityEngine;
using System.Collections;

public class LivesUI : MonoBehaviour {
	
	Global globalObj;
	GUIText livesText;
	
	// Use this for initialization
	void Start () {
		GameObject g = GameObject.Find ("GlobalObject");
		globalObj = g.GetComponent< Global >(); 
		int lives = 3;
		livesText = gameObject.GetComponent<GUIText>();
		
		
	}
	
	// Update is called once per frame
	void Update () {
		livesText.text = "LIVES " + globalObj.livesLeft.ToString();	
	}

}
