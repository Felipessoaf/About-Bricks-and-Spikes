using UnityEngine;
using System.Collections;

public class ChangeColor : MonoBehaviour {

	public GameController gm;
	public Color[] colors;

	public bool cp;
	
	void Start()
	{
		cp = true;
		gm = GameObject.Find ("GameController").GetComponent<GameController> ();
		GetComponent<SpriteRenderer>().color = colors[gm.ind];
	}
	
	void Update () {
		if(gm.gameRunning)
		{
			if(gm.cp && cp)
			{
				GetComponent<SpriteRenderer>().color = colors[gm.ind];
				cp=false;
			}
			if(!gm.cp)
				cp=true;
		}
	}
}
