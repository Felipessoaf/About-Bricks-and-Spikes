using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class Player : MonoBehaviour {

	public float speed;
	public float upSpeed;
	public GameController gm;
	public bool canJump = true;
	public bool grounded = true;
	public Animator anim;
	bool firstSpike = true;
	bool firstBrick = true;

	float upVel = 1000; 
	Touch touch;

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "ceiling")
		{
			gm.dead = true;
			if(firstSpike)
			{
				Social.ReportProgress("CgkInuaLgr8eEAIQAw", 100.0f, (bool success) => {
				});
				firstSpike = false;
			}
		}
		if (other.gameObject.tag == "obstacle")
		{
			gm.dead = true;
			if(firstBrick)
			{
				Social.ReportProgress("CgkInuaLgr8eEAIQBw", 100.0f, (bool success) => {
				});
				firstBrick = false;
			}
		}
		if (other.gameObject.tag == "ground")
		{
			grounded = true;
			anim.SetBool("grounded",true);
			canJump = true;
		}
	}

	void OnCollisionExit2D(Collision2D other1)
	{
		if (other1.gameObject.tag == "ground")
			grounded = false;
			anim.SetBool("grounded",false);
	}

	// Use this for initialization
	void Start () {
		canJump = true;
		Physics2D.IgnoreLayerCollision (8, 9);
		upSpeed = upVel;
	}
	
	// Update is called once per frame
	void Update () {

		if (gm.gameRunning) {
			transform.Translate (Vector3.right * Time.deltaTime * speed);
		
			#if UNITY_ANDROID && !UNITY_EDITOR

			if(canJump)
			{
				if (Input.touchCount > 0)
				{
					touch = Input.touches[0];
					if (touch.phase == TouchPhase.Began) {
						gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0f, upSpeed));
						upSpeed = 85;
					}
					if (touch.phase == TouchPhase.Stationary) {
						if(upSpeed==1000)
							upSpeed=0;
						gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0f, upSpeed));
						upSpeed -= 4f;
						if (upSpeed < 5)
							upSpeed = 5;
					} 
					if(touch.phase == TouchPhase.Ended)
					{
						upSpeed = upVel;
						if(!grounded)
							canJump = false;
					}
				}
			}

			#endif

			#if UNITY_EDITOR

			if(canJump)
			{
				if (Input.GetKeyDown (KeyCode.Space)) {
					gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0f, upSpeed));
					upSpeed = 85;
				}
				if (Input.GetKey (KeyCode.Space)) {
					if(upSpeed==1000)
						upSpeed=0;
					gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0f, upSpeed));
					upSpeed -= 4f;
					if (upSpeed < 5)
						upSpeed = 5;
					} 
				if(Input.GetKeyUp (KeyCode.Space))
				{
					upSpeed = upVel;
					if(!grounded)
						canJump = false;
				}
			}

			#endif
		}
	}
}
