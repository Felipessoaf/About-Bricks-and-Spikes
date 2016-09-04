using UnityEngine;
using System.Collections;

public class MoveCloser : MonoBehaviour {

	public GameController gm;
	public float speed;
	public float teto;

	public bool cp;

	void Start()
	{
		cp = false;
		gm = GameObject.Find ("GameController").GetComponent<GameController> ();
	}

	void Update () {
		if(gm.gameRunning)
		{
			transform.Translate(Vector3.down * Time.deltaTime * speed);
			if(gm.cp)
				cp=true;
			if(cp==true && transform.position.y<26)
			{
				transform.Translate(Vector3.down * Time.deltaTime * speed * (-5));
				teto = gm.distLeft;
			}
			else
			{
				cp = false;
				gm.cp = false;
			}
		}
	}
}
