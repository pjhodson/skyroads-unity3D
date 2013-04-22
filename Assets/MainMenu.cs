using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	
	
	public Camera theCamera;
	
	public TextMesh title;
	public TextMesh play;
	
	private bool flyOff;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Screen.showCursor = false;
	
		title.fontSize = Screen.height/4;
		play.fontSize = Screen.height/5;
		
		if(!flyOff) {
		Vector3 newPos = theCamera.ScreenToWorldPoint(Input.mousePosition);
		newPos.x = -115;
		newPos.z = 350;
		newPos.y -= 10;
		this.gameObject.transform.position = newPos;
		}
		
		else {
			float angle = .1f;
			this.gameObject.transform.position = Vector3.Lerp(this.gameObject.transform.position, new Vector3(theCamera.ScreenToWorldPoint(new Vector3(Screen.width+200,0,0)).x,this.gameObject.transform.position.y, 350), 0.02f);
			angle+=angle*Time.deltaTime/5;
			this.gameObject.transform.RotateAround(Vector3.right,angle);
		}
		
		title.transform.position = theCamera.ScreenToWorldPoint(new Vector3(50, Screen.height - 50, 350));
		play.transform.position = theCamera.ScreenToWorldPoint(new Vector3(Screen.width/2, Screen.height/2, 350));
		
		if(Input.GetMouseButton(0)) {
			Ray theRay = theCamera.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if(Physics.Raycast(theRay, out hit, 1000)) {
				string theButton = hit.collider.name.ToString();
				switch(theButton)
				{
				case "Play":
					flyOff = true;
					Invoke ("goToLevel", 1.5f);
					break;
				default:
					break;
				}
				
			}
		}		
	}
	
	void goToLevel() { 
		Application.LoadLevel("srproj");
	}
	
}
