using UnityEngine;
using System.Collections;

//requires a collider for touch/click area
[RequireComponent (typeof (Collider2D))]

public class IsMovable : MonoBehaviour 
{
	public bool isMovableX = false;
	public bool isMovableY = false;
	//public GameObject setterMover;

	public bool enableBoundaries;
	public float topBoundary;
	public float bottomBoundary;
	public float leftBoundary;
	public float rightBoundary;

	private Vector3 firstPosition;

	private Vector3 prevPosition;
	private Vector3 offset;
	private Vector3 curPosition;

	public void DisableIsMovable()
	{
		isMovableX = false;
		isMovableY = false;
	}

	public void EnableIsMovable()
	{
		isMovableX = true;
		isMovableY = true;
	}

	public void EnableIsMovableX()
	{
		isMovableX = true;
	}

	public void EnableIsMovableY()
	{
		isMovableY = true;
	}

	private void UpdateObjectPosition(Vector3 vTarget)
	{
		bool boundaryCrossed = false;
		if(enableBoundaries)
		{
			if(vTarget.y > (firstPosition.y + topBoundary))
				boundaryCrossed = true;
			if(vTarget.y < (firstPosition.y - bottomBoundary))
				boundaryCrossed = true;
			if(vTarget.x > (firstPosition.x + rightBoundary))
				boundaryCrossed = true;
			if(vTarget.x < (firstPosition.x - leftBoundary))
				boundaryCrossed = true;
		}
		if(!boundaryCrossed)
		{
			if(isMovableX && isMovableY)
			{
				gameObject.transform.position = new Vector3 (vTarget.x, vTarget.y, gameObject.transform.position.z);
			}
			else if(isMovableX)
			{
				gameObject.transform.position = new Vector3 (vTarget.x, gameObject.transform.position.y, gameObject.transform.position.z);
			}
			else if (isMovableY)
			{
				gameObject.transform.position = new Vector3 (gameObject.transform.position.x, vTarget.y, gameObject.transform.position.z);
			}
		}
	}


	// Use this for initialization
	void Start () 
	{
		firstPosition = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//for touch
		if(Input.touchCount == 1)
		{
			var touch = Input.GetTouch(0);
			switch (touch.phase)
			{
			case TouchPhase.Began:
				Debug.Log ("Down");
				prevPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
				break;
			case TouchPhase.Moved:
				if(this.GetComponent<Collider2D>() == Physics2D.OverlapPoint(new Vector2(prevPosition.x, prevPosition.y)))
				{
					offset = prevPosition - gameObject.transform.position;
					curPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
					Vector3 vTarget = curPosition - offset;

					UpdateObjectPosition (vTarget);

					prevPosition = curPosition;

					Debug.Log ("Dragging");
				}
				break;
			}
		}
	}

	void OnMouseDown()
	{
		Debug.Log ("Down");
		prevPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
	}

	void OnMouseDrag()
	{
		Debug.Log ("Dragging");
		offset = prevPosition - gameObject.transform.position;
		curPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector3 vTarget = curPosition - offset;

		UpdateObjectPosition (vTarget);

		prevPosition = curPosition;
	}

	void OnMouseUp()
	{
		Debug.Log ("Up");
	}
}
