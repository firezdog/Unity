using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textController : MonoBehaviour {

	public Text text;

	// cell, mirror, sheets_0, lock_0, sheets_1, cell_mirror, lock_1, freedom
	private Dictionary<string, System.Action> States = new Dictionary<string, System.Action>();
	private string myState;
	private string input;
	
	// Use this for initialization
	void Start () {
		States.Add("cell", state_cell);
		States.Add("sheets_0", state_sheets_0);
		States.Add("lock_0", state_lock_0);
		States.Add("mirror", state_mirror);
		States.Add("cell_mirror", state_cell_mirror);
		States.Add("sheets_1", state_sheets_1);
		States.Add("lock_1", state_lock_1);
		myState = "cell";
	}
	
	// Update is called once per frame
	void Update () {
		
		States[myState]();

	}

	void state_lock_1() {

		text.text = "By holding the mirror close to the keypad, you are able to make out the smudge of the guard's fingerprints on numbers 3, 3, and 6.\n\nTo go back to the cell, press C. To enter the keycode \"336\", press K. To examine the lock more closely, press E.";

	}

	void state_sheets_1() {
	
		text.text = "The sheets' reflection looks as dirty as the original.\n\nTo go back to the cell, press C.";

		if(Input.GetKeyDown(KeyCode.C)) {
			myState = "cell_mirror";
		}
	
	}

	void state_cell() {
	
		text.text = "You are in a prison cell, and you want to escape. There are some dirty sheets on the bed and a mirror on the wall; the door is locked from the outside.\n\nTo look at the mirror, press M; to look at the sheets, press S; to look at the locked door, press D.";

		if(Input.GetKeyDown(KeyCode.S)) {
			myState = "sheets_0";
		} else if (Input.GetKeyDown(KeyCode.D)) {
			myState = "lock_0";
		} else if (Input.GetKeyDown(KeyCode.M)) {
			myState = "mirror";
		}
	
	}

	void state_cell_mirror() {
	
		text.text = "You have pried the mirror loose from the wall and now wonder what to do next.\n\nTo use the mirror with the sheets, press S; to use the mirror with the lock, press L.";

		if(Input.GetKeyDown(KeyCode.S)) {
			myState = "sheets_1";
		} else if (Input.GetKeyDown(KeyCode.L)) {
			myState = "lock_1";
		}
	
	}

	void state_sheets_0() {
	
		text.text = "The sheets smell as if they haven't been washed in weeks -- in fact, they haven't.\n\nPress C to return to the cell.";

		if(Input.GetKeyDown(KeyCode.C)) {
			myState = "cell";
		}
	
	}

	void state_lock_0() {

		text.text = "This is one of those button locks. You have no idea what the combination is. You wish you could somehow see where the dirty fingerprints are.\n\nPress C to return to the cell.";

		if(Input.GetKeyDown(KeyCode.C)) {
			myState = "cell";
		}

	}

	void state_mirror() {

		text.text = "The dirty old mirror seems loose.\n\nPress T to take the mirror; press C to return to the cell.";

		if(Input.GetKeyDown(KeyCode.C)) {
			myState = "cell";
		}

		if(Input.GetKeyDown(KeyCode.T)) {
			myState = "cell_mirror";
		}

	}


}