using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class FogCountUpdater : MonoBehaviour 
{
	public Text fogCountUpdaterText;

	private GameObject fogCountUpdater;
	private List<GameObject> childList;
	private List<GameObject> dissipatedChildList;
	
	// Use this for initialization
	void Start () 
	{
		//fogCountUpdater = GameObject.Find (fogCountUpdaterName);

		childList = new List<GameObject> ();
		dissipatedChildList = new List<GameObject> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		//populate the child list;
		GameObject fogObject = GameObject.FindGameObjectWithTag("Fog");
		foreach(Transform child in fogObject.transform)
		{
			if(child.GetComponent<ParticleSystem>() != null && !childList.Contains(child.gameObject))
			{
				childList.Add(child.gameObject);
			}
		}

		foreach(GameObject child in childList)
		{
			if(child.GetComponent<ParticleSystem>().emissionRate == 0 && !dissipatedChildList.Contains (child))
			{
				dissipatedChildList.Add(child);
				fogCountUpdaterText.text = "Fog Dissipated: " + dissipatedChildList.Count + "/" + childList.Count;
			}
		}
	}
}
