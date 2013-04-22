using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	
	
	public Camera theCamera;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 newPos = theCamera.ScreenToWorldPoint(Input.mousePosition);
		newPos.x = -115;
		newPos.z = 350;
		this.gameObject.transform.position = newPos;
	}
}
