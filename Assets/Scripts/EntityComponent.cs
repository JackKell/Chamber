using UnityEngine;
using System.Collections;

public class EntityComponent : MonoBehaviour {

	public bool isAlive;
	public int health = 0;

	// Use this for initialization
	void Start () {
		isAlive = true;
	}
	
	// Update is called once per frame
	void Update () {

		if (health <= 0) {
			kill();
		}

		if(isAlive == false) {
			destroy();
		}
	}

	public void damage(int damage) {
		health -= damage;
	}

	public void kill() {
		isAlive = false;
	}

	public void destroy() {
		Destroy(this.gameObject);
	}
}
