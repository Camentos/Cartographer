using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ProjectileControl : MonoBehaviour, IReloadable
{
	public GameObject projectileObject;
	public Button reloadButton;

	private Vector3 projectileObjectDefaultPosition;
	private Quaternion projectileObjectDefaultRotation;

	// Use this for initialization
	void Start () 
	{
		projectileObjectDefaultPosition = projectileObject.transform.position;
		projectileObjectDefaultRotation = projectileObject.transform.rotation;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//disableReloadButtonWhileInMotion();
	}

	public void DisableReloadButtonWhileInMotion()
	{
		Debug.Log("Velocity of Projectile: " + projectileObject.GetComponent<Rigidbody2D>().velocity.magnitude);
		if(projectileObject.GetComponent<Rigidbody2D>().velocity.magnitude > 0 && reloadButton.interactable)
		{
			reloadButton.interactable = false;
		}
		else if(projectileObject.GetComponent<Rigidbody2D>().velocity.magnitude == 0 && !reloadButton.interactable)
		{
			reloadButton.interactable = true;
		}
	}

	public void Reload()
	{
		Debug.Log("Projectile Reloading..................");
		projectileObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		projectileObject.GetComponent<Rigidbody2D>().angularVelocity = 0f;
		TransformReset(projectileObject, projectileObjectDefaultPosition, projectileObjectDefaultRotation);
	}

	private void TransformReset(GameObject theObject, Vector3 defaultPosition, Quaternion defaultRotation)
	{
		Debug.Log("Transform Resetting - - - ");
		theObject.transform.position = new Vector3(defaultPosition.x, defaultPosition.y, defaultPosition.z);
		theObject.transform.rotation = new Quaternion(defaultRotation.x, defaultRotation.y, defaultRotation.z, defaultRotation.w);
	}
	/*
	private void transformReset(GameObject theObject, Transform theDefaultTransform)
	{
		Debug.Log("Transform Resetting - - - ");
		theObject.transform.position = new Vector3(theDefaultTransform.position.x, theDefaultTransform.position.y, theDefaultTransform.position.z);
		theObject.transform.rotation = new Quaternion(theDefaultTransform.rotation.x, theDefaultTransform.rotation.y, theDefaultTransform.rotation.z, theDefaultTransform.rotation.w);
	}
	*/
}
