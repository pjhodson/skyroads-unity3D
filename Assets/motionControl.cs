using UnityEngine;
using System.Collections;

public class motionControl : MonoBehaviour {
	
	public float jumpForce = 0;
	public float desiredVelocity = 0;
	public float sideways = 0;
	
	public AudioClip thud = null;
	public AudioClip win = null;
	public AudioClip fail = null;
	
	public float throttle = 0;
	public bool jumping = false;
	
	public bool hasWon = false;
	public bool dead = false;
	public bool camUn = false;
	
	public Camera mainCam;
	
	private Vector3 lastPos;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		//We clamp the throttle at desired velocity, which is set in the inspector.
		throttle = Mathf.Clamp (throttle + 0.5f * Input.GetAxis("Vertical"),0,desiredVelocity);
		
		//We apply a constant force in the forward direction, with the magnitude of the throttle. 
		constantForce.relativeForce = Vector3.forward * throttle;
		
		//This makes the sideways motion more effective at higher speeds, because sideways motion felt sluggish when going quickly.
	
		
		//Add a sidways force depending on which key is pressed.
		rigidbody.AddForce(Input.GetAxis("Horizontal") * sideways,0,0);
		
		//Jump.
		if( Input.GetAxis("Jump") > 0 && jumping == false )
		{
			rigidbody.AddForce(0,jumpForce,0,ForceMode.Impulse);
			jumping = true;
		}	
		
		if(dead)
		{
			mainCam.transform.parent = null;
			mainCam.transform.position = Vector3.Lerp(mainCam.transform.position,new Vector3(lastPos.x,500,lastPos.z), .01f*Time.deltaTime);
			mainCam.transform.LookAt (this.gameObject.transform);
			camUn = true;
		}
	}


	
	//This function will trigger the endgame state.
	void OnTriggerEnter(Collider terrainHit) {
		if(terrainHit.gameObject.tag == "DEATH")
		{
			lastPos = this.gameObject.transform.position;
			this.gameObject.audio.clip = fail;
			this.gameObject.audio.Play();
			Debug.Log ("YOU'RE DEAD");
			dead = true;
		}
		
		if(terrainHit.gameObject.tag == "WIN")
		{
			hasWon = true;
			this.gameObject.audio.clip = win;
			this.gameObject.audio.Play();
			Debug.Log("YOU WIN!");
			throttle = 0;
			sideways = 0;
			rigidbody.velocity = Vector3.zero;
		}
	}
	
	//Collision for the jumping stuff.
	void OnCollisionEnter(Collision collide) {
		if(collide.gameObject.tag == "Terrain")
		{
			if(!hasWon){
				this.gameObject.audio.clip = thud;
				this.gameObject.audio.Play();
			}
			jumping = false;
		}
	}	
}
