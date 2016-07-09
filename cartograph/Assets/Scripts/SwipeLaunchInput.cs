using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SwipeLaunchInput : MonoBehaviour 
{
	public Button launchButton;
	public enum SwipeDirection {Up, Right, Down, Left};
	public SwipeDirection swipeDirectionRequired;
	[Range(10f, 100f)]
	public float swipeDistanceRequired =  40f;
	[Range(1f, 179f)]
	public float swipeAngleMaxDeviation;

	private Vector2 startPosition;
	private Vector2 endPosition;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnMouseDown()
	{
		startPosition = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
		Debug.Log("Down");
	}

	void OnMouseDrag()
	{

	}

	void OnMouseUp()
	{
		endPosition = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
		float distance = Vector2.Distance(startPosition, endPosition);
		Debug.Log("Distance" + distance);
		if(distance > swipeDistanceRequired)
		{
			if(DirectionAndAngleChosenMatchesVector(startPosition, endPosition, swipeDirectionRequired, swipeAngleMaxDeviation))
				launchButton.onClick.Invoke();
		}
	}

	private bool DirectionAndAngleChosenMatchesVector(Vector2 vectorStart, Vector2 vectorEnd, SwipeDirection chosenDirection, float angleRequired)
	{
		Vector2 vectorNet = vectorEnd - vectorStart;
		float angleBetween = 0f;
		//this is the right way
		//Debug.Log ("---------AngleDefaultDown " + Vector2.Angle(vectorNet, Vector2.down));
		if(chosenDirection == SwipeDirection.Up)
		{
			if(vectorEnd.y > vectorStart.y)
			{
				angleBetween = Vector2.Angle(vectorNet, Vector2.up);
				Debug.Log("Angle: " + angleBetween);
				if(angleBetween < angleRequired)
					return true;
			}
		}
		else if(chosenDirection == SwipeDirection.Right)
		{
			if(vectorEnd.x > vectorStart.x)
			{
				angleBetween = Vector2.Angle(vectorNet, Vector2.right);
				Debug.Log("Angle: " + angleBetween);
				if(angleBetween < angleRequired)
					return true;
			}
		}
		else if(chosenDirection == SwipeDirection.Down)
		{
			if(vectorEnd.y < vectorStart.y)
			{
				angleBetween = Vector2.Angle(vectorNet, Vector2.down);
				Debug.Log("Angle: " + angleBetween);
				if(angleBetween < angleRequired)
					return true;
			}
		}
		else if(chosenDirection == SwipeDirection.Left)
		{
			if(vectorEnd.x < vectorStart.x)
			{
				angleBetween = Vector2.Angle(vectorNet, Vector2.left);
				Debug.Log("Angle: " + angleBetween);
				if(angleBetween < angleRequired)
					return true;
			}
		}
		return false;
	}
}
