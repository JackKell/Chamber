using UnityEngine;
using System.Collections;

public class PanelToggle : MonoBehaviour {

	public bool isActive = true;
	public float alpha = .5f;
	public float delta = .01f;

	private BoxCollider collider;
	private SpriteRenderer renderer;
	private float targetAlpha = 1.0f;

	private float r;
	private float g;
	private float b;
	private float a;

	// Use this for initialization
	public void Initialize () {
		collider = GetComponent<BoxCollider> ();
		renderer = GetComponent<SpriteRenderer> ();
		r = renderer.color.r;
		g = renderer.color.g;
		b = renderer.color.b;
		a = renderer.color.a;

		if(isActive == false) {
			deactivate();
		}
	}
	
	// Update is called once per frame
	void Update () {
		r = renderer.color.r;
		g = renderer.color.g;
		b = renderer.color.b;
		a = renderer.color.a;
		lerpAlpha (targetAlpha);

		collider.enabled = isActive;
	}

	public void lerpAlpha(float targetAlpha) {
		a = Mathf.Lerp (a, targetAlpha, delta);
		renderer.color = new Color (r, g, b, a);
	}
	
	public void toggle() {
		if (isActive) {
			deactivate ();
		}
		else {
			activate();
		}
	}
	
	public void activate(bool lerp = true) {
		isActive = true;
		targetAlpha = 1.0f;
		renderer.sortingOrder = 1;

		if (lerp == false) {
			renderer.color = new Color (r, g, b, targetAlpha);
		}
	}
	
	public void deactivate(bool lerp = true) {
		isActive = false;
		targetAlpha = this.alpha;
		Debug.Log (null == renderer);
		renderer.sortingOrder = 0;

		if(lerp == false) {
			renderer.color = new Color (r, g, b, targetAlpha);
		}
	}
}
