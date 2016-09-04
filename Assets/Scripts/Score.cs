using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {

	public Text scoretext;
	public GameController gm;
	public float score;

	// Update is called once per frame
	void Update () {
		if (gm.gameRunning) {
			score += Time.deltaTime * 20;
			scoretext.text = "Total Distance: " + (int)score;
			gm.score = score;
		}
	}
}
