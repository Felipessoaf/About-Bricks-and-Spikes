using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HighscoresControl : MonoBehaviour {
	
	public GameObject highScoresText;
	public GameObject highScore0T;
	public GameObject highScore1T;
	public GameObject highScore2T;
	public GameObject highScore3T;
	public GameObject highScore4T;
	public GameObject highScoreImage;
	public GameObject mainMenuButton;
	
	public Text highScore0Text;
	public Text highScore1Text;
	public Text highScore2Text;
	public Text highScore3Text;
	public Text highScore4Text;
	
	public int highScore0;
	public int highScore1;
	public int highScore2;
	public int highScore3;
	public int highScore4;
	
	string highScoreKey0 = "HighScore0";
	string highScoreKey1 = "HighScore1"; 
	string highScoreKey2 = "HighScore2";
	string highScoreKey3 = "HighScore3";
	string highScoreKey4 = "HighScore4";
	
	// Use this for initialization
	void Start () {
		highScore0 = PlayerPrefs.GetInt(highScoreKey0, 0);
		highScore1 = PlayerPrefs.GetInt(highScoreKey1, 0);
		highScore2 = PlayerPrefs.GetInt(highScoreKey2, 0);
		highScore3 = PlayerPrefs.GetInt(highScoreKey3, 0);
		highScore4 = PlayerPrefs.GetInt(highScoreKey4, 0);
		
		highScore0Text.text = "1. " + highScore0;
		highScore1Text.text = "2. " + highScore1;
		highScore2Text.text = "3. " + highScore2;
		highScore3Text.text = "4. " + highScore3;
		highScore4Text.text = "5. " + highScore4;
	}
	
	public void HighscoreMenu ()
	{
		highScoresText.SetActive (true);
		highScore0T.SetActive (true);
		highScore1T.SetActive (true);
		highScore2T.SetActive (true);
		highScore3T.SetActive (true);
		highScore4T.SetActive (true);
		highScoreImage.SetActive (true);
		mainMenuButton.SetActive (true);
	}
	
	public void MainMenu ()
	{
		highScoresText.SetActive (false);
		highScore0T.SetActive (false);
		highScore1T.SetActive (false);
		highScore2T.SetActive (false);
		highScore3T.SetActive (false);
		highScore4T.SetActive (false);
		highScoreImage.SetActive (false);
		mainMenuButton.SetActive (false);
	}
	
	
}
