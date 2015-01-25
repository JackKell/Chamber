using UnityEngine;
using System.Collections;

public class SawBlade : MonoBehaviour {

	public float xSpeed = 0;
	public float rotSpeed = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.forward * rotSpeed * Time.deltaTime, Space.Self);
		transform.Translate (new Vector2(xSpeed * Time.deltaTime, 0), Space.World);
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.tag == "Player") {
			Debug.Log("Player Dies");
		}
	}
}
