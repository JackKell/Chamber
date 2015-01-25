using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Grid : MonoBehaviour {

	public List<GameObject> panels = new List<GameObject>();
	private int width = 18;
	private int height = 10;

	void Awake() {
		for(int i = 0; i < width * height; i++) {
			PanelToggle pt = panels[i].GetComponent<PanelToggle>();
			pt.Initialize();
		}
	}

	// Use this for initialization
	void Start () {
		startConfig();
		toggleCells (false, new Vector2 (9, 7), new Vector2 (9, 8), new Vector2 (9, 9), new Vector2 (9, 10));
	}

	// Update is called once per frame
	void Update () {
	
	}

	public void startConfig() {
		Debug.Log("StartConfig");
		for(int i = 0; i < width * height; i++) {
			PanelToggle pt = panels[i].GetComponent<PanelToggle>();
			pt.deactivate(false);
		}

		toggleRow (0, true, false);
		toggleRow (height - 1, true, false);

		toggleColumn (0, true, false);
		toggleColumn (width - 1, true, false);
	}

	public void toggleColumn(int colNumber, bool state, bool lerp = true) {
		for(int i = 0; i < height; i++) {
			PanelToggle pt = panels[colNumber + i * width].GetComponent<PanelToggle>();
			
			if(state)
				pt.activate(lerp);
			else
				pt.deactivate(lerp);
		}
	}

	public void toggleRow(int rowNumber, bool state, bool lerp = true) {
		for(int i = 0; i < width; i++) {
			PanelToggle pt = panels[i + rowNumber * width].GetComponent<PanelToggle>();

			if(state)
				pt.activate(lerp);
			else
				pt.deactivate(lerp);
		}
	}

	public void toggleCell(int rowNumber, int colNumber, bool state, bool lerp = true) {
		PanelToggle pt = panels[colNumber + rowNumber * width].GetComponent<PanelToggle>();
		
		if(state)
			pt.activate(lerp);
		else
			pt.deactivate(lerp);
	}

	public void toggleCells(bool state, params Vector2[] cells) {
		foreach(Vector2 cell in cells) {
			toggleCell ((int)cell.x, (int)cell.y, state);
		}
	}
}
