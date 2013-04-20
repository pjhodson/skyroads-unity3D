using UnityEngine;
using System.Collections;

public class shipParticles : MonoBehaviour {
	
	public motionControl moCon;
	public Detonator endBoom;
	public Mesh shipMesh;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(moCon.dead == true && moCon.camUn == true)
		{
			endBoom.Explode();
			Invoke ("disableRender",3);
		}
	
	}
	
	void disableRender () {
		this.gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;
	}
}
