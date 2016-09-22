using UnityEngine;
using System.Collections;

public class EnvironmentControl : MonoBehaviour
{
	// Use this for initialization
	void Start () 
	{
		PlayerPrefLevelNumberInterpreter ();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	private void PlayerPrefLevelNumberInterpreter()
	{
		string fogName = "Fog" + PlayerPrefs.GetInt ("Level_Number").ToString ();
		GameObject fog = (GameObject)Instantiate (Resources.Load ("Fogs/" + fogName));
		fog.transform.parent = this.transform;
	}
}
