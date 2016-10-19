using UnityEngine;
using System.Collections;

public class TankManager : MonoBehaviour {

    public GameData gameData;
    public TankController tankController;
    //public TankWeaponController tankWaeponController;
    public CameraController cameraController;

    void Start () {
	
	}
	
	void Update () {
	
	}

    public void ProcessKeyHold(KeyCode key_code)
    {
        switch (key_code)
        {
            case KeyCode.LeftArrow:
            case KeyCode.RightArrow:
            case KeyCode.UpArrow:
            case KeyCode.DownArrow:
                tankController.ProcessKeyHold(key_code);
                cameraController.UpdateCameraPosition(tankController.GetTankPosition());
                break;
            case KeyCode.X:
            case KeyCode.Q:
            case KeyCode.W:
                break;
        }
    }

    public void ProcessKeyUp(KeyCode key_code)
    {
        switch (key_code)
        {
            case KeyCode.LeftArrow:
            case KeyCode.RightArrow:
            case KeyCode.UpArrow:
            case KeyCode.DownArrow:
                tankController.ProcessKeyUp(key_code);
                cameraController.UpdateCameraPosition(tankController.GetTankPosition());
                break;
            case KeyCode.X:
            case KeyCode.Q:
            case KeyCode.W:
                break;
        }
    }

    public float GetTankMovementSpeed()
    {
        return gameData.GetTankMovementSpeed();
    }

    public float GetTankRotationSpeed()
    {
        return gameData.GetTankRotationSpeed();
    }
}
