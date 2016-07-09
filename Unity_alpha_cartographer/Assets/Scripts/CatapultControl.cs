using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CatapultControl : MonoBehaviour, IReloadable
{
	public GameObject catapultLauncher;
	//public GameObject catapultLink;
	public GameObject catapultWeight;
	public GameObject catapultSetter;

	private Vector3 catapultLauncherDefaultPosition;
	//private Vector3 catapultLinkDefaultPosition;
	private Vector3 catapultWeightDefaultPosition;
	private Vector3 catapultSetterDefaultPosition;

	private Quaternion catapultLauncherDefaultRotation;
	private Quaternion catapultLinkDefaultRotation;
	private Quaternion catapultWeightDefaultRotation;
	private Quaternion catapultSetterDefaultRotation;

	// Use this for initialization
	void Start () 
	{
		catapultLauncherDefaultPosition = catapultLauncher.transform.position;
		//catapultLinkDefaultPosition = catapultLink.transform.position;
		catapultWeightDefaultPosition = catapultWeight.transform.position;
		catapultSetterDefaultPosition = catapultSetter.transform.position;

		catapultLauncherDefaultRotation = catapultLauncher.transform.rotation;
		//catapultLinkDefaultRotation = catapultLink.transform.rotation;
		catapultWeightDefaultRotation = catapultWeight.transform.rotation;
		catapultSetterDefaultRotation = catapultSetter.transform.rotation;
	}

	// Update is called once per frame
	void Update ()
	{
		
	}

	public void Reload()
	{
		Debug.Log("Catapult Reloading..................");
		catapultLauncher.GetComponent<Rigidbody2D>().sleepMode = RigidbodySleepMode2D.StartAsleep;
		catapultLauncher.GetComponent<Rigidbody2D>().freezeRotation = true;

		TransformReset(catapultLauncher, catapultLauncherDefaultPosition, catapultLauncherDefaultRotation);
		//transformReset(catapultLink, catapultLinkDefaultPosition, catapultLinkDefaultRotation);
		TransformReset(catapultWeight, catapultWeightDefaultPosition, catapultWeightDefaultRotation);
		TransformReset(catapultSetter, catapultSetterDefaultPosition, catapultSetterDefaultRotation);

		catapultSetter.GetComponent<IsMovable>().EnableIsMovableX();
		
		/*
		foreach(GameObject child in catapultChildObjects)
		{

			foreach(GameObject childPrefab in catapultChildObjectPrefabs)
			{
				//anything else to check beside name?
				if(childPrefab.name == child.name)
				{
					GameObject.Destroy(child);
					GameObject.Instantiate(childPrefab).transform.SetParent(this.transform);
				}
			}
		}
		*/
	}

	private void TransformReset(GameObject theObject, Vector3 defaultPosition, Quaternion defaultRotation)
	{
		Debug.Log("Transform Resetting - - - ");
		theObject.transform.position = new Vector3(defaultPosition.x, defaultPosition.y, defaultPosition.z);
		theObject.transform.rotation = new Quaternion(defaultRotation.x, defaultRotation.y, defaultRotation.z, defaultRotation.w);
		/*
		theObject.transform.position = theDefaultTransform.position;
		theObject.transform.rotation = theDefaultTransform.rotation;
		theObject.transform.position.Set(theDefaultTransform.position.x, theDefaultTransform.position.y, theDefaultTransform.position.z);
		theObject.transform.rotation.Set(theDefaultTransform.rotation.x, theDefaultTransform.rotation.y, theDefaultTransform.rotation.z, theDefaultTransform.rotation.w);
		*/
	}
}
