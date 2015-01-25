using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Timer))]
public class GameManager : MonoBehaviour 
{
	static GameManager _instance;
	private Timer timer;
	public GameObject Player1;
	public GameObject Player2;

	
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
	
	}
	
	public void LoadTitleScene()
	{
		Application.LoadLevel("TitleScene");
	}
	
	public void LoadGameScene()
	{
		timer.isStopped = false;
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
