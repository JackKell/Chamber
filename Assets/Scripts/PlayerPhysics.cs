using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]
public class PlayerPhysics : MonoBehaviour {
	
	public LayerMask collisionMask;
	public bool grounded;
	public bool movementStopped;
	
	private BoxCollider collider;
	private Vector3 size;
	private Vector3 center;
	
	private float skin = .00001f;
	
	private Ray ray;
	private RaycastHit hit;
	
	public void Start()
	{
		collider = GetComponent<BoxCollider>();
		size = collider.size;
		center = collider.center;
	}

	public void Move(Vector2 moveAmount)
	{
		float deltaY = moveAmount.y;
		float deltaX = moveAmount.x;
		Vector2 position = transform.position;
		
		//Checks Up and Down Collision
		grounded = false;
		for (int i = 0; i < 3; i++)
		{
			float direction = Mathf.Sign(deltaY);
			float x = (position.x + center.x - size.x/2) + size.x/2 * i;
			float y = position.y + center.y + size.x/2 * direction;
						
			ray = new Ray(new Vector2(x, y), new Vector2(0, direction));
			Debug.DrawRay(ray.origin, ray.direction);
			
			if (Physics.Raycast(ray,out hit,Mathf.Abs(deltaY) + skin,collisionMask))
			{
				float distance = Vector3.Distance(ray.origin, hit.point);
				
				if (distance > skin)
				{
					deltaY = distance * direction - skin * direction;				
				}
				else
				{		
					deltaY = 0;
				}
				grounded = true;
				break;
			}
		}
		
		//Checks Right and Left Collision
		movementStopped = false;
		for (int i = 0; i < 3; i++)
		{
			float direction = Mathf.Sign(deltaX);
			//Debug.Log("LR Direction: " + direction);
			float y = (position.y + center.y - size.y/2) + size.y/2 * i;
			float x = position.x + center.x + size.y/2 * direction;
			
			ray = new Ray(new Vector2(x, y), new Vector2(direction, 0));
			Debug.DrawRay(ray.origin, ray.direction);
			
			if (Physics.Raycast(ray,out hit,Mathf.Abs(deltaX) + skin,collisionMask))
			{
				//Debug.Log("Fire");
				float distance = Vector3.Distance(ray.origin, hit.point);
				
				if (distance > skin)
				{
					deltaX = distance * direction - skin * direction;				
				}
				else
				{		
					deltaX = 0;
				}
				movementStopped = true;
				break;
			}
		}
		
		Vector2 finalTransform = new Vector2(deltaX, deltaY);
		
		transform.Translate(finalTransform);
	}
}
