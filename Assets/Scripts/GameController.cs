using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class GameController : MonoBehaviour {

	public Text leftText;
	public Player pl;
	public Score sc;
	public int ind;
	public CamPos cam;

	public GameObject gameoverText;
	public GameObject scoreText;
	public Text scText;
	public GameObject hscoreText;
	public Text hscText;
	public GameObject restartButton;
	public GameObject gameoverImage;
	public GameObject menuButton;

	public GameObject StartBackground;
	public GameObject StartImage;
	public GameObject StartText;

	public int limit;
	public float distLeft;
	int limitCounter;
	public bool gameRunning;
	public bool dead;
	public float score;
	public bool cp;
	bool start;
	int totalDistance;
	bool firstGame = true;

	public Text highScoreText;
	public int highScore0;

	string highScoreKey0 = "HighScore0";
		
	// Use this for initialization
	void Start () {
		ind = 0;
		highScore0 = PlayerPrefs.GetInt(highScoreKey0, 0);
		totalDistance = PlayerPrefs.GetInt ("total", 0);
		dead = false;
		start = true;
		//gameRunning = true;
		distLeft = 500;
		limitCounter = 0;
		score = 0;
		pl.speed = 15;
		cam.speed = 15;
		sc.score = 0;
		limit =	(int)distLeft;
		cp = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(gameRunning)
		{
			distLeft-= Time.deltaTime*20;
			leftText.text = "Distance Left: " + (int) distLeft;
		}
		else
			if(start)
			{
				#if UNITY_ANDROID && !UNITY_EDITOR
				
				if (Input.touchCount > 0)
				{
					gameRunning = true;
					if(firstGame)
					{
						Social.ReportProgress("CgkInuaLgr8eEAIQAg", 100.0f, (bool success) => {
						});
						firstGame = false;
					}
					StartBackground.SetActive(false);
					StartImage.SetActive(false);
					StartText.SetActive(false);
					StartCoroutine (game ());
				}

				
				#endif
				
				#if UNITY_EDITOR
				
				if (Input.GetKeyDown (KeyCode.Space))
				{
					gameRunning = true;
					StartBackground.SetActive(false);
					StartImage.SetActive(false);
					StartText.SetActive(false);
					StartCoroutine (game ());
				}

				#endif
			}
	}

	IEnumerator game()
	{
		while(gameRunning){
			if(score<limit){
				if(dead)
				{
					yield return new WaitForSeconds (0.01f);
					gameRunning = false;
					cam.move=true;
					start = false;
					if(score>=highScore0){
						highScore0 = (int)score;
					}
					scText.text = "Your Score: " + (int)score;
					hscText.text = "Highscore: " + highScore0;
					gameoverImage.SetActive(true);
					gameoverText.SetActive(true);
					scoreText.SetActive(true);
					hscoreText.SetActive(true);
					restartButton.SetActive(true);
					menuButton.SetActive(true);
					totalDistance += (int)score;
					Social.ReportScore((int)score, "CgkInuaLgr8eEAIQAQ", (bool success) => {
						});
					if(totalDistance>=5000)
						Social.ReportProgress("CgkInuaLgr8eEAIQCA", 100.0f, (bool success) => {
						});
					if(score>=500)
						Social.ReportProgress("CgkInuaLgr8eEAIQBA", 100.0f, (bool success) => {
						});
					if(score>=1000)
						Social.ReportProgress("CgkInuaLgr8eEAIQBQ", 100.0f, (bool success) => {
						});
					if(score>=1500)
						Social.ReportProgress("CgkInuaLgr8eEAIQBg", 100.0f, (bool success) => {
						});
					PlayerPrefs.SetInt ("total",totalDistance);
					PlayerPrefs.SetInt (highScoreKey0, highScore0);
					PlayerPrefs.Save ();
				}
				else
				{
					yield return new WaitForSeconds (0.01f);
				}
			}
			else
			{
				limitCounter++;
				distLeft = 625;
				limit=((int) score) +(int)distLeft;
				cp = true;
				ind+=1;
				if(ind>6)
					ind=0;
				pl.speed += 3;
				cam.speed += 3;
			}
		}
	}	
}
