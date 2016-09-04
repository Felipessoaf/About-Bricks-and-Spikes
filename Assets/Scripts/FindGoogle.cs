using UnityEngine;
using System.Collections;

public class FindGoogle : MonoBehaviour {

	GooglePlayControlador gg;

	// Use this for initialization
	void Start () {
		gg = GameObject.FindObjectOfType<GooglePlayControlador>();
	}
	
	public void getAchievements()
	{
		gg.achievementsMenu ();
	}

	public void getLeaderboard()
	{
		gg.leaderboardMenu ();
	}
}
