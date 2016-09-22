using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AttemptsCountUpdater : MonoBehaviour 
{
	public Text attemptsCountUpdater;

	private int attempts = 0;

	// Use this for initialization
	void Start () 
	{
		attemptsCountUpdater.text = "Attempts: " + attempts;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void IncreaseAttempts()
	{
		attempts++;
		attemptsCountUpdater.text = "Attempts: " + attempts;
	}
}
