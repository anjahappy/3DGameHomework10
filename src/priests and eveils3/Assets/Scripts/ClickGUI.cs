using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.Mygame;

public class ClickGUI : MonoBehaviour {
	UserAction action;
	MyCharacterController characterController;
	    public static IState state = new IState(0, 0, 3, 3, false, null);
		public static IState endState = new IState(3, 3, 0, 0, true, null);
GUIStyle style;
	GUIStyle buttonStyle;
	GUIStyle hintStyle;
	private string hint = "";
 public static FirstController controller;
	public void setController(MyCharacterController characterCtrl) {
		characterController = characterCtrl;
	}

	void Start() {
		action = Director.getInstance ().currentSceneController as UserAction;
		      controller = Director.getInstance().currentSceneController as FirstController;

		buttonStyle = new GUIStyle("button");
		buttonStyle.fontSize = 50;
		hintStyle = new GUIStyle {
        fontSize = 30,
        fontStyle = FontStyle.Normal
		};
	}

	void OnGUI() {
		
		if (GUI.Button(new Rect(Screen.width - 300, 90, 200, 100), "Tips", buttonStyle)) {
        //Debug.Log("StateRight: " + state.rightDevils + " " + state.rightPriests);
        //Debug.Log("StateLeft: " + state.leftDevils + " " + state.leftPriests);

        IState temp = IState.bfs(state, endState);
        //Debug.Log("NextRight: " + temp.rightDevils + " " + temp.rightPriests);
        //Debug.Log("NextLeft: " + temp.leftDevils + " " + temp.leftPriests);
        hint = "Hint:\n" + "Right:  Devils: " + temp.rightDevils + "   Priests: " + temp.rightPriests +
          "\nLeft:  Devils: " + temp.leftDevils + "   Priests: " + temp.leftPriests;
        //int priestsOffset = temp.leftPriests - state.leftPriests;
        //int devilsOffset = temp.leftDevils - state.leftDevils;
        //Debug.Log("offset: " + priestsOffset + " " + devilsOffset);
        //controller.AIMove(priestsOffset, devilsOffset);
      }
	  GUI.Label(new Rect(300, 90, 100, 50),
         hint, hintStyle);
	}

	void OnMouseDown() {
		if (gameObject.name == "boat") {
			action.moveBoat ();

		

		int from_priest = controller.fromCoast.getCharacterNum()[0];
          int from_devil = controller.fromCoast.getCharacterNum()[1];
          int to_priest = controller.toCoast.getCharacterNum()[0];
          int to_devil = controller.toCoast.getCharacterNum()[1];
          bool location = controller.boat.get_to_or_from() ==-1  ? true : false;
          int[] boatCount = controller.boat.getCharacterNum ();
		if (location) {	// boat at toCoast
			to_priest += boatCount[0];
			to_devil += boatCount[1];
		} else {	// boat at fromCoast
			from_priest += boatCount[0];
			from_devil += boatCount[1];
		}
          state = new IState(to_priest, to_devil, from_priest, from_devil, location , null);
		} else {
			action.characterIsClicked (characterController);
		}
	}

}
