using UnityEngine;
using System.Collections;

public class CamPos : MonoBehaviour {
	public GameObject player;
	public float speed;
	public GameController gm;
	public bool move;

	void Start()
	{
		move = false;
	}

	void Update()
	{
		if(gm.gameRunning || move)
			transform.Translate (Vector3.right * Time.deltaTime * speed);
	}
	

}
