using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.Mygame;

public class UserGUI : MonoBehaviour {
	private UserAction action;
	public int status = 0;
	private string hint = "hhh";
	GUIStyle style;
	GUIStyle buttonStyle;
	GUIStyle hintStyle;
	    public static FirstController controller;
	    public MyCharacterController characterCtrl;

	public static IState state = new IState(0, 0, 3, 3, false, null);
    public static IState endState = new IState(3, 3, 0, 0, true, null);

	void Start() {
		action = Director.getInstance ().currentSceneController as UserAction;

		style = new GUIStyle();
		style.fontSize = 40;
		style.alignment = TextAnchor.MiddleCenter;

		buttonStyle = new GUIStyle("button");
		buttonStyle.fontSize = 30;
		hintStyle = new GUIStyle {
        fontSize = 15,
        fontStyle = FontStyle.Normal
      };
	}
	void OnGUI() {
		
		if (status == 1) {
			GUI.Label(new Rect(Screen.width/2-50, Screen.height/2-85, 100, 50), "Gameover!", style);
			if (GUI.Button(new Rect(Screen.width/2-70, Screen.height/2, 140, 70), "Restart", buttonStyle)) {
				status = 0;
				action.restart ();
			}
		} else if(status == 2) {
			GUI.Label(new Rect(Screen.width/2-50, Screen.height/2-85, 100, 50), "You win!", style);
			if (GUI.Button(new Rect(Screen.width/2-70, Screen.height/2, 140, 70), "Restart", buttonStyle)) {
				status = 0;
				action.restart ();
			}
		}
	}
	

    
}
