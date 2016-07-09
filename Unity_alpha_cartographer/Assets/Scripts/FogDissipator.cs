using UnityEngine;
using System.Collections;

public class FogDissipator: MonoBehaviour {

	public float dissipateTime = 0.5f;

	private bool startDissipate = false;
	private float dissipateTimeTemp;

	void Start () 
	{
		dissipateTimeTemp = dissipateTime;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(startDissipate)
		{
			dissipateTimeTemp = dissipateTimeTemp - Time.deltaTime;
			if(dissipateTimeTemp <= 0)
			{
				this.GetComponent<ParticleSystem>().emissionRate = 0;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Projectile")
		{
			this.GetComponent<ParticleSystem>().loop = false;
			this.GetComponent<ParticleSystem>().emissionRate = 0.5f;
			startDissipate = true;
		}
	}
}
