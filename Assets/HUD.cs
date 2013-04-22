using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {
	
	public motionControl moCon = null;
	private string jumpNot = "Jump Charged";
	
	void OnGUI () {
		if(moCon.jumping == true) { jumpNot = "Charging"; }
		else jumpNot = "Jump Charged!";
		
		GUI.Box (new Rect(10,10,100,35), new GUIContent(moCon.throttle.ToString()));
		GUI.Box (new Rect(10,50,100,35), new GUIContent(jumpNot));
				
		if(moCon.hasWon == true || moCon.dead == true)
		{
			Screen.showCursor = true;
			if(GUI.Button (new Rect(Screen.width/2 - 50, Screen.height/2 - 50, 200,50), new GUIContent("Restart")))
			{
				Application.LoadLevel("srproj");
			}
			if(GUI.Button (new Rect(Screen.width/2-50, Screen.height/2 + 25, 200,50), new GUIContent("Main Menu")))
			{
				Application.LoadLevel("mainMenu");
			}
		}
		
	}
	
}
