using UnityEngine;
using System.Collections;

public class motionControl : MonoBehaviour {
	
	public float jumpForce = 0;
	public float desiredVelocity = 0;
	public float sideways = 0;
	
	private float throttle = 0;
	private bool jumping = false;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		throttle = Mathf.Clamp (throttle + 0.5f * Input.GetAxis("Vertical"),0,desiredVelocity);
		
		constantForce.relativeForce = new Vector3(0,0,throttle);
		
		rigidbody.AddForce(Input.GetAxis("Horizontal") * sideways,0,0);
				
		if( Input.GetKeyDown(KeyCode.Space) )
		{
			RaycastHit hit;
			Physics.Raycast(rigidbody.position + new Vector3(0,1,-1),-Vector3.up, out hit);
			Debug.Log(hit.distance);
			Debug.DrawRay(rigidbody.position,-Vector3.up,Color.red);
			if(!jumping && hit.distance < 10) 
				rigidbody.AddForce(0,jumpForce,0,ForceMode.Force);
			jumping = true;
		}		
		
	}
	
	void OnTriggerEnter(Collider terrainHit) {
		if(terrainHit.gameObject.tag == "DEATH")
		{
			Debug.Log ("YOU'RE DEAD");
		}
	}
	
	void OnCollisionEnter(Collision collide) {
		if(collide.gameObject.tag == "Terrain")
		{
			jumping = false;
		}
	}
		
}
