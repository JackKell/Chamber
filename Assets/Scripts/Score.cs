using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	public float score = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		score += Time.deltaTime;
	}
}
