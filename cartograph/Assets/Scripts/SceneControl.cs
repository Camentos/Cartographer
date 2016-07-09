using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SceneControl : MonoBehaviour 
{
	public List<GameObject> reloadableObjects;

	void Awake()
	{
		//DontDestroyOnLoad (this);
		PlayerPrefs.SetInt ("Level_Number", 10001);
		PlayerPrefs.SetString ("Level_10001_FogState", "11111111111");
		Debug.Log("Setting PlayerPrefs default values");
	}

	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void ReloadAll()
	{
		Debug.Log ("Attempting to reload all; " + reloadableObjects.Count);
		foreach(GameObject reloadableObject in reloadableObjects)
		{
			Debug.Log ("Reloading: " + reloadableObject.name);
			//Debug.Log("IReloadable is: " + reloadableObject.GetComponent("IReloadable").name);
			//reloadableObject.GetComponent<IReloadable>().Reload();

			MonoBehaviour[] list = reloadableObject.GetComponents<MonoBehaviour>();
			foreach(MonoBehaviour mb in list)
			{
				Debug.Log ("MonoBehaviour found: " + mb);
				if (mb is IReloadable)
				{
					Debug.Log ("IReloadable of: " + mb);
					IReloadable ir = mb as IReloadable;
					//reloadableObject.GetComponent<IReloadable>().Reload();
					ir.Reload();
				}
			}
		}
	}
}
