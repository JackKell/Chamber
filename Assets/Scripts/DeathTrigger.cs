using UnityEngine;
using System.Collections;

public class DeathTrigger : MonoBehaviour {

	public string tagName = "";

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider collider) {
		if(collider.tag == tagName) {
			EntityComponent entity = GetComponent<EntityComponent>();
			if(null == entity) {
				//Destroy (this.gameObject);
			}
			else {
				entity.isAlive = false;
			}
		}
	}
}
