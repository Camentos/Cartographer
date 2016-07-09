using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

//to do, send cloud info to fogcountupdater in scene is better i think

public class FogControl : MonoBehaviour
{
	private List<GameObject> childFog;
	private List<GameObject> dissipatedChildFog;
	private int currentLevel;
	private string currentFogStateName;

	void Awake()
	{
		currentLevel = PlayerPrefs.GetInt("Level_Number");
		currentFogStateName = "Level_" + currentLevel + "_FogState";
		Debug.Log (currentFogStateName);
		Debug.Log (PlayerPrefs.GetString (currentFogStateName));

		//add all fog instance children to list
		childFog = new List<GameObject> ();
		foreach(Transform child in transform)
		{
			if(child.gameObject.GetComponent<ParticleSystem>() != null)
				childFog.Add(child.gameObject);
		}

		PlayerPrefFogStateInterpreter ();
	}

	// Use this for initialization
	void Start () 
	{
		dissipatedChildFog = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		for(int i = 0; i< childFog.Count; i++)
		{
			if(childFog[i].GetComponent<ParticleSystem>().emissionRate == 0f && !dissipatedChildFog.Contains(childFog[i]))
			{
				Debug.Log ("collision detected");
				PlayerPrefFogStateUpdater(i);
				dissipatedChildFog.Add(childFog[i]);
			}
		}
	}

	private void PlayerPrefFogStateInterpreter()
	{
		string fogState = PlayerPrefs.GetString (currentFogStateName);
		for(int i = 0; i < fogState.Length; i++)
		{
			if (fogState[i] == '0')
			{
				FogEmissionInitializerZero(childFog, i);
			}
		}
	}
	
	private void FogEmissionInitializerZero(List<GameObject> childFogInstances, int index)
	{
		for(int i = 0; i < childFogInstances.Count; i++)
		{
			if(i == index)
			{
				childFogInstances[i].GetComponent<ParticleSystem>().emissionRate = 0;
				Debug.Log("FogState adjusted according to previous level: [" + index + "]");
			}
		}
	}
	
	private void PlayerPrefFogStateUpdater(int index)
	{
		string prevFogState = PlayerPrefs.GetString (currentFogStateName);
		string newFogState = "";
		for(int i = 0; i < prevFogState.Length; i++)
		{
			if(i == index)
			{
				newFogState = newFogState + '0';
			}
			else
			{
				newFogState = newFogState + prevFogState[i];
			}
		}
		Debug.Log("FogState changed from: " +prevFogState + " to [" + index + "] " + newFogState);
		PlayerPrefs.SetString ("Level_10001_FogState", newFogState);
	}
}
