using UnityEngine;
using System.Collections;

public class Restart : MonoBehaviour {

	public void restartGame () {
		Application.LoadLevel (Application.loadedLevel);
	}
	
}
