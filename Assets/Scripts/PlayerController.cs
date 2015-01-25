using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerPhysics))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(EntityComponent))]
public class PlayerController : MonoBehaviour 
{
	public int playerNumber = 1;
	public Animator animator;

	public float gravity = 20;
	public float speed = 8;
	public float acceleration = 30;
	public float jumpHeight = 12;

	// States
	private bool jumping;
	
	private float currentSpeed;
	private float targetSpeed ;
	private Vector2 amountToMove;
	
	private PlayerPhysics playerPhysics;
	private SpriteRenderer renderer;
	private EntityComponent entity;
	
	// Use this for initialization
	void Start () 
	{
		playerPhysics = GetComponent<PlayerPhysics>();
		renderer = GetComponent<SpriteRenderer> ();
		entity = GetComponent<EntityComponent> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(entity.isAlive == false) {
			this.gameObject.SetActive(false);
		}

		if (playerPhysics.movementStopped)
		{
			targetSpeed = 0;
			currentSpeed = 0;
		}
		
		targetSpeed = Input.GetAxisRaw("Horizontal_P" + playerNumber) * speed;

		animator.SetBool("Running", targetSpeed != 0);

		currentSpeed = IncrementTowards(currentSpeed, targetSpeed, acceleration);

		// The player is on the ground
		if (playerPhysics.grounded)
		{
			amountToMove.y = 0;

			if(jumping) {
				jumping = false;
				animator.SetBool("Jumping", false);
			}

			// The jump button is pressed
			if (Input.GetButtonDown("Jump_P" + playerNumber))
			{
				amountToMove.y = jumpHeight;
				jumping = true;
				animator.SetBool("Jumping", true);
			}
		}
		
		amountToMove.x = currentSpeed;
		amountToMove.y -= gravity * Time.deltaTime;
		playerPhysics.Move(amountToMove * Time.deltaTime);

		// Face direction
		float moveDir = Input.GetAxisRaw ("Horizontal_P" + playerNumber);
		if(moveDir != 0) {
			transform.eulerAngles = (moveDir > 0) ? Vector3.up * 180 : Vector3.zero;
		}

		animator.SetBool("Grounded", playerPhysics.grounded);
	}

	void OnCollisionEnter(Collision collision) {
		Debug.Log("I collided!");
	}
	
	private float IncrementTowards(float currentSpeed, float targetSpeed, float acceleration)
	{
		if (currentSpeed == targetSpeed)
		{
			return currentSpeed;
		}
		else
		{
			//Math.Sign states whether a number is negative or positive
			float direction = Mathf.Sign (targetSpeed - currentSpeed);
			currentSpeed += acceleration * Time.deltaTime * direction;
			return (direction == Mathf.Sign(targetSpeed-currentSpeed))? currentSpeed: targetSpeed;
		}
	}
}
