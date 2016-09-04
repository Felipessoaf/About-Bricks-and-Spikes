using UnityEngine;
using System.Collections;

public class SpawnObstacle : MonoBehaviour {

	public GameObject player;
	public GameObject[] obstacles;
	public bool first;

	// Use this for initialization
	void Start () {
		if (!first) {
			GameObject obstacle1 = obstacles [Random.Range (0, obstacles.Length)];
			Vector3 spawnPosition1 = new Vector3 (-20.0f + transform.position.x, transform.position.y + obstacle1.GetComponent<Collider2D> ().bounds.size.y, 0.0f);//(Random.Range (-30.0f + transform.position.x, -15.0f + transform.position.x), transform.position.y + obstacle1.GetComponent<Collider2D> ().bounds.size.y, 0.0f);
			Instantiate (obstacle1, spawnPosition1, Quaternion.identity);

			GameObject obstacle2 = obstacles [Random.Range (0, obstacles.Length)];
			Vector3 spawnPosition2 = new Vector3 (0.0f + transform.position.x, transform.position.y + obstacle2.GetComponent<Collider2D> ().bounds.size.y, 0.0f);//(Random.Range (-15.0f + transform.position.x, 0.0f + transform.position.x), transform.position.y + obstacle2.GetComponent<Collider2D> ().bounds.size.y, 0.0f);
			Instantiate (obstacle2, spawnPosition2, Quaternion.identity);

			GameObject obstacle3 = obstacles [Random.Range (0, obstacles.Length)];
			Vector3 spawnPosition3 = new Vector3 (20.0f + transform.position.x, transform.position.y + obstacle2.GetComponent<Collider2D> ().bounds.size.y, 0.0f);//(Random.Range (0.0f + transform.position.x, 15.0f + transform.position.x), transform.position.y + obstacle2.GetComponent<Collider2D> ().bounds.size.y, 0.0f);
			Instantiate (obstacle3, spawnPosition3, Quaternion.identity);

			/*GameObject obstacle4 = obstacles [Random.Range (0, obstacles.Length)];
			Vector3 spawnPosition4 = new Vector3 (Random.Range (15.0f + transform.position.x, 30.0f + transform.position.x), transform.position.y + obstacle2.GetComponent<Collider2D> ().bounds.size.y, 0.0f);
			Instantiate (obstacle4, spawnPosition4, Quaternion.identity);*/
		}
		first = false;
	}
	

}
