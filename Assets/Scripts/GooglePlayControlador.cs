using UnityEngine;
using System.Collections;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class GooglePlayControlador : MonoBehaviour {

	private static GooglePlayControlador _instance;
	
	public static GooglePlayControlador instance
	{
		get
		{
			if(_instance == null)
			{
				_instance = GameObject.FindObjectOfType<GooglePlayControlador>();
				
				//Tell unity not to destroy this object when loading a new scene!
				DontDestroyOnLoad(_instance.gameObject);
			}
			
			return _instance;
		}
	}
	
	void Awake() 
	{
		if(_instance == null)
		{
			//If I am the first instance, make me the Singleton
			_instance = this;
			DontDestroyOnLoad(this);
		}
		else
		{
			//If a Singleton already exists and you find
			//another reference in scene, destroy it!
			if(this != _instance)
				Destroy(this.gameObject);
		}
	}
	// Use this for initialization
	void Start () {
		PlayGamesPlatform.Activate();
		Social.localUser.Authenticate((bool success) => {
		});
	}

	public void leaderboardMenu()
	{
		Social.ShowLeaderboardUI();
	}

	public void achievementsMenu()
	{
		Social.ShowAchievementsUI();
	}
}
