﻿using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
	static GameManager _instance;
	
	static public bool isActive 
	{
		get 
		{
			return _instance != null;
		}
	}
	
	static public GameManager instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = Object.FindObjectOfType(typeof(GameManager)) as GameManager;
				
				if (_instance == null)
				{
					GameObject go = new GameObject("_gamemanager");
					DontDestroyOnLoad(go);
					_instance = go.AddComponent<GameManager>();
				}
			}
			return _instance;
		}
	}

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	public void LoadTitleScene()
	{
		Application.LoadLevel("TitleScene");
	}
	
	public void LoadGameScene()
	{
		Application.LoadLevel("GameScene");
	}
	
	public void LoadCreditsScene()
	{
		Application.LoadLevel("CreditsScene");
	}
	
	public void LoadGameOverScene()
	{
		Application.LoadLevel("GameOverScene");
	}
	
	public void LoadAboutScene()
	{
		Application.LoadLevel("AboutScene");
	}
}
