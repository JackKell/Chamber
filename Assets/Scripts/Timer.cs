﻿using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {
	
	public float elaspedTime;
	private bool isRunning = false;
	
	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(isRunning == true)
		{
			elaspedTime += Time.deltaTime;
		}
	}
	
	public void Begin()
	{
		isRunning = true;
	}
	
	public void End()
	{
		isRunning = false;
	}
}
