using UnityEngine;
using System.Collections;

public class LevelUI : MonoBehaviour {

	Global globalObj;
	GUIText levelText;

	// Use this for initialization
	void Start () {
		GameObject g = GameObject.Find ("GlobalObject");
		globalObj = g.GetComponent< Global >(); 
		int lastScore = 0;
		levelText = gameObject.GetComponent<GUIText>();
		

	}
	
	// Update is called once per frame
	void Update () {
		levelText.text = "LEVEL " + globalObj.currentLevel.ToString();	
	}
}
