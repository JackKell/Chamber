using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Timer))]
public class GameManager : MonoBehaviour 
{
	static GameManager _instance;
	private Timer timer;
	public GameObject player1;
	public GameObject player2;

	
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
		timer = GetComponent<Timer>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		player1 = GameObject.Find ("Player 1");
		player2 = GameObject.Find ("Player 2");
		
		/*
		if (player1 != null)
		{
			entity1 = player1.GetComponent<EntityComponent>();
		}
		
		if (player2 != null)
		{
			entity2 = player2.GetComponent<EntityComponent>();
		}
		
		if (entity1 != null && entity2 != null)
		{
			if(!entity1.isAlive && !entity2.isAlive) 
			{
				timer.End();
				LoadGameOverScene();
			}
		}
		*/
		if (player1 != null && player2 != null)
		{
			EntityComponent entity1, entity2;
			entity1 = player1.GetComponent<EntityComponent>();
			entity2 = player2.GetComponent<EntityComponent>();
			Debug.Log("E1: " + entity1.isAlive);
			Debug.Log("E2: " + entity1.isAlive);
			if(!entity1.isAlive && !entity2.isAlive) 
			{
				Debug.Log("Both Players Are Dead");
				timer.End();
				LoadGameOverScene();
			}
		}
		
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			LoadTitleScene();
		}
		
		if (Input.GetKeyDown(KeyCode.R))
		{
			LoadTitleScene();
			LoadGameScene();
		}
		
		if (Input.GetKeyDown(KeyCode.L))
		{
			LoadGameOverScene();
		}
	}
	
	public void LoadTitleScene()
	{
		Application.LoadLevel("TitleScene");
	}
	
	public void LoadGameScene()
	{
		timer.End();
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
