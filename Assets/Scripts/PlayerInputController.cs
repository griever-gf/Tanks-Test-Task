using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class PlayerInputController : MonoBehaviour {

    public TankManager tankManager;

    void Start () {
	    
	}

	void Update () {
        bool isAnyTurnKeyHold = true;
        bool isAnyMoveKeyHold = true;

        if (Input.GetKey(KeyCode.LeftArrow))
            tankManager.ProcessKeyHold(KeyCode.LeftArrow);
        else if (Input.GetKey(KeyCode.RightArrow))
            tankManager.ProcessKeyHold(KeyCode.RightArrow);
        else
            isAnyTurnKeyHold = false;

        if (Input.GetKey(KeyCode.UpArrow))
            tankManager.ProcessKeyHold(KeyCode.UpArrow);
        else if (Input.GetKey(KeyCode.DownArrow))
            tankManager.ProcessKeyHold(KeyCode.DownArrow);
        else
            isAnyMoveKeyHold = false;


        if (!isAnyMoveKeyHold && !isAnyTurnKeyHold)
        {
            if (Input.GetKeyUp(KeyCode.LeftArrow))
                tankManager.ProcessKeyUp(KeyCode.LeftArrow);
            else if (Input.GetKeyUp(KeyCode.RightArrow))
                tankManager.ProcessKeyUp(KeyCode.RightArrow);
            else if (Input.GetKeyUp(KeyCode.UpArrow))
                tankManager.ProcessKeyUp(KeyCode.UpArrow);
            else if (Input.GetKeyUp(KeyCode.DownArrow))
                tankManager.ProcessKeyUp(KeyCode.DownArrow);
        }
    }
}
