using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject player1, player2;

	// Use this for initialization
	void Start () {
		SpawnPlayers();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void SpawnPlayers() {
		Instantiate (player1, new Vector3(-2.5f, 1.01f), Quaternion.identity);
		Instantiate (player2, Vector3.zero, Quaternion.identity);
	}
}
